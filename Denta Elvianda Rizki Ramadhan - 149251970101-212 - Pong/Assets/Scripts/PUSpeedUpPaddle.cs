using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpeedUpPaddle : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D ball;
    private bool isRight;
    //public GameObject paddleKanan;
    //public GameObject paddleKiri;
    public float spawnDuration, effectDuration, multiplier;
    private float timer, effectTimer;
    public bool effectisActive = false;
    public BallController ballController;
    public PaddleController paddleController;

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
            GameObject.Find(ballController.lastcollision).GetComponent<PaddleController>().ActivatePUSpeedUpPaddle(multiplier);
            effectisActive = true;
            /*if (isRight)
            {
                paddleKanan.GetComponent<PaddleController>().ActivatePUSpeedUpPaddle(multiplier);//Extend Right Paddle
            }
            else
            {
                paddleKiri.GetComponent<PaddleController>().ActivatePUSpeedUpPaddle(multiplier);//Extend Left Paddle
            }
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            ballisActive = true;

            Debug.Log("Kena Effect");*/
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
        if (effectisActive == true)
        {

            if (effectTimer >= effectDuration)
            {
                effectTimer -= effectDuration;
                DeactiveEffect();
            }
        }
        Debug.Log("Kena Effect Paddle" + effectisActive);
    }

    private void DeactiveEffect()
    {
        GameObject.Find(ballController.lastcollision).GetComponent<PaddleController>().DeactivatePUSpeedUpPaddle(multiplier);
        
        effectTimer = 0;
        effectisActive = false;

    }
}
