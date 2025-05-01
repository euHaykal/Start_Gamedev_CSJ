using UnityEngine;

public class Wood : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float timeMove;

    private float timeCount;

    void Update()
    {
        timeCount += Time.deltaTime;

        if (timeCount < timeMove)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime); // Move na direção definida
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Se o objeto colidir com o jogador
        {
            PlayerItems playerItems = collision.GetComponent<PlayerItems>();

            if (playerItems.currentWood < playerItems.woodLimit) // Verifica se o jogador ainda pode pegar mais madeira
            {
                playerItems.WoodLimit(1); // Adiciona 1 madeira respeitando o limite
                Destroy(gameObject); // Destrói o objeto
            }
            else
            {
                Debug.Log("Wood limit reached! Item will remain in the scene."); // Mensagem opcional
            }
        }
    }
}