using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public ThirdPersonCamera camera;
    private Rigidbody ballRb;
    private Vector3 ballDirection;

    private void Awake()
    {
        SwipeDetector.OnSwipe += SwipeDetectorOnSwipe;
        ballRb = transform.GetComponent<Rigidbody>();
        ballDirection = transform.forward;
    }

    private void SwipeDetectorOnSwipe(SwipeData data)
    {
        switch (data.Direction.ToString()){
            case "Up":
                ballRb.AddForce(ballDirection * 400.0f);
                break;
            case "Down":
                break;
            case "Left":
                ballDirection = Quaternion.Euler(0, -90, 0) * ballDirection;
                ballRb.AddForce(ballDirection * 50.0f);
                camera.ChangeAngle(-90);
                break;
            case "Right":
                ballDirection = Quaternion.Euler(0, 90, 0) * ballDirection;
                ballRb.AddForce(ballDirection * 50.0f);
                camera.ChangeAngle(90);
                break;
        }
    }

    public Vector3 getBallDirection () {
        return this.ballDirection;
    }
}
