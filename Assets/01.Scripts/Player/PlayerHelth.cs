using System.Collections;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHelth : MonoBehaviour
{
    public GameManager GM;

    private bool isDamege = true;

    private SpriteRenderer PlyerRenderer;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        PlyerRenderer = GetComponent<SpriteRenderer>();

        GM.PHP = 15;
        GM.Timer = 1f;
    }

    private void Update()
    {
        PlayerDath();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Enemy")
        {
            OnDamege(collision.transform.position);
        }
    }

    private void PlayerDath()
    {
        if (GM.PHP <= 0) { GameOver(); }
    }

    public void GameOver()
    {
        gameObject.SetActive(false);
        Invoke("RestartGame", 3.0f);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnDamege(Vector2 targetPos)
    {
        GM.PHP -= GM.EPower;
        Debug.Log($"체력이:{GM.PHP} 남았습니다.");

        gameObject.layer = 8;

        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;

        rb.AddForce(new Vector2(dirc, 1) * 1, ForceMode2D.Impulse);

        PlyerRenderer.color = new Color(1, 1, 1, 0.4f);

        Invoke("OffDamaged", 2f);
    }

    void OffDamaged()
    {
        gameObject.layer = 3;

        PlyerRenderer.color = new Color(1, 1, 1, 1);
    }
}
