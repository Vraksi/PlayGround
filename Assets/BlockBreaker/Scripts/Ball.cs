using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //Config parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 10f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;

    //state
    private Vector2 paddleToBallVector;
    private bool hasStarted = false;

    //Audio
    AudioSource myAudioSource;
    Rigidbody2D rb2d;

    private void Awake()
    {
        //Tager fat i Control scheme igennem Paddle.cs 
        //men man kan (umiddelbart) også bare lave bruge new controls for at og så er der stadig kun en.
        //paddle1.controls.Mouse.MouseDown.performed += ctx => LaunchOnMouseClick();
    }
    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        // Vi får differencen mellem de 2 punkter.
        paddleToBallVector = transform.position - paddle1.transform.position;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
        }

    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    public void LaunchOnMouseClick()
    {
        if (!hasStarted)
        {
            rb2d.velocity = new Vector2(xPush, yPush);
            hasStarted = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));
        if(hasStarted)
        {
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            rb2d.velocity += velocityTweak;
        }
        
    }
}
