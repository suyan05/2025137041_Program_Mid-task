using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2 : MonoBehaviour
{
    public GameManager GM;
    public PlayerControl PC;

    private int HP;

    private Rigidbody2D rb;
    private Animator EAni;
    private SpriteRenderer ERenderer;


    private void Awake()
    {
        HP = GM.EHP_2;

        rb = GetComponent<Rigidbody2D>();
        EAni = GetComponent<Animator>();
        ERenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        FollowPlayer();
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void FollowPlayer()
    {
        Vector2 direction = GM.player.position - transform.position;

        if (direction.magnitude > GM.traceDistance) return;

        Vector2 directionNormalized = direction.normalized;

        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, directionNormalized, GM.raycastDistance);
        Debug.DrawRay(transform.position, directionNormalized * GM.raycastDistance, Color.red);

        foreach (RaycastHit2D rHit in hits)
        {
            if(rHit.collider!=null&&rHit.collider.CompareTag("Ground"))
            {
                Vector3 alternativeDirection = Quaternion.Euler(0f, 0f, -90f) * direction;
                transform.Translate(alternativeDirection * GM.ESpeed_2 * Time.deltaTime);
            }
            else
            {
                transform.Translate(direction * GM.ESpeed_2 * Time.deltaTime);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Attack")
        {
            if (!PC.isUpGradeDamege) { HP -= GM.PDamege; Debug.Log(GM.PDamege); }
            else { HP -= GM.PDamege * 2; Debug.Log(GM.PDamege * 2); }
            ERenderer.color = new Color(1, 1, 1, 0.4f);
            Invoke("ColorEnd", 0.1f);
        }
    }

    private void ColorEnd()
    {
        ERenderer.color = new Color(1, 1, 1, 1);
    }
}
