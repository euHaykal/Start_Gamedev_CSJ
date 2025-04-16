using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float speed;

    private Rigidbody2D rig;
    private Vector2 _direction;  //Encapsulamento

    public Vector2 direction  //Encapsulamento
    {
        get { return _direction; }  //Pega o valor da váriável _direction
        set { _direction = value; }  //Seta o valor da variável direction para o mesmo da variável _direction
    }

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();  //No inicio da cena, o unity ira procurar pelo combonente Rigidbody2D no objeito personagem
    }

    private void Update()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));  //Armazena informação quando o input horizontal ou vertical é acionado
    }

    private void FixedUpdate() //Só utiliza para coisas com física
    {
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime); //Acessa a posição do personagem e adiciona ao input acionado
    }

}
