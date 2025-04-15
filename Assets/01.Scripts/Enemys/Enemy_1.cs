using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1 : MonoBehaviour
{
    public GameManager GM;

    private Rigidbody2D rb;
    private Animator EAni;

    private bool isMovingRight = true;
    private bool Move = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        EAni = GetComponent<Animator>();

        GM.Timer = 5f;
    }

    private void Update()
    {
        EMove();
    }

    private void EMove()
    {
        if(Move)
        {
            EAni.SetBool("isMove", true);
            if (isMovingRight) 
            {
                rb.velocity = new Vector2(GM.ESpeed_1, rb.velocity.y);
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            else
            {
                rb.velocity = new Vector2(-GM.ESpeed_1, rb.velocity.y);
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
        else
        {
            EAni.SetBool("isMove", false);
        }

        if(GM.Timer>0)
        {
            GM.Timer -= Time.deltaTime;
            if(GM.Timer<=0)
            {
                if (Move == true) { GM.Timer = 3f; Debug.Log("3�ʷ� �ٲ�"); }
                else { GM.Timer = 5f; Debug.Log("5�ʷ� �ٲ�"); }
                Move = !Move;
                Debug.Log("Ÿ�̸� �ʱ�ȭ");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Boundary"))
        {
            isMovingRight = !isMovingRight;
        }
    }
}
