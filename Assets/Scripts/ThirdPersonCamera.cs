using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class ThirdPersonCamera : MonoBehaviour {
  
    public float turnSpeed = 4.0f;
    public Transform player;

    private Vector3 offset;
    private Vector3 nextOffset;
    private float speed = 1.0f;

    private float journeyLength;

    private bool lerpActive = false;
    private float startTime;
    private float lerpTime = 0.5f;
    private Vector3 lerpTarget;
  

    void Start () {
      //offset = new Vector3(player.position.x, player.position.y + 4.0f, player.position.z - 8.0f);
      offset = new Vector3(0, 4.0f, 8.0f);
    }

    void LateUpdate()
    {
      if (lerpActive)
      {
        float fracComplete = (Time.time - startTime) / lerpTime;
        transform.position = player.position + Vector3.Lerp(offset, nextOffset, fracComplete);

        if (fracComplete >= 1)
        {
          offset = nextOffset;
          lerpActive = false;
        }
      }
      else
      {
          transform.position = player.position + offset;
      }
      
      transform.LookAt(player.position);
    }

    public void ChangeAngle(float angle) {
      if (!lerpActive)
      {
        nextOffset = Quaternion.AngleAxis(angle, Vector3.up) * offset;
        StartLerping();
      }
      else
      {
        nextOffset = Quaternion.AngleAxis(angle, Vector3.up) * nextOffset;
      }
      
    }

    private void StartLerping()
    {
      startTime = Time.time;
      lerpActive = true;
    }
  }