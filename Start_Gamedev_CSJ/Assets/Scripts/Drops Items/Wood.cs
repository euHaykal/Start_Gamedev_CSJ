using UnityEngine;

public class Wood : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float timeMove;

    private float timeCount;

    void Update()
    {
        timeCount += Time.deltaTime; //Acumula o tempo que passou desde o último frame

        if (timeCount < timeMove) //Se o tempo acumulado for menor ao tempo de movimento
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime); //Move o objeto para a direita
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) //Se o objeto colidir com o jogador
        {
            collision.GetComponent<PlayerItems>().totalWood++; //Aumenta o total de madeira do jogador
            Destroy(gameObject); //Destrói o objeto
        }
    }

}
