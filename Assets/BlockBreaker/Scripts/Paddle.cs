using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    private MouseActionsd controls;
    [SerializeField] GameObject paddleObj;

    // Start is called before the first frame update
    void Awake()
    {
        controls = new MouseActionsd();
        controls.Mouse.MousePos.performed += ctx => MousePos(ctx.ReadValue<Vector2>());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void MousePos(Vector2 pos)
    {
        //Debug.Log(pos.x / Screen.width * 16);
        float mousePos = pos.x / Screen.width * 16;
        Vector2 paddlePos = new Vector2(mousePos, transform.position.y);
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
