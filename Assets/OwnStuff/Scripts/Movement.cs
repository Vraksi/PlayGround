using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private PlayerControls controls;
    private Vector2 move;
    bool isTrue = true;

    public float maxSpeed = 7;

    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Awake()
    {
        controls = new PlayerControls();
        rb2d = GetComponent<Rigidbody2D>();
        
        controls.GamePlay.Movement.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.GamePlay.Movement.canceled += ctx => move = Vector2.zero;
        controls.GamePlay.DebugLog.performed += ctx => SwitchSticks();

    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMovement();
    }

    //To change controls and give buttons more stuff to do in the same scene.
    private void SwitchSticks()
    {
        if (isTrue)
        {
            controls.GamePlay.Movement.Disable();
            controls.GamePlay.Newmovement.Enable();
            controls.GamePlay.Newmovement.performed += ctx => move = ctx.ReadValue<Vector2>();
            controls.GamePlay.Newmovement.canceled += ctx => move = Vector2.zero;
            isTrue = false;
        }
        else if (!isTrue)
        {
            controls.GamePlay.Newmovement.Disable();
            controls.GamePlay.Movement.Enable();
            controls.GamePlay.Movement.performed += ctx => move = ctx.ReadValue<Vector2>();
            controls.GamePlay.Movement.canceled += ctx => move = Vector2.zero;
            isTrue = true;
        }
    }

    private void HorizontalMovement()
    {
        Vector2 currentMoveSpeed = new Vector2(move.x * maxSpeed, move.y * maxSpeed);
        rb2d.velocity = currentMoveSpeed;
    }

    //Skal være med for Enable vores movement input control
    private void OnEnable()
    {
        controls.GamePlay.Enable();
    }

    //Skal være med for Disable vores movement input control
    private void OnDisable()
    {
        controls.GamePlay.Disable();
    }
}
