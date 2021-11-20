using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObstacleType{
    none = -1,
    rock1 = 0
}
public class Obstacle : MonoBehaviour
{
    public GameObject backLocator;
    public ObstacleType type;
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        backLocator = GameObject.FindGameObjectWithTag("BackLocator");
    }

    // Update is called once per frame
    void Update()
    {
        if(backLocator.transform.position.z > transform.position.z){
            gameObject.SetActive(false);
            ObstacleSpawner.Instance.SpawnRandomObstacle();
        }
    }
}
