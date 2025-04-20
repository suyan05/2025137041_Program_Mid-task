using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    private readonly float _showDelay = 0.14f;

    private SpriteRenderer _spriteRenderer;
    private SpriteRenderer _ghostSpriteRenderer;
    private GameObject _ghost;
    [SerializeField] private float _currentTime;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _ghost = transform.Find("Ghost").gameObject;
        _ghostSpriteRenderer = _ghost.GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _currentTime = _showDelay;
    }

    private void FixedUpdate()
    {
        ApplyAfterImage();
    }

    // 따라오는 적들에게 위치값과 회전값과 strite 를 적용시켜줄 함수
    public void SetPosAndSprite(TrackingData trackingData)
    {
        transform.position = trackingData.posData;
        transform.rotation = Quaternion.Euler(trackingData.rotData);
        _spriteRenderer.sprite = trackingData.spriteData;
    }

    //간단한 잔상을 보여줄 함수
    private void ApplyAfterImage()
    {
        _currentTime -= Time.deltaTime;
        if (_currentTime <= 0)
        {
            GameObject currentGhost = Instantiate(_ghost, transform.position,
            transform.rotation);
            _ghost.SetActive(true);
            _ghostSpriteRenderer.sprite = _spriteRenderer.sprite;
            Destroy(currentGhost, 0.18f);
            _currentTime = _showDelay;
        }
    }
}