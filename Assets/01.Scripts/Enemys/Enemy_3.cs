using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_3 : MonoBehaviour
{
    public GameManager GM;
    public PlayerControl PC;

    public GameObject Ball;

    private int HP;

    private Rigidbody2D rb;
    private Animator EAni;
    private SpriteRenderer ERenderer;


    private float R;

    private bool isAttack = true;

    private Vector3 offset;

    private void Awake()
    {
        HP = GM.EHP_3;

        offset = new Vector3(0, GM.FollowHeight, -GM.FollwDistancw);
        rb = GetComponent<Rigidbody2D>();
        EAni = GetComponent<Animator>();
        ERenderer = GetComponent<SpriteRenderer>();

        GM.Timer = 4.5f;
    }
    
    private void Update()
    {
        Found();
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Found()
    {
        if(GM.player != null)
        {
            Vector3 targetPosition = GM.player.position + offset;

            transform.position = Vector3.Lerp(transform.position, targetPosition, GM.ESpeed_3 * Time.deltaTime);

            Attack();
        }
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Attack")
        {
            if (!PC.isUpGradeDamege) { HP -= GM.PDamege; }
            else { HP -= GM.PDamege * 2; }
            ERenderer.color = new Color(1, 1, 1, 0.4f);
            Invoke("ColorEnd", 0.1f);
        }
    }

    private void ColorEnd()
    {
        ERenderer.color = new Color(1, 1, 1, 1);
    }
}
