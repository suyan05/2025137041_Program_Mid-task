using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float PSpeed = 3f;
    public float PJumpPower = 3f;
    public float PAttackPower = 3f;
    public float PHP = 10f;

    public Transform GroundCh;
    public LayerMask GroundLay;

    private Rigidbody2D rb;
    private bool isGround = true;
    private bool isDoubleJump = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        float MoveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(MoveInput * PSpeed, rb.velocity.y);

        isGround = Physics2D.OverlapCircle(GroundCh.position, 0.2f, GroundLay);

        if(isGround&&Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            isDoubleJump = true;
        }
        else if(isDoubleJump && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            isDoubleJump = false;
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * PJumpPower, ForceMode2D.Impulse);
    }
}
