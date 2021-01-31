using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //Config params
    [Header("PlayerMovement")]
    [SerializeField] float moveSpeed;
    [SerializeField] float padding;

    [Header("Projectile")]
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFiringPeriod = 0.5f;

    [Header("PlayerStats")]
    [SerializeField] float health = 100;

    Coroutine firingCoroutine;

    //Cached Reference
    private PlayerShipControls playerControls;
    

    float xMin;
    float xMax;
    float yMin;
    float yMax;

    //state variables
    private Vector2 direction;
    //private float firing;

    private void Awake()
    {        
        playerControls = new PlayerShipControls();
        //LAMDBA BRUG DEM FOR STORED VALUES
        playerControls.Move.Horizontal.performed += ctx => direction.x = ctx.ReadValue<float>();
        playerControls.Move.Vertical.performed += ctx => direction.y = ctx.ReadValue<float>();
        playerControls.Move.Fire.performed += ctx => Fire(ctx.ReadValue<float>());        
    }

    // Start is called before the first frame update
    void Start()
    {
        SetupMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        //Fire();
        
    }

    private void Fire(float firing)
    {
        Debug.Log(firing);
        if (firing == 1f) 
        {
            //Den store referencen og starter Coroutinen
            firingCoroutine = StartCoroutine(FireContinouosly());
        }
        if (firing == 0f)
        {
            StopCoroutine(firingCoroutine);
        }
    }

    private IEnumerator FireContinouosly()
    {
        //Hvis vi holder den er den true;
        while (true)
        {
            GameObject laser = Instantiate(
            laserPrefab,
            transform.position,
            Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, projectileSpeed);
            yield return new WaitForSeconds(projectileFiringPeriod);
        }           
    }

    private void Move()
    {        
        var deltaXY = direction * Time.deltaTime * moveSpeed;   
        var newXPos = Mathf.Clamp(transform.position.x + deltaXY.x, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaXY.y, yMin, yMax);
        transform.position = new Vector2(newXPos, newYPos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        if (collision.tag == "EnemyProjectile")
        {
            ProcessHit(collision, damageDealer);
        }
    }

    private void ProcessHit(Collider2D collision, DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.hit();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
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

    private void SetupMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
        Debug.Log(xMin + xMax);
    }
}
