using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float BallSpeed = 3f;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(0, -BallSpeed * Time.deltaTime, 0);

        Invoke("DestroyObj", 6.0f);
    }

    private void DestroyObj()
    {
        Destroy(gameObject);
        Debug.Log("ªË¡¶");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyObj();
    }
}
