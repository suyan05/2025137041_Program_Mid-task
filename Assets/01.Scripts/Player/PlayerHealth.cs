using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public GameManager GM;

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
        if(collision.gameObject.tag == "Pitfall")
        {
            GameOver();
        }
    }

    //GameOver
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


    //무적,데미지 계산
    private void OnDamege(Vector2 targetPos)
    {
        GM.PHP -= GM.EPower;
        Debug.Log($"체력이:{GM.PHP} 남았습니다.");

        gameObject.layer = 8;

        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;

        rb.AddForce(new Vector2(dirc, 4) * 1, ForceMode2D.Impulse);

        PlyerRenderer.color = new Color(1, 1, 1, 0.4f);

        Invoke("OffDamaged", 1.5f);
    }

    private void OffDamaged()
    {
        gameObject.layer = 3;

        PlyerRenderer.color = new Color(1, 1, 1, 1);
    }
}
