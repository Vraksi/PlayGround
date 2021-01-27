using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    //Config parameters
    public MouseActionsd controls;
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float screenWidthMax = 16;
    [SerializeField] float screenWidthMin = 0;

    //state
    GameStatus gameStatus;
    Ball ball;
    Vector2 paddlePos;
    

    // Start is called before the first frame update
    void Awake()
    {
        controls = new MouseActionsd();
        controls.Mouse.MousePos.performed += ctx => MousePos(ctx.ReadValue<Vector2>());
    }

    private void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        ball = FindObjectOfType<Ball>();
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
