using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_3 : MonoBehaviour
{
    public GameManager GM;

    public GameObject Ball;

    private Rigidbody2D rb;
    private Animator EAni;

    private float R;

    private bool isAttack = true;
    private bool FoundPlayer = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        EAni = GetComponent<Animator>();
        GM.Timer = 4.5f;
    }
    
    private void Update()
    {
        Found();
        if (FoundPlayer) { FollowPlayer(); }
        else { EnemyMove(); }
    }

    private void Found()
    {
        FoundPlayer = true;
    }

    private void EnemyMove()
    {

    }

    private void FollowPlayer()
    {
        Attack();
    }

    private void Attack()
    {
        Transform spawnTransform = transform;

        if (isAttack)
        {
            
            Instantiate(Ball, spawnTransform.position, spawnTransform.rotation);
            isAttack = false;
        }
        else { Timer(); }
    }

    private void Timer()
    {
        if(GM.Timer>0)
        {
            GM.Timer -= Time.deltaTime;
            if(GM.Timer<=0)
            {
                R = Random.Range(2.5f, 6f);
                Debug.Log(R);
                GM.Timer = R;
                isAttack = true;
            }
        }
    }
}
