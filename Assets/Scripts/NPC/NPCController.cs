using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [Tooltip("请选定两个作为移动端点的位置，以形成长方形路径。否则，可能导致不可预测的行为结果。")]
    [Header("移动目标点")]
    public List<Transform> TargetPoint;

    public List<Transform> worldPoints;
    [Header("格子大小")]
    public int GridSize=1;
    [Header("移动延迟时长")]
    public float DelayTime = 0.3f;
    [Header("移动速度")] 
    public float Speed = 3f;
    
    private int TargetIndex = 0;
    private Vector3 direction;
    public Vector3 targetPos;
    private Rigidbody2D rb;

    private List<Transform> ConvertToLocalToWorld(List<Transform> localPoints)
    {
        List<Transform> worldPoints = new List<Transform>();

        foreach (Transform localPoint in localPoints)
        {
            Vector3 worldPos = localPoint.TransformPoint(Vector3.zero); // 将本地坐标 (0, 0, 0) 转换为世界坐标
            GameObject newPoint = new GameObject(localPoint.name); // 创建新的 GameObject
            //newPoint.transform.position = worldPos; // 设置新 GameObject 的位置
            newPoint.transform.position = new Vector3(
                Mathf.Round(worldPos.x), // 四舍五入到整数
                Mathf.Round(worldPos.y), // 四舍五入到整数
                worldPos.z // 保持原始的世界坐标的 z 值
            );
            worldPoints.Add(newPoint.transform); // 将新 GameObject 的 Transform 添加到新的列表中
        }

        return worldPoints;
    }

    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();

        worldPoints =ConvertToLocalToWorld(TargetPoint);
        TargetPoint = worldPoints;
        if (TargetPoint.Count != 0)
        {
            direction = (TargetPoint[TargetIndex].position - transform.position).normalized;
        }
        else {
            Debug.LogWarning("检测到有敌人没有设置巡逻点");
        }
            
 
    }

    private void Update()
    {
        if (TargetPoint.Count == 0)
        {
            return;
        }
        ChangeTargetPoint();
        MoveCharacter();
        targetPos = transform.position + direction * GridSize;
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

     private void OnCollisionEnter2D(Collision2D other)
     {
         if (other.gameObject.CompareTag("Player"))
         {
             BornPlaceSetter.Instance.PlayerBornAgain();
             ScoreManager.MinusMoney(10);
         }
     }
}
