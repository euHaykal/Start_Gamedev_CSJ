using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Player player;
    private Animator anim;

    void Start()
    {
        player = GetComponent<Player>();  //Permete a Unity a acessar o componente Player e pegar as informações do mesmo
        anim = GetComponent<Animator>();  //Permete a Unity a acessar o componente Animator e pegar as informações do mesmo
    }

    void Update()
    {
        if(player.direction.sqrMagnitude > 0)  //Código para verificar está clicando input de andar ou não
        {
            anim.SetInteger("transition",1);
        }
        else
        {
            anim.SetInteger("transition",0);
        }

        if(player.direction.x > 0)  //Código para verificar se o jogador está andando para a direita. Reflete a arte do personagem para a direção correta do movimento
        {
            transform.eulerAngles = new Vector2(0,0);
        }

        if(player.direction.x < 0)  //Código para verificar se o jogador está andando para a esquerda. Reflete a arte do personagem para a direção correta do movimento
        {
            transform.eulerAngles = new Vector2(0,180);
        }
    }

}
