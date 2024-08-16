using Fusion;
using StarterAssets;
using UnityEngine.InputSystem;

public class Player : NetworkBehaviour
{
    private NetworkCharacterController _cc;
    public ThirdPersonController _controller;
    public bool isInitialized;

    public override void FixedUpdateNetwork()
    {
        if (isInitialized)
        {
            if (GetInput(out NetworkInputData data))
            {
                _controller.PlayerMovement(data);
            }
        }
    }
}
