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

                if (data.direction.sqrMagnitude > 0)
                    _forward = data.direction;

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
