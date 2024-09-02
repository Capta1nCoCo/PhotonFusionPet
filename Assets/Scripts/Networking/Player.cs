using Fusion;
using StarterAssets;
using UnityEngine;

public class Player : NetworkBehaviour
{
    [Networked] private TickTimer delay { get; set; }

    [SerializeField] private Ball _prefabBall;

    private ThirdPersonController _tpController;

    private Vector3 _forward = Vector3.forward;

    public void Initialization(ThirdPersonController thirdPersonController)
    {
        _tpController = thirdPersonController;
    }

    public override void FixedUpdateNetwork()
    {
        if (_tpController != null)
        {
            if (GetInput(out NetworkInputData data))
            {
                _tpController.PlayerMovement(data);

                if (data.move.sqrMagnitude > 0)
                    _forward = new Vector3(data.move.x, 0f, data.move.y);

                if (HasStateAuthority && delay.ExpiredOrNotRunning(Runner))
                {
                    if (data.buttons.IsSet(NetworkInputData.MOUSEBUTTON0))
                    {
                        Runner.Spawn(_prefabBall,
                        transform.position + _forward, Quaternion.LookRotation(_forward), Object.InputAuthority, (runner, o) =>
                        {
                            // Initialize the Ball before synchronizing it
                            o.GetComponent<Ball>().Init();
                        });
                    }
                }
            }
        }
    }
}
