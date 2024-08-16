using StarterAssets;
using UnityEngine;

public class PlayerDependencyInjector : MonoBehaviour
{
    [SerializeField] private StarterAssetsInputs playerInput;
    [SerializeField] private Player player;
    [SerializeField] private ThirdPersonController controller;

    private void Awake()
    {
        playerInput = GetComponent<StarterAssetsInputs>();
        controller = GetComponent<ThirdPersonController>();
        FindObjectOfType<BasicSpawner>().setInput = playerInput;
        var player = GetComponent<Player>();
        player._controller = controller;
        player.isInitialized = true;
    }
}
