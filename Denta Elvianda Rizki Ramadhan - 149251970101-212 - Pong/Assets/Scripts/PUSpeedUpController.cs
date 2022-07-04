using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpeedUpController : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D ball;
    public float magnitude, spawnDuration,effectDuration;
    private float timer,effectTimer;
    public bool ballisActive = false;

    private void Start()
    {
        timer = 0;
        effectTimer = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Collision Detection
        if (collision == ball)
        {
            ball.GetComponent<BallController>().ActivatePUSpeedUp(magnitude);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            ballisActive = true;
            
            Debug.Log("Kena Effect");
        }
    }

    private void Update()
    {
        //Start Timer
        timer += Time.deltaTime;
        
        //Timer for Spawn
        // Note : Nilai Spawn Duration == Spawn Interval
        if (timer >= spawnDuration)
        {
            manager.RemovePowerUp(gameObject);
            timer -= spawnDuration;
        }
        //Timer for Effect
        effectTimer += Time.deltaTime;
        if (ballisActive== true)
        {
            
            if (effectTimer >= effectDuration)
            {
                effectTimer -= effectDuration;
                DeactiveEffect();
            }
        }
        Debug.Log("Kena Effect" + ballisActive);
    }

    private void DeactiveEffect()
    {
        ball.GetComponent<BallController>().DeactivatePUSpeedUp(magnitude);
        effectTimer = 0;
        ballisActive = false;
      
    }
}
