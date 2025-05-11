using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Skeleton : MonoBehaviour
{
    [Header("Stats")]
    public float followRange;
    public float maxHealth;
    public float currentHealth;
    public Image healthBar;
    public bool isDead;


    [Header("Components")]
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private SkeletonAnim animControl;
    [SerializeField] private LayerMask playerLayer;


    private Player player;
    private bool detectingPlayer;

    private void Start()
    {
        currentHealth = maxHealth;
        player = FindAnyObjectByType<Player>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        if (!isDead && detectingPlayer)
        {
            agent.isStopped = false;
            agent.SetDestination(player.transform.position);

            if (Vector2.Distance(transform.position, player.transform.position) <= agent.stoppingDistance)
            {
                // chegou no limite de distância do player
                animControl.PlayAnim(2);

            }
            else
            {
                //skeleton se movendo
                animControl.PlayAnim(1);
            }

            float posX = (player.transform.position.x - transform.position.x);
            if (posX < 0)
            {
                transform.eulerAngles = new Vector2(0, 180);
            }
            else if (posX > 0)
            {
                transform.eulerAngles = new Vector2(0, 0);
            }
        }
    }

    private void FixedUpdate()
    {
        DetectPlayer();
    }

    public void DetectPlayer()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, followRange, playerLayer);
        if (hit != null)
        {
            // player está dentro do range
            detectingPlayer = true;
        }
        else
        {
            // player está fora do range
            detectingPlayer = false;
            animControl.PlayAnim(0);
            agent.isStopped = true;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, followRange);
    }

}
