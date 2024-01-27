using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.1f;

    private float velocity;
    

    private void FixedUpdate()
    {
        var posX = Mathf.SmoothDamp(transform.position.x, target.position.x, ref velocity, smoothTime);
        var posY = Mathf.SmoothDamp(transform.position.y, target.position.y, ref velocity, smoothTime); 
        transform.position = new Vector3(posX, posY, transform.position.z);
    }
}
