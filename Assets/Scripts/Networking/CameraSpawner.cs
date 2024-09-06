using Fusion;
using UnityEngine;
using Cinemachine;

public class CameraSpawner : NetworkBehaviour
{
    [SerializeField] private GameObject cameraPrefab;
    [SerializeField] private CinemachineVirtualCamera virtualCameraPrefab;
    [SerializeField] private Transform playerCameraRoot;
    [SerializeField] private PlayerInitializer playerInitializer;

    private GameObject _playerCamera;

    public override void Spawned()
    {
        if (Object.HasInputAuthority) // Check if this is the local player
        {
            _playerCamera = Instantiate(cameraPrefab, transform.position, Quaternion.identity);
            virtualCameraPrefab = Instantiate(virtualCameraPrefab, transform.position, Quaternion.identity);
            virtualCameraPrefab.Follow = playerCameraRoot;
            _playerCamera.SetActive(true);
            playerInitializer.SetPlayerCamera(_playerCamera);
        }
    }

    public override void Despawned(NetworkRunner runner, bool hasState)
    {
        if (_playerCamera != null)
        {
            Destroy(_playerCamera);
        }
    }
}
