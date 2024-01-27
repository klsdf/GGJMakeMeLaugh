using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BornPlaceSetter : MonoBehaviour
{
    [Header("默认出生点")] 
    public Transform DefaultBornPlace;
    [Header("安全屋出生点")] 
    public List<BornPlaceInfo> SafeHomePlaces;

    public static BornPlaceSetter Instance;
    private GameObject player;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        //默认位置是玩家开始游戏时的位置
        player = GameObject.FindGameObjectWithTag("Player");
        DefaultBornPlace = player.transform;
    }

    public void ChangeBornPosition(string bornPlaceKey)
    {
        //PlayerController.Instance.curBornPlaceTrans = SafeHomePlaces;
    }

    public void PlayerBornAgain()
    {
        PlayerController.Instance.PlayerBorn();
    }
}
