using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform Player;

    public float CameraOffset = 5f;

    private void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Vector3 targetPos = new Vector3(Player.transform.position.x, Player.transform.position.y + 1.5f, Player.transform.position.z - CameraOffset);
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime);


    }
}
