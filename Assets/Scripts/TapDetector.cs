using System;
using UnityEngine;

public class TapDetector : MonoBehaviour {

    private Vector2 fingerDownPosition;
    private Rigidbody ballRb;

    void Start() 
    {
        ballRb = transform.GetComponent<Rigidbody>();
    }

    void Update() 
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerDownPosition = touch.position;
            }

            if(touch.phase == TouchPhase.Ended)
            {
                if(Mathf.Abs(Vector2.Distance(touch.position, fingerDownPosition)) < 1.0f){
                    ballRb.AddForce(Vector3.up * 500.0f);
                }
            }
        }
    }
}