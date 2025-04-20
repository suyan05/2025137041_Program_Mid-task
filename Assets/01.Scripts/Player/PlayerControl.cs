using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public GameManager GM;
    public GameObject Ball_1;
    public GameObject Ball_2;
    public Transform firePoint;

    private bool isJump = true;
    private bool isDoubleJump = false;
    public bool isUpGradeDamege = false;

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
        isGround();
        PlayerAttack();
    }

    private void PlayerAttack()
    {
        Transform spawnTransform = transform;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(!isUpGradeDamege)
            {
                GameObject ball = Instantiate(Ball_1, firePoint.position, firePoint.rotation);
            }
            else
            {
                GameObject ball = Instantiate(Ball_2, firePoint.position, firePoint.rotation);
            }
        }
    }

    private void PlayerMove()
    {
        float MoveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(MoveInput * GM.PSpeed, rb.velocity.y);

        isJump = Physics2D.OverlapCircle(GM.GroundCh.position, 0.2f, GM.GroundLay);

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
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * GM.PJumpPower, ForceMode2D.Impulse);
        PAni.SetBool("Player_Jump_Up", true);
    }

    private void isGround()
    {
        if (rb.velocity.y < 0)
        {
            PAni.SetBool("Player_Jump_Down", true);
            PAni.SetBool("Player_Jump_Up", false);

            Debug.DrawRay(rb.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(rb.position, Vector3.down, 1, LayerMask.GetMask("Ground"));
            if (rayHit.collider != null)
            {
                if (rayHit.distance < 0.6f)
                {
                    Debug.Log(rayHit.collider.name);
                    PAni.SetBool("Player_Jump_Down", false);
                }
            }
        }
    }
}

/*using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab; // ÃÑ¾Ë ÇÁ¸®ÆÕ
    public Transform firePoint; // ÃÑ¾ËÀÌ ¹ß»çµÇ´Â À§Ä¡
    public float bulletSpeed = 10f; // ÃÑ¾Ë ¼Óµµ

    void Update()
    {
        // ½ºÆäÀÌ½º¹Ù¸¦ ´­·¶À» ¶§ ÃÑ¾Ë ¹ß»ç
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // ÃÑ¾Ë »ý¼º
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // ÃÑ¾Ë¿¡ ¼Óµµ Ãß°¡
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = firePoint.right * bulletSpeed;
        }
    }
}*/