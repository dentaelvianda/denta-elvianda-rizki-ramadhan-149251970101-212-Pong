using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUExtendPaddle : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D ball;
    private bool isRight;
    public GameObject paddleKanan;
    public GameObject paddleKiri;
    public float spawnDuration, effectDuration,multiplier;
    private float timer, effectTimer;
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
            if (isRight)
            {
                paddleKanan.GetComponent<PaddleController>().ActivatePUExtendPaddle(multiplier);//Extend Right Paddle
            }
            else
            {
                paddleKiri.GetComponent<PaddleController>().ActivatePUExtendPaddle(multiplier);//Extend Left Paddle
            }
            
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
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
        if (ballisActive == true)
        {

            if (effectTimer >= effectDuration)
            {
                effectTimer -= effectDuration;
                DeactiveEffect();
            }
        }
        Debug.Log("Kena Effect Paddle 2" + ballisActive);
    }

    private void DeactiveEffect()
    {
        paddleKanan.GetComponent<PaddleController>().DeactivatePUExtendPaddle(multiplier);
        paddleKiri.GetComponent<PaddleController>().DeactivatePUExtendPaddle(multiplier);
        effectTimer = 0;
        ballisActive = false;

    }
}
