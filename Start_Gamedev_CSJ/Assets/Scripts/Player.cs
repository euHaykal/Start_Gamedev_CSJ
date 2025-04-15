using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float speed;

    private Rigidbody2D rig;
    private Vector2 direction;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();  //No inicio da cena, o unity ira procurar pelo combonente Rigidbody2D no objeito personagem
    }

    private void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));  //Armazena informação quando o input horizontal ou vertical é acionado
    }

    private void FixedUpdate() //Só utiliza para coisas com física
    {
        rig.MovePosition(rig.position + direction * speed * Time.fixedDeltaTime); //Acessa a posição do personagem e adiciona ao input acionado
    }

}
