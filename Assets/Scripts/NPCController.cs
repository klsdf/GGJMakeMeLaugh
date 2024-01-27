using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public List<Transform> TargetPoint;
    public int GridSize;
    public float DelayTime = 0.3f;
    private int TargetIndex = 0;
    private Vector3 direction;
    private Vector3 targetPos;

    private void Update()
    {
        ChangeTargetPoint();
        MoveCharacter();
    }

    private void ChangeTargetPoint()
    {
        if (Vector3.Distance(transform.position,TargetPoint[TargetIndex].position)<0.1f)
        {
            ChangeDirection(TargetPoint[TargetIndex+1]);
            TargetIndex += 1;
        }
    }
    
    private void ChangeDirection(Transform point)
    {
        Vector3 newPos = point.position;
        direction = (transform.position - newPos).normalized;
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
         transform.position = targetPos;
     }
}
