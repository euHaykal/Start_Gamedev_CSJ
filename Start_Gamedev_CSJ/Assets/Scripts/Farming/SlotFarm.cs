using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip holeSFX;
    [SerializeField] private AudioClip carrotSFX;

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
    private bool plantedCarrot;
    private bool carrotCollected; //verifica se o jogador coletou a cenoura
    private bool isPlayer; //Fica verdadeiro enquanto o player está enconstando na cenoura

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

            if (currentWater >= waterAmount && !plantedCarrot) // verifica se o jogador tem água suficiente para plantar a cenoura
            {
                audioSource.PlayOneShot(holeSFX); // toca o som do buraco
                spriteRenderer.sprite = carrot; // seta o sprite da cenoura

                carrotCollected = false; // Reseta a variável para permitir replantar
                plantedCarrot = true; // seta a variável de cenoura plantada como true
            }

            if (Input.GetKeyDown(KeyCode.E) && plantedCarrot && !carrotCollected && isPlayer) // verifica se o jogador apertou a tecla E
            {
                if (playerItems.currentCarrots < playerItems.carrotLimit) // verifica se o jogador tem espaço para mais cenouras
                {
                    audioSource.PlayOneShot(carrotSFX);
                    spriteRenderer.sprite = hole;
                    playerItems.CarrotLimit(1);
                    currentWater = 0;
                    carrotCollected = true; // Resetar as variáveis para permitir novo plantio
                    plantedCarrot = false; // Não resetamos dugHole aqui para manter o buraco cavado
                }
                else
                {
                    Debug.Log("Carrot limit reached! Item will remain in the scene."); // mensagem opcional
                }
            }
        }
    }

    public void OnHit()
    {
        digAmount--;

        if (digAmount <= initialDigAmount / 2)
        {
            spriteRenderer.sprite = hole; // Seta o sprite do buraco
            dugHole = true; // Marca o buraco como cavado
            carrotCollected = false; // Reseta a variável para permitir replantar
            plantedCarrot = false; // Reseta o estado de cenoura plantada
            currentWater = 0; // Reseta a água
        }
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
        if (collision.CompareTag("Player"))
        {
            isPlayer = true; //verifica se o jogador está na área de detecção do buraco
        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("WateringCan"))
        {
            detectingPlayer = false; //verifica se o jogador saiu da área de detecção do buraco
        }
        if (collision.CompareTag("Player"))
        {
            isPlayer = false; //verifica se o jogador está fora da área de detecção do buraco
        }
    }
}
