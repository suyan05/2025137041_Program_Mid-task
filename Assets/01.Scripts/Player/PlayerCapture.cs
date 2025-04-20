using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerCapture : MonoBehaviour
{
    [SerializeField] private float _chaseDelay = 3;
    private SpriteRenderer _spriteRenderer;
    [FormerlySerializedAs("playerChaser")][FormerlySerializedAs("_chasePlayer")][SerializeField] PlayerTracker playerTracker;

    private Queue<TrackingData> _trackingDataBuffer;

    TrackingData _trackingData;

    private void Awake()
    {
        _trackingDataBuffer = new Queue<TrackingData>();
        _spriteRenderer = transform.parent.Find("Player").GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        CaptureData();
        _chaseDelay -= Time.deltaTime;
        if (_chaseDelay > 0) return;
        ApplyTrackingData(_trackingData);
    }

    private void CaptureData()
    {
        _trackingData.posData = transform.position;
        _trackingData.spriteData = _spriteRenderer.sprite;
        _trackingData.rotData = transform.eulerAngles;
        _trackingDataBuffer.Enqueue(_trackingData);
    }

    private void ApplyTrackingData(TrackingData trackingData)
    {

        playerTracker.SetPosAndSprite(_trackingDataBuffer.Peek());
        _trackingDataBuffer.Dequeue();
    }
}