using UnityEngine;

public class House : MonoBehaviour
{
    [Header("Amounts")]
    [SerializeField] private Color startColor;
    [SerializeField] private Color endColor;
    [SerializeField] private float timeAmount;

    [SerializeField] private int woodCost;

    [Header("Components")]
    [SerializeField] private GameObject houseCollider;
    [SerializeField] private SpriteRenderer houseSprite;
    [SerializeField] private Transform point;


    [SerializeField] private bool detectingPlayer;
    private Player player;
    private PlayerItems playerItems;
    private PlayerAnim playerAnim;

    private float timeCount;
    private bool isBeginning;

    private void Start()
    {
        player = FindAnyObjectByType<Player>();
        playerAnim = player.GetComponent<PlayerAnim>();
        playerItems = player.GetComponent<PlayerItems>();
    }

    private void Update()
    {
        if (detectingPlayer && Input.GetKeyDown(KeyCode.E) && playerItems.currentWood >= woodCost)
        {
            // Construção da casa é iniciada
            isBeginning = true;
            playerAnim.OnHammeringStarted();
            houseSprite.color = startColor;
            playerAnim.transform.position = point.position;
            player.isMoving = true;
            playerItems.currentWood -= woodCost; // Remove o custo de madeira
        }

        if (isBeginning)
        {
            timeCount += Time.deltaTime;
            if (timeCount >= timeAmount)
            {
                isBeginning = false;
                playerAnim.OnHammeringFinished();
                houseSprite.color = endColor;
                player.isMoving = false;
                houseCollider.SetActive(true);
            }
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
