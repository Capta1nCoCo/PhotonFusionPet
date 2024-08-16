using Fusion;
using UnityEngine;
using Cinemachine;

public class CameraSpawner : NetworkBehaviour
{
    private const string _mainCameraTag = "MainCamera";

    [SerializeField] private GameObject cameraPrefab;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private Transform playerCameraRoot;

    private GameObject playerCamera;

    public override void Spawned()
    {
        if (Object.HasInputAuthority) // Check if this is the local player
        {
            // Instantiate the camera
            playerCamera = Instantiate(cameraPrefab, transform.position, Quaternion.identity);

            virtualCamera = Instantiate(virtualCamera, transform.position, Quaternion.identity);
            virtualCamera.Follow = playerCameraRoot;

            // Activate the camera
            playerCamera.SetActive(true);
        }
    }

    public override void Despawned(NetworkRunner runner, bool hasState)
    {
        // Destroy the camera when the player is despawned
        if (playerCamera != null)
        {
            Destroy(playerCamera);
        }
    }
}
