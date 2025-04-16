using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2 : MonoBehaviour
{
    public GameManager GM;

    private Rigidbody2D rb;
    private Animator EAni;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        EAni = GetComponent<Animator>();
    }

    private void Update()
    {
        FollowPlayer();
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
}
