using Fusion;
using StarterAssets;
using UnityEngine.InputSystem;

public class Player : NetworkBehaviour
{
    private ThirdPersonController _tpController;

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
            }
        }
    }
}
