using StarterAssets;
using UnityEngine;

public class PlayerInitializer : MonoBehaviour
{
    [SerializeField] private StarterAssetsInputs _playerInput;
    [SerializeField] private Player _player;
    [SerializeField] private ThirdPersonController _tpController;

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
}
