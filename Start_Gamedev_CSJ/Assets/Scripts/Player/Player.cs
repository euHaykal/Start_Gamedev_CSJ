using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector] public bool isMoving; //Variável para verificar se o jogador está se movendo


    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float waterSpent;

    private Rigidbody2D rig;
    private PlayerItems playerItems; //Variável para acessar o script PlayerItems

    private float initialSpeed;
    private bool _isRunning;
    private bool _isRolling;
    private bool _isCutting;
    private bool _isDiggin; //Variável para verificar se o jogador está cavando
    private bool _isWatering; //Variável para verificar se o jogador está regando
    private Vector2 _direction;  //Encapsulamento

    [HideInInspector] public int handlingObj = 1;

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
    public bool isDiggin  //Encapsulamento
    {
        get { return _isDiggin; }  //Pega o valor da váriável _isDiggin
        set { _isDiggin = value; }  //Seta o valor da variável isDiggin para o mesmo da variável _isDiggin
    }
    public bool isWatering  //Encapsulamento
    {
        get { return _isWatering; }  //Pega o valor da váriável _isWatering
        set { _isWatering = value; }  //Seta o valor da variável isWatering para o mesmo da variável _isWatering
    }
    public Vector2 direction  //Encapsulamento
    {
        get { return _direction; }  //Pega o valor da váriável _direction
        set { _direction = value; }  //Seta o valor da variável direction para o mesmo da variável _direction
    }

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();  //No inicio da cena, o unity ira procurar pelo combonente Rigidbody2D no objeito personagem
        playerItems = GetComponent<PlayerItems>(); //No inicio da cena, o unity ira procurar pelo combonente PlayerItems no objeito personagem
        initialSpeed = speed;
    }

    private void Update()
    {
        if (!isMoving)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                handlingObj = 1; //Seta o objeto que o jogador está segurando como 1
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                handlingObj = 2; //Seta o objeto que o jogador está segurando como 2
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                handlingObj = 3; //Seta o objeto que o jogador está segurando como 3
            }

            OnInput();
            OnRun();
            OnRolling();
            OnCutting();
            OnDiggin();
            OnWatering();
        }
    }

    private void FixedUpdate() //Só utiliza para coisas com física
    {
        if (!isMoving)
        {
            OnMove();
        }
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
        if (Input.GetKeyDown(KeyCode.LeftShift))  //Se o Shift esquerdo é pressionado, a variável speed recebe o valor da variável runSpeed
        {
            speed = runSpeed;
            _isRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift)) //Quando o Shift esquerdo é pressionado, a variável speed volta a receber o valor da variável initialSpeed
        {
            speed = initialSpeed;
            _isRunning = false;
        }
    }

    void OnRolling()
    {
        if (Input.GetMouseButtonDown(1))
        {
            speed = runSpeed;
            _isRolling = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            speed = initialSpeed;
            _isRolling = false;
        }
    }

    void OnCutting()
    {
        if (handlingObj == 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                speed = 0;
                isCutting = true;
            }

            if (Input.GetMouseButtonUp(0))
            {
                speed = initialSpeed;
                isCutting = false;
            }
        }
    }

    void OnDiggin()
    {
        if (handlingObj == 2)
        {
            if (Input.GetMouseButtonDown(0))
            {
                speed = 0;
                isDiggin = true;
            }

            if (Input.GetMouseButtonUp(0))
            {
                speed = initialSpeed;
                isDiggin = false;
            }
        }
    }

    void OnWatering()
    {
        if (handlingObj == 3)
        {
            if (Input.GetMouseButtonDown(0) && playerItems.currentWater > 0)
            {
                speed = 0;
                isWatering = true;
            }

            if (Input.GetMouseButtonUp(0) || playerItems.currentWater <= 0) //Verifica se o jogador soltou o botão esquerdo do mouse ou se a quantidade de água do jogador é menor ou igual a 0
            {
                speed = initialSpeed;
                isWatering = false;
            }

            if (isWatering) //Verifica se o jogador está regando
            {
                playerItems.currentWater -= waterSpent; //Diminui a quantidade de água do jogador
            }
        }
    }

    #endregion

}
