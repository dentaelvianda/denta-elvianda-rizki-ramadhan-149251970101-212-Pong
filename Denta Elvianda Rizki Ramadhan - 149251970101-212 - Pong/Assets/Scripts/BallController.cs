using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector2 speed;
    public Vector2 resetPosition;
    private Rigidbody2D rig;
    public Collider2D ball;
    public bool isRight;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = speed;

    }
    public void Update()
    {
        Debug.Log("Speed Bola:" + rig.velocity);
    }

    public void ResetBall()
    {
        transform.position = new Vector3(resetPosition.x, resetPosition.y, 2);
        rig.velocity = speed;
    }

    public string lastcollision;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        lastcollision = collision.collider.tag;
        string name = collision.collider.name;
        if (lastcollision == "paddleKanan")
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
