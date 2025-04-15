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

    public int PAttackPower = 3;
    public int PHP = 10;

    public Transform GroundCh;
    public LayerMask GroundLay;

    [Header("Enemy_1")]
    public float ESpeed_1 = 3f;
    public int EHP_1 = 3;

    public int EPower = 1;

    [Header("Ÿ��")]
    public Component DistoryTile;

    private void Awake()
    {
        DistoryTile.GetComponent<TilemapRenderer>().enabled = false;
    }
}
