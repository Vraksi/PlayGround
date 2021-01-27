using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    //Config parameters
    
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float screenWidthMax = 16;
    [SerializeField] float screenWidthMin = 0;

    //state
    private GameStatus gameStatus;
    private Ball ball;
    private Vector2 paddlePos;
    public MouseActionsd controls;


    // Start is called before the first frame update
    void Awake()
    {
        controls = new MouseActionsd();        
    }

    private void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        ball = FindObjectOfType<Ball>();
        
        if (controls == null)
        {
            controls = new MouseActionsd();
            controls.Mouse.MousePos.performed += ctx => MousePos(ctx.ReadValue<Vector2>());
            controls.Mouse.MouseDown.performed += ctx => ball.LaunchOnMouseClick();
        }
        else
        {
            controls.Mouse.MousePos.performed += ctx => MousePos(ctx.ReadValue<Vector2>());
            controls.Mouse.MouseDown.performed += ctx => ball.LaunchOnMouseClick();
        }
    }

    // Update is called once per frame
    void Update()
    { 
        if (gameStatus.IsAutoPlayEnabled())
        {
            paddlePos.x = ball.gameObject.transform.position.x;
            paddlePos.y = transform.position.y;
            transform.position = paddlePos;
        }
    }

    private void MousePos(Vector2 pos)
    {
        Debug.Log(pos);
        float mousePos = pos.x / Screen.width * screenWidthInUnits;
        paddlePos = new Vector2(mousePos, transform.position.y);
        //Debug.Log(pos.x / Screen.width * screenWidthInUnits);
        if (!gameStatus.IsAutoPlayEnabled())
        {
            paddlePos.x = Mathf.Clamp(mousePos, screenWidthMin, screenWidthMax);          
        }
        transform.position = paddlePos;
    }


    //Skal være med for Enable vores movement input control
    private void OnEnable()
    {
        controls.Mouse.Enable();
    }

    //Skal være med for Disable vores movement input control
    private void OnDisable()
    {
        controls.Mouse.Disable();
    }
}
