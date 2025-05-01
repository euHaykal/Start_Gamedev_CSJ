using UnityEngine;

public class Fish : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Se o objeto colidir com o jogador
        {
            PlayerItems playerItems = collision.GetComponent<PlayerItems>();

            if (playerItems.currentFishies < playerItems.fishiesLimit) // Verifica se o jogador ainda pode pegar mais peixes
            {
                playerItems.FishiesLimit(1); // Adiciona 1 peixe respeitando o limite
                Destroy(gameObject); // Destrói o objeto
            }
            else
            {
                Debug.Log("Fishies limit reached! Item will remain in the scene."); // Mensagem opcional
            }
        }
    }
}