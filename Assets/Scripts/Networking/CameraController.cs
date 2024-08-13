using Fusion;
using UnityEngine;

public class CameraController : NetworkBehaviour
{
    private const string _mainCameraTag = "MainCamera";

    [SerializeField] private GameObject cameraPrefab;
    private GameObject playerCamera;

    public override void Spawned()
    {
        if (Object.HasInputAuthority) // Check if this is the local player
        {
            // Instantiate the camera
            playerCamera = Instantiate(cameraPrefab, transform.position, Quaternion.identity);

            // Make the camera a child of the player (optional)
            playerCamera.transform.SetParent(transform);

            // Position the camera relative to the player (adjust as needed)
            playerCamera.transform.localPosition = new Vector3(0, 2, -5);

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
