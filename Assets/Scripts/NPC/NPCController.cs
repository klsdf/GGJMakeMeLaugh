using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [Tooltip("请选定两个作为移动端点的位置，以形成长方形路径。否则，可能导致不可预测的行为结果。")]
    [Header("移动目标点")]
    public List<Transform> TargetPoint;
    [Header("格子大小")]
    public int GridSize;
    [Header("移动延迟时长")]
    public float DelayTime = 0.3f;
    [Header("移动速度")] 
    public float Speed = 3f;
    
    private int TargetIndex = 0;
    private Vector3 direction;
    private Vector3 targetPos;
    public Rigidbody rb; 
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        direction = (TargetPoint[TargetIndex].position - transform.position).normalized;
    }

    private void Update()
    {
        ChangeTargetPoint();
        MoveCharacter();
    }

    private void ChangeTargetPoint()
    {
        if (Vector3.Distance(transform.position,TargetPoint[TargetIndex].position)<0.1f)
        {
            TargetIndex = TargetIndex + 1 < TargetPoint.Count? TargetIndex + 1 : 0;
            ChangeDirection(TargetPoint[TargetIndex]);
        }
    }
    
    private void ChangeDirection(Transform point)
    {
        Vector3 newPos = point.position;
        direction = (newPos - transform.position).normalized;
    }
    
    private void MoveCharacter()
     {
         if (Vector3.Distance(transform.position,targetPos) > 0.1f)
             StartCoroutine(MoveToNextPos(targetPos, DelayTime));
         else
             targetPos = transform.position + direction * GridSize;
     }
    
     IEnumerator MoveToNextPos(Vector3 targetPos,float delayTime)
     {
         yield return new WaitForSeconds(delayTime);
         Vector3 targetPosition = Vector3.MoveTowards(rb.position, targetPos, Speed * Time.deltaTime);
         rb.MovePosition(targetPosition);
     }
}
