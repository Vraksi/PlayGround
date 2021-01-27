using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //Config params
    [SerializeField] float moveSpeed;
    [SerializeField] float padding;

    //Cached Reference
    private PlayerShipControls playerControls;

    float xMin;
    float xMax;
    float yMin;
    float yMax;

    //state variables
    Vector2 direction;

    private void Awake()
    {
        playerControls = new PlayerShipControls();
        //LAMDBA BRUG DEM FOR STORED VALUES
        playerControls.Move.Horizontal.performed += ctx => direction.x = ctx.ReadValue<float>();
        playerControls.Move.Vertical.performed += ctx => direction.y = ctx.ReadValue<float>();
    }

    // Start is called before the first frame update
    void Start()
    {
        SetupMoveBoundaries();
    }

    private void SetupMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
        Debug.Log(xMin + xMax);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        var deltaXY = direction * Time.deltaTime * moveSpeed;   
        var newXPos = Mathf.Clamp(transform.position.x + deltaXY.x, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaXY.y, yMin, yMax);
        transform.position = new Vector2(newXPos, newYPos);
    }

    //Skal være med for Enable vores movement input control
    private void OnEnable()
    {
        playerControls.Move.Enable();
    }

    //Skal være med for Disable vores movement input control
    private void OnDisable()
    {
        playerControls.Move.Disable();
    }
}
