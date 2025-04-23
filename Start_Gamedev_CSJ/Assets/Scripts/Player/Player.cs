using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;

    private Rigidbody2D rig;

    private float initialSpeed;
    private bool _isRunning;
    private bool _isRolling;
    private bool _isCutting;
    private Vector2 _direction;  //Encapsulamento

    public bool isRunning  //Encapsulamento
    {
        get { return _isRunning; }  //Pega o valor da váriável _isRunning
        set { _isRunning = value; }  //Seta o valor da variável isRunning para o mesmo da variável _isRunning
    }
    public bool isRolling  //Encapsulamento
    {
        get { return _isRolling; }  //Pega o valor da váriável _isRolling
        set { _isRolling = value; }  //Seta o valor da variável isRolling para o mesmo da variável _isRolling
    }
    public bool isCutting  //Encapsulamento
    {
        get { return _isCutting; } 
        set { _isCutting = value; }
    }
    public Vector2 direction  //Encapsulamento
    {
        get { return _direction; }  //Pega o valor da váriável _direction
        set { _direction = value; }  //Seta o valor da variável direction para o mesmo da variável _direction
    }

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();  //No inicio da cena, o unity ira procurar pelo combonente Rigidbody2D no objeito personagem
        initialSpeed = speed;
    }

    private void Update()
    {
        OnInput();
        OnRun();
        OnRolling();
        OnCutting();
    }

    private void FixedUpdate() //Só utiliza para coisas com física
    {
        OnMove();
    }

    #region Movement

    void OnInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));  //Armazena informação quando o input horizontal ou vertical é acionado
    }

    void OnMove()
    {
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime); //Acessa a posição do personagem e adiciona ao input acionado
    }

    void OnRun()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))  //Se o Shift esquerdo é pressionado, a variável speed recebe o valor da variável runSpeed
        {
            speed = runSpeed;
            _isRunning = true;
        }

        if(Input.GetKeyUp(KeyCode.LeftShift)) //Quando o Shift esquerdo é pressionado, a variável speed volta a receber o valor da variável initialSpeed
        {
            speed = initialSpeed;
            _isRunning = false;
        }
    }

    void OnRolling()
    {
        if(Input.GetMouseButtonDown(1))
        {
            speed = runSpeed;
            _isRolling = true;
        }

        if(Input.GetMouseButtonUp(1))
        {
            speed = initialSpeed;
            _isRolling = false;
        }
    }

    void OnCutting()
    {
        if(Input.GetMouseButtonDown(0))  
        {
            speed = 0;
            _isCutting = true;
        }

        if(Input.GetMouseButtonUp(0)) 
        {
            speed = initialSpeed;
            _isCutting = false;
        }
    }

    #endregion

}
