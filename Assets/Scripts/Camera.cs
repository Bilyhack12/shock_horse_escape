using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Transform player;
    public Vector3 offset;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        Vector3 newPos = player.position + offset;
        newPos.y = transform.position.y;
        transform.position = newPos;

    }
}
