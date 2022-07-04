using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector2 speed;
    public Vector2 resetPosition;
    private Rigidbody2D rig;
    public bool isRight;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = speed;
        //isRight = false;
    }

    public void Update()
    {
        Debug.Log("Speed Bola:" + rig.velocity);
        Debug.Log("Last Collision" + isRight);
    }

    public void ResetBall()
    {
        transform.position = new Vector3(resetPosition.x, resetPosition.y, 2);
        rig.velocity = speed;
    }

    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.collider.tag == "paddleKiri")
        {
            
            isRight = false;
            
        }
        else if(collisionInfo.collider.tag == "paddleKanan")
        {
            
            isRight = true;
        }
    }
    public void ActivatePUSpeedUp(float magnitude)
    {
        rig.velocity *= magnitude;

    }

    public void DeactivatePUSpeedUp(float magnitude)
    {
        rig.velocity /= magnitude;
    }
}
