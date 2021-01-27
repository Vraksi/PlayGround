using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //Config params (Variabler vi ændrer på manuelt)
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    //[SerializeField] int maxHits;
    [SerializeField] Sprite[] hitSprites;

    //cached Reference (Variabler for ting vi gerne vil have fat i vores script)
    Level level;
    GameStatus gameStatus;

    //state variables (Variabler der angiver den status objektet har)
    [SerializeField] int timesHit; // only serialized for debugging.

    private void Start()
    {        
        CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if(hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError(gameObject.name + "sprite is missing from array");
        }
        
    }

    private void DestroyBlock()
    {
        PlayBlockDestroySFX();
        Destroy(gameObject);
        level.BlockDestroyed();
        TriggerSparklesVFX();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();

        if (tag == "Breakable")
        {
            level.CountBreakableBlocks();
        }
    }

    private void PlayBlockDestroySFX()
    {
        FindObjectOfType<GameStatus>().AddToScore();
        //playclipatpoint laver en audio source i 3d rum og skal sættes på cameraet fordi ellers bliver lyden lavere.
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX()
    {
        //Vi er nød til lægge den i en variable for kunne slette den.
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 2f);
    }
}
