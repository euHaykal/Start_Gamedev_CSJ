using UnityEngine;

public class SkeletonAnim : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask playerLayer;

    private Animator anim;
    private PlayerAnim player;
    private Skeleton skeleton;

    private void Start()
    {
        anim = GetComponent<Animator>();
        player = FindAnyObjectByType<PlayerAnim>();
        skeleton = GetComponentInParent<Skeleton>();
    }

    public void PlayAnim(int value)
    {
        anim.SetInteger("transition", value);
    }

    public void Attack()
    {
        if (!skeleton.isDead)
        {
            Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, attackRange, playerLayer);

            if (hit != null)
            {
                player.OnHit(); // Chama o método OnHit do PlayerAnim
            }
        }
    }

    public void OnHit()
    {
        if (skeleton.currentHealth <= 0) // Verifica se a vida do esqueleto é menor ou igual a 0
        {
            skeleton.isDead = true; // Define o esqueleto como morto
            anim.SetTrigger("isDead"); // Inicia a animação de morrer

            if (skeleton.healthBar != null)
            {
                Canvas healthBarCanvas = skeleton.healthBar.GetComponentInParent<Canvas>();
                if (healthBarCanvas != null)
                {
                    Destroy(healthBarCanvas.gameObject); // Destroi o GameObject do Canvas da barra de vida
                }
            }

            Destroy(skeleton.gameObject, 1f); // Destroi o objeto esqueleto após 1 segundo
        }
        else
        {
            anim.SetTrigger("isHit"); // Inicia a animação de ser atingido
            skeleton.currentHealth--; // Diminui a vida do esqueleto em 1

            skeleton.healthBar.fillAmount = skeleton.currentHealth / skeleton.maxHealth; // Atualiza a barra de vida do esqueleto 

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
