using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class 玩家的移动线 : MonoBehaviour
{
   
    private LineRenderer lineRenderer;
    private Rigidbody2D rb;
    private PlayerController playerController;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
    }


    // Update is called once per frame
    void Update()
    {


            Vector3 playerPosition = transform.position;

          
            Vector3 playerDirection = (playerController.targetPos-transform.position).normalized;

            Vector3 lineEndPoint = playerPosition + playerDirection * 2f;

            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, playerPosition);
            lineRenderer.SetPosition(1, lineEndPoint);
        
    }
}
