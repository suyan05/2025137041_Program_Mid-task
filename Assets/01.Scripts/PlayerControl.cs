using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float PSpeed = 3f;
    public float PJumpPower = 3f;
    public float PAttackPower = 3f;
    public float PHP = 10f;

    private bool isJump = true;
    private bool isDoubleJump = false;
    private bool isGround = true;

    public Transform GroundCh;
    public LayerMask GroundLay;

    private Rigidbody2D rb;
    private Animator PAni;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        PAni = GetComponent<Animator>();
    }

    private void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        float MoveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(MoveInput * PSpeed, rb.velocity.y);

        isJump = Physics2D.OverlapCircle(GroundCh.position, 0.2f, GroundLay);

        if (MoveInput > 0) 
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            PAni.SetBool("Player_Move", true);
        }
        else if (MoveInput < 0) 
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            PAni.SetBool("Player_Move", true);
        }
        else { PAni.SetBool("Player_Move", false); }

        if (isJump && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            isDoubleJump = true;
        }
        else if (isDoubleJump && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            isDoubleJump = false;
        }
        else if (isGround == true) { PAni.SetBool("Player_Jump", false); }
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * PJumpPower, ForceMode2D.Impulse);
        PAni.SetBool("Player_Jump", true);
        isGround = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
            Debug.Log("점프 가능");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

        }
    }

}
