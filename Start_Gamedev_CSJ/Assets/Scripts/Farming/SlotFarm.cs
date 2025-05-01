using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite hole;
    [SerializeField] private Sprite carrot;

    [Header("Settings")]
    [SerializeField] private int digAmount;  //quantidade de buracos que o jogador pode cavar
    [SerializeField] private float waterAmount;
    [SerializeField] private bool detectingPlayer; //verifica se o jogador está na área de detecção do buraco    

    private int initialDigAmount; //quantidade inicial de buracos que o jogador pode cavar
    private float currentWater;
    private bool dugHole;

    PlayerItems playerItems;

    private void Start()
    {
        playerItems = FindAnyObjectByType<PlayerItems>(); //procurar o objeto do tipo PlayerItems na cena
        initialDigAmount = digAmount; //seta a quantidade inicial de buracos que o jogador pode cavar
    }

    private void Update()
    {
        if (dugHole) // verifica se o jogador já cavou o buraco
        {
            if (detectingPlayer)
            {
                currentWater += 0.01f;
            }

            if (currentWater >= waterAmount) // verifica se o jogador tem água suficiente para plantar a cenoura
            {
                spriteRenderer.sprite = carrot; // seta o sprite da cenoura

                if (Input.GetKeyDown(KeyCode.E)) // verifica se o jogador apertou a tecla E
                {
                    if (playerItems.currentCarrots < playerItems.carrotLimit) // verifica se o jogador tem espaço para mais cenouras
                    {
                        spriteRenderer.sprite = hole; // seta o sprite do buraco
                        playerItems.CarrotLimit(1); // adiciona uma cenoura ao inventário do jogador
                        currentWater = 0; // zera a quantidade de água do jogador
                    }
                    else
                    {
                        Debug.Log("Carrot limit reached! Item will remain in the scene."); // mensagem opcional
                    }
                }
            }
        }
    }

    public void OnHit()
    {
        digAmount--;

        if (digAmount <= initialDigAmount / 2)
        {
            spriteRenderer.sprite = hole; //seta o sprite do buraco
            dugHole = true; //seta a variavel de buraco como true
        }

        // if (digAmount <= 0)
        // {
        //     spriteRenderer.sprite = carrot; //seta o sprite da cenoura
        // }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shovel"))
        {
            OnHit();
        }

        if (collision.CompareTag("WateringCan"))
        {
            detectingPlayer = true; //verifica se o jogador está na área de detecção do buraco
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("WateringCan"))
        {
            detectingPlayer = false; //verifica se o jogador saiu da área de detecção do buraco
        }
    }
}
