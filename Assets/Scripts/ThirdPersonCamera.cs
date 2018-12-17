using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class ThirdPersonCamera : MonoBehaviour {
  
    public float turnSpeed = 4.0f;
    public Transform player;

    private Vector3 offset;
    private float speed = 1.0f;

    private float startTime;
    private float journeyLength;
  

    void Start () {
      offset = new Vector3(player.position.x, player.position.y + 8.0f, player.position.z - 7.0f);
    }

    void LateUpdate()
    {
        // offset = Quaternion.AngleAxis(directionAngle, Vector3.up) * offset;
        // transform.position = player.position + offset;
     // float distCovered = (Time.time - startTime) * speed;
      //float fracJourney = distCovered / journeyLength;

     // transform.position = Vector3.Lerp(transform.position, player.position + offset);
      transform.position = player.position + offset;
      transform.LookAt(player.position);
    }

    public void ChangeAngle(float angle) {
      offset = Quaternion.AngleAxis(angle, Vector3.up) * offset;
    }
  }