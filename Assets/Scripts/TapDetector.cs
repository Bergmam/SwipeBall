using System;
using UnityEngine;

public class TapDetector : MonoBehaviour {

    private Vector2 fingerDownPosition;
    private Rigidbody ballRb;
    private float distanceToTheGround;

    private bool countingTime = false;
    private float timer = 0.0f;

    void Start() 
    {
        ballRb = transform.GetComponent<Rigidbody>();
        distanceToTheGround = GetComponent<Collider>().bounds.extents.y;
    }

    void Update() 
    {
        if (countingTime)
        {
            timer += Time.deltaTime;
        }

        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerDownPosition = touch.position;
                countingTime = true;
            }

            if(touch.phase == TouchPhase.Ended)
            {
                countingTime = false;
                if(Mathf.Abs(Vector2.Distance(touch.position, fingerDownPosition)) < 1.0f && IsGrounded() && timer <= 0.5f){
                    ballRb.AddForce(Vector3.up * 500.0f);
                }

                timer = 0.0f;
            }

            if(touch.phase == TouchPhase.Stationary && timer > 0.25f)
            {
                ballRb.velocity = new Vector3(0, ballRb.velocity.y, 0);
            }
        }
    }

    bool IsGrounded() {
        return Physics.Raycast(transform.position, Vector3.down, distanceToTheGround + 0.1f);
    }
}