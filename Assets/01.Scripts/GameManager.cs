using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    [Header("Ÿ�̸�")]
    public float Timer = 4f;
    
    [Header("�÷��̾�")]
    public float PSpeed = 3f;
    public float PJumpPower = 3f;
    public int PDamege = 1;

    public int PHP = 10;

    public Transform GroundCh;
    public LayerMask GroundLay;

    [Header("Enemy")]
    public int EPower = 1;
    public float raycastDistance = 3f;
    public float traceDistance = 2f;

    public Transform player;

    [Header("Enemy_1")]
    public float ESpeed_1 = 3f;
    public int EHP_1 = 6;

    [Header("Enemy_2")]
    public float ESpeed_2 = 3f;
    public int EHP_2 = 4;

    [Header("Enemy_3")]
    public float ESpeed_3 = 3f;
    public int EHP_3 = 3;
    public float FollowHeight = 5f;
    public float FollwDistancw = 3f;

    [Header("Ÿ��")]
    public Component DistoryTile;

    private void Awake()
    {
        DistoryTile.GetComponent<TilemapRenderer>().enabled = false;
    }
}
