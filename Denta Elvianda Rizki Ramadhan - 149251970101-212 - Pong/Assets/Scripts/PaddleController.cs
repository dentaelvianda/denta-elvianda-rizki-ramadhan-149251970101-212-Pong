using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed;
    public KeyCode upKey;
    public KeyCode downKey;
    private Rigidbody2D rig;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveObject(GetInput());
        Debug.Log("Kecepatan :" + rig.velocity);
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
        Vector3 newscale = transform.localScale;
        newscale.y *= multiplier;
        transform.localScale = newscale;
        //Extend the Paddle
    }
    public void DeactivatePUExtendPaddle(float multiplier)
    {
        Vector3 newscale = transform.localScale;
        newscale.y /= multiplier;
        transform.localScale = newscale;
        //De-Extend the Paddle
    }
    public void ActivatePUSpeedUpPaddle(float multiplier)
    {
        speed *= multiplier;//Activate Speed
    }
    public void DeactivatePUSpeedUpPaddle(float multiplier)
    {
        speed /= multiplier;//De-Activate Speed
    }
}
