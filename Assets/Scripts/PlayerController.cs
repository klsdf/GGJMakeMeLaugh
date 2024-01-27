using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("格子大小")]
    public float gridSize;
    [Header("延迟时间")] 
    public float DelayTime = 0.2f; 
    [Header("移动速度")]
    public float Speed = 0.2f;
    
    private Vector3 targetPos;
    private Vector3 direction = new Vector3(0, -1, 0);

    private void Start()
    {
        targetPos = transform.position + direction*gridSize;
    }
    void Update()
    {
        CheckInputs();
        MoveCharacter(); 
    }

    private void CheckInputs()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        if (verticalInput>0)
        {
            direction = new Vector3(0, 1, 0);
        }
        else if (verticalInput<0)
        {
            direction = new Vector3(0, -1, 0);
        }
        else if (horizontalInput<0)
        {
            direction = new Vector3(-1, 0, 0);
        }
        else if (horizontalInput>0)
        {
            direction = new Vector3(1, 0, 0);
        }
    }
    private void MoveCharacter()
    {
        if (Vector3.Distance(transform.position, targetPos) > 0.01f)
            StartCoroutine(MoveToNextPos(targetPos, DelayTime));
        else
            targetPos = transform.position + direction * gridSize;
    }
    
    IEnumerator MoveToNextPos(Vector3 targetPos,float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, Speed * Time.deltaTime);
    }
}