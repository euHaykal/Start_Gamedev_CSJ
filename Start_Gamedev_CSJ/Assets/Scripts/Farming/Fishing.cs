using UnityEngine;

public class Fishing : MonoBehaviour
{
    [SerializeField] private bool detectingPlayer;
    [SerializeField] private int percentageFish; //Chance de pegar peixe
    [SerializeField] private GameObject fishPrefab; //Prefab do peixe que o jogador pode pegar


    private PlayerItems player;
    private PlayerAnim playerAnim;

    private void Start()
    {
        player = FindAnyObjectByType<PlayerItems>();
        playerAnim = player.GetComponent<PlayerAnim>();
    }

    private void Update()
    {
        if (detectingPlayer && Input.GetKeyDown(KeyCode.E))
        {
            playerAnim.OnFishingStarted(); //Chama a animação de pescar
        }
    }

    public void OnFishing()
    {
        int randomValue = Random.Range(1, 100); //Gera um valor aleatório entre 0 e 100

        if (randomValue <= percentageFish) //Se o valor aleatório for menor ou igual a 50, o jogador pega um peixe
        {
            Debug.Log("Fish caught!");
            Instantiate(fishPrefab, player.transform.position + new Vector3(Random.Range(-2.5f, -0.5f), 0f, 0f), Quaternion.identity); //Instancia o prefab do peixe na posição do jogador
        }
        else
        {
            Debug.Log("No fish caught.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            detectingPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            detectingPlayer = false;
        }
    }
}
