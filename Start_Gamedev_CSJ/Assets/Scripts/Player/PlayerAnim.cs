using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
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
    }

    #region Movement
    void OnMove()
    {
        if (player.direction.sqrMagnitude > 0)  //Código para verificar está clicando input de andar ou não
        {
            if (player.isRolling)  //Checa se o player está rolando
            {
                anim.SetTrigger("isRoll");  //Animator transition = 3
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
        if (player.isRunning)
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

}