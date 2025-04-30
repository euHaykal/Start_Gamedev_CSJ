using UnityEngine;

public class Water : MonoBehaviour
{
    private PlayerItems player;

    [SerializeField] private bool detectingPlayer;
    [SerializeField] private int waterAmount; //Quantidade de água que o jogador pode pegar

    private void Start()
    {
        player = FindAnyObjectByType<PlayerItems>();
    }

    private void Update()
    {
        if (detectingPlayer && Input.GetKeyDown(KeyCode.E))
        {
            player.WaterLimit(waterAmount);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            detectingPlayer = true;
            Debug.Log("Player detected in water area.");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            detectingPlayer = false;
            Debug.Log("Player exited water area.");
        }
    }

}
