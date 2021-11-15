using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Transform player;
    private Vector3 offset;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        //Vector3 newPos = transform.position + offset;
        //transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime);
        //transform.LookAt(player);
    }
}
