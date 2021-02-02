using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 100;
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFiringPeriod = 0.5f;
    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationOfExplosion = 1f;


    [Header("Sound/VFX")]
    [Range(0f, 1f)] [SerializeField] float soundVolume = 1f;
    [Range(0f, 1f)] [SerializeField] float laserVolume = 1f;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip fireLaserSound;

    [SerializeField] int pointPerKill = 100;

    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        audio.volume = laserVolume;
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
        }
    }

    private void Fire()
    {
        audio.PlayOneShot(fireLaserSound);
        GameObject laser = Instantiate(
            laserPrefab,
            transform.position,
            Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -projectileSpeed);
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        if (collision.tag == "Projectile")
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
            Die();
        }
    }

    private void Die()
    {       
        if (FindObjectOfType<LaserDefenderGameSession>())
        {
            FindObjectOfType<LaserDefenderGameSession>().AddToScore(pointPerKill);
        }
        else
        {
            Debug.Log("Kunne ikke finde GameSession");            
        }
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, soundVolume);
        GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(explosion, durationOfExplosion);
    }


}
