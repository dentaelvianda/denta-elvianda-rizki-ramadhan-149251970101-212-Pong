using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public int speed;
    public KeyCode upKey;
    public KeyCode downKey;
    private Rigidbody2D rig;
    public bool isRight;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveObject(GetInput());
    }
    private Vector2 GetInput()
    {
        Vector2 movement = Vector2.zero;
        if (Input.GetKey(upKey))
        {
            //gerakan ke atas
            return Vector2.up * speed;
        }
        else if (Input.GetKey(downKey))
        {
            //gerakan ke bawah
            return Vector2.down * speed;
        }
        return Vector2.zero;
    }
    private void MoveObject(Vector2 movement)
    {
        Debug.Log("Test" + movement);
        rig.velocity= movement;
    }

    
    public void ActivatePUExtendPaddle(float multiplier)
    {
        transform.localScale += new Vector3(transform.localScale.x*1f,transform.localScale.y*multiplier,2);
        //Extend the Paddle
    }
    public void DeactivatePUExtendPaddle(float multiplier)
    {
        transform.localScale -= new Vector3(transform.localScale.x * 1f, transform.localScale.y * multiplier, 2);//De-Extend the Paddle
    }
    public void ActivatePUSpeedUpPaddle(float multiplier)
    {
        rig.velocity *= multiplier;//Activate Speed
    }
    public void DeactivatePUSpeedUpPaddle(float multiplier)
    {
        rig.velocity /= multiplier;//De-Activate Speed
    }
}
