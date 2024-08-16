using Fusion;
using UnityEngine;
using Cinemachine;

public class CameraSpawner : NetworkBehaviour
{
    [SerializeField] private GameObject cameraPrefab;
    [SerializeField] private CinemachineVirtualCamera virtualCameraPrefab;
    [SerializeField] private Transform playerCameraRoot;

    private GameObject playerCamera;

    public override void Spawned()
    {
        if (Object.HasInputAuthority) // Check if this is the local player
        {
            playerCamera = Instantiate(cameraPrefab, transform.position, Quaternion.identity);
            virtualCameraPrefab = Instantiate(virtualCameraPrefab, transform.position, Quaternion.identity);
            virtualCameraPrefab.Follow = playerCameraRoot;
            playerCamera.SetActive(true);
        }
    }

    public override void Despawned(NetworkRunner runner, bool hasState)
    {
        if (playerCamera != null)
        {
            Destroy(playerCamera);
        }
    }
}
