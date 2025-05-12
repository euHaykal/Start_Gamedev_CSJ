using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [Header("Attack Settings")]
    [SerializeField] private Transform attackPoint; //Ponto de ataque do jogador
    [SerializeField] private float attackRange; //Raio de ataque do jogador
    [SerializeField] private LayerMask enemyLayer; //Camada de inimigos
    [SerializeField] private float revoceryTime;

    private bool isHitting;
    private float timeCount;

    private Player player;
    private Animator anim;

    private Fishing fishing; //Variável para acessar o script Fishing

    void Start()
    {
        player = GetComponent<Player>();  //Permete a Unity a acessar o componente Player e pegar as informações do mesmo
        anim = GetComponent<Animator>();  //Permete a Unity a acessar o componente Animator e pegar as informações do mesmo

        fishing = FindAnyObjectByType<Fishing>(); //Permite a Unity a acessar o script Fishing e pegar as informações do mesmo

    }

    void Update()
    {
        OnMove();
        OnRun();

        if (isHitting)
        {
            timeCount += Time.deltaTime; //Contador de tempo para o tempo de recuperação do jogador após ser atingido
            if (timeCount >= revoceryTime) //Verifica se o jogador foi atingido e se o tempo de recuperação já passou
            {
                isHitting = false; //Reabilita a animação de ser atingido
                timeCount = 0; //Reseta o contador de tempo
            }
        }
    }

    #region Movement
    void OnMove()
    {
        if (player.direction.sqrMagnitude > 0)  //Código para verificar está clicando input de andar ou não
        {
            if (player.isRolling)  //Checa se o player está rolando
            {
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Rolling"))
                {
                    anim.SetTrigger("isRoll");  //Animator transition = 3
                }
            }
            else
            {
                anim.SetInteger("transition", 1);  //Animator transition = 1
            }

        }
        else
        {
            anim.SetInteger("transition", 0);  //Animator transition = 0
        }

        if (player.direction.x > 0)  //Código para verificar se o jogador está andando para a direita. Reflete a arte do personagem para a direção correta do movimento
        {
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (player.direction.x < 0)  //Código para verificar se o jogador está andando para a esquerda. Reflete a arte do personagem para a direção correta do movimento
        {
            transform.eulerAngles = new Vector2(0, 180);
        }

        if (player.isCutting)
        {
            anim.SetInteger("transition", 3);
        }

        if (player.isDiggin)
        {
            anim.SetInteger("transition", 4);
        }

        if (player.isWatering)
        {
            anim.SetInteger("transition", 5);
        }
    }

    void OnRun()
    {
        if (player.isRunning && player.direction.sqrMagnitude > 0)
        {
            anim.SetInteger("transition", 2);  //Animator transition = 2
        }
    }

    #endregion

    #region Actions

    public void OnFishingStarted() //É chamado quando o jogador começa a pescar
    {
        anim.SetTrigger("isFishing");
        player.isMoving = true; //Desabilita o movimento do jogador enquanto ele pesca
    }

    public void OnFishingFinished()  //É chamado quando a animação de pescar termina
    {
        fishing.OnFishing(); //Chama a função OnFishing do script Fishing
        player.isMoving = false; //Habilita o movimento do jogador após pescar
    }

    public void OnHammeringStarted()
    {
        anim.SetBool("isHammering", true); //Inicia a animação de martelar
    }

    public void OnHammeringFinished()
    {
        anim.SetBool("isHammering", false); //Para a animação de martelar
    }

    #endregion

    #region Attack

    public void OnHit()
    {
        if (!isHitting)
        {
            anim.SetTrigger("isHit"); //Inicia a animação de ser atingido
            isHitting = true; //Desabilita a animação de ser atingido
        }
    }

    public void OnAttack()
    {
        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, attackRange, enemyLayer); //Verifica se o jogador está atacando um inimigo

        if (hit != null) //Verifica se o jogador está atacando um inimigo
        {
            //ataca o inimigo
            hit.GetComponentInChildren<SkeletonAnim>().OnHit(); //Chama a função OnHit do script SkeletonAnim
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    #endregion

}