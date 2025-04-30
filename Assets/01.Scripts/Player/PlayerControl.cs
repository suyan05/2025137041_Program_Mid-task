using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public GameManager GM;
    public GameObject Ball_1;
    public GameObject Ball_2;
    public Transform firePoint;

    public Text currentScore;

    private bool isJump = true;
    private bool isDoubleJump = false;
    public bool isUpGradeDamege = false;
    private bool transferI = false;
    private bool JUmpI = false;

    private Rigidbody2D rb;
    private Animator PAni;
    private SpriteRenderer PlyerRenderer;

    float score;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        PAni = GetComponent<Animator>();
        PlyerRenderer = GetComponent<SpriteRenderer>();

        score = 1000f;
    }

    private void Update()
    {
        PlayerMove();
        isGround();
        PlayerAttack();
        CurrentScore();
    }

    public void CurrentScore()
    {
        score -= Time.deltaTime;

        currentScore.text = "Score: " + score.ToString();
    }

    private void PlayerAttack()
    {
        Transform spawnTransform = transform;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(!UIManager.ESC)
            {
                Debug.Log("isUI True");
                if (!isUpGradeDamege)
                {
                    GameObject ball = Instantiate(Ball_1, firePoint.position, firePoint.rotation);
                }
                else
                {
                    GameObject ball = Instantiate(Ball_2, firePoint.position, firePoint.rotation);
                }
            }
            else
            {
                Debug.Log("isUI false");
            }
        }
    }

    private void PlayerMove()
    {
        float MoveInput = Input.GetAxisRaw("Horizontal");
        if(!transferI)
        {
            rb.velocity = new Vector2(MoveInput * GM.PSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(MoveInput * GM.PSpeed*2, rb.velocity.y);
        }

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
        if (!JUmpI)
        {
            rb.AddForce(Vector2.up * GM.PJumpPower, ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(Vector2.up * GM.PJumpPower * 1.5f, ForceMode2D.Impulse);
        }
        
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Invincibility")
        {
            InvincibilityItem();
        }

        if (collision.gameObject.tag == "Transfer")
        {
            TransferItem();
        }

        if (collision.gameObject.tag == "Attack")
        {
            DamegeItem();
        }
        
        if (collision.gameObject.tag == "Jump")
        {
            JumpItem();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Goal"))
        {
            DataSave.TrySet(SceneManager.GetActiveScene().buildIndex, (int)score);
            collision.GetComponent<LevelObj>().MoveToNext();
        }    
    }

    //무적
    private void InvincibilityItem()
    {
        gameObject.layer = 8;
        PlyerRenderer.color = new Color(1, 1, 1, 0.4f);

        Invoke("OffDamaged", 5f);
    }

    private void OffDamaged()
    {
        gameObject.layer = 3;

        PlyerRenderer.color = new Color(1, 1, 1, 1);
    }

    //이속 증가
    private void TransferItem()
    {
        transferI = true;
        Invoke("TransferItemOff", 5f);
    }

    private void TransferItemOff()
    {
        transferI = false;
    }

    //데미지 업
    private void DamegeItem()
    {
        isUpGradeDamege = true;
        Invoke("DamegeItemOff", 5f);
    }

    private void DamegeItemOff()
    {
        isUpGradeDamege = false;
    }

    //점프 업
    private void JumpItem()
    {
        JUmpI = true;
        Invoke("JumpItemOff", 5.5f);
    }

    private void JumpItemOff()
    {
        JUmpI = false;
    }


}