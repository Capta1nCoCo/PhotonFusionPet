using StarterAssets;
using UnityEngine;

[RequireComponent(typeof(StarterAssetsInputs),(typeof(Player)), (typeof(ThirdPersonController)))]
public class PlayerInitializer : MonoBehaviour
{
    private StarterAssetsInputs _playerInput;
    private Player _player;
    private ThirdPersonController _tpController;

    private void OnEnable()
    {
        _playerInput = GetComponent<StarterAssetsInputs>();
        _tpController = GetComponent<ThirdPersonController>();
        _tpController.Initialization(_playerInput);

        BasicSpawner basicSpawner = FindObjectOfType<BasicSpawner>();
        basicSpawner.Initialization(_playerInput);

        Player player = GetComponent<Player>();
        player.Initialization(_tpController);
    }

    public void SetPlayerCamera(GameObject camera)
    {
        _tpController.setCamera = camera;
    }
}
