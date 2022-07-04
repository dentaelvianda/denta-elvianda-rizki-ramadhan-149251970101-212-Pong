using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpeedUpPaddle : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D ball;
    public float spawnDuration, effectDuration, multiplier;
    private float timer, effectTimer;
    private bool leftActive, RightActive;
    public BallController lastCollision;
    public PaddleController paddleKanan, paddleKiri;

    private void Start()
    {
        timer = 0;
        effectTimer = 0;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Collision Detection
        if (collision == ball)
        {
            if (lastCollision.isRight == true)
            {
                paddleKanan.GetComponent<PaddleController>().ActivatePUSpeedUpPaddle(multiplier);
                RightActive = true;
            }
            else if (lastCollision.isRight == false)
            {
                paddleKiri.GetComponent<PaddleController>().ActivatePUSpeedUpPaddle(multiplier);
                leftActive = true;
            }
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
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
        if (leftActive == true)
        {
            if (effectTimer >= effectDuration)
            {
                effectTimer -= effectDuration;
                DeactiveEffectLeft();
            }
        }

        if (RightActive == true)
        {
            if (effectTimer >= effectDuration)
            {
                effectTimer -= effectDuration;
                DeactiveEffectRight();
            }
        }

        Debug.Log("Kena Effect Paddle left" + leftActive);
        Debug.Log("Kena Effect Paddle right" + RightActive);
    }

    private void DeactiveEffectLeft()
    {

        paddleKiri.GetComponent<PaddleController>().DeactivatePUSpeedUpPaddle(multiplier);
        effectTimer = 0;
        leftActive = false;

    }
    private void DeactiveEffectRight()
    {

        paddleKanan.GetComponent<PaddleController>().DeactivatePUSpeedUpPaddle(multiplier);
        effectTimer = 0;
        RightActive = false;

    }
}
