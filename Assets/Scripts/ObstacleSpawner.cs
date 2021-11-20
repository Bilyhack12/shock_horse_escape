using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public static ObstacleSpawner Instance {set; get;}
    public GameObject[] obstaclesPrefabs;
    public GameObject[] spawnedObstacles;
    private float spawnMaxDistance = 60;
    private float spawnMinDistance = 20;
    private float spawnPositionX = 15f;
    private float spawnInterval;
    private float startDelay = 5.0f;
    private Vector3 lastSpawnPosition;    
    private GameObject player;

    GameObject FindInObstacles(GameObject[] obstacles, GameObject gameObject){
        for(int i = 0; i<obstacles.Length; i++){
            if(obstacles[i].GetComponent<Obstacle>().type == gameObject.GetComponent<Obstacle>().type && !obstacles[i].activeSelf){
                return obstacles[i];
            }
        }
        return null;
    }

    GameObject[] GetAllChildren(){
        GameObject[] gameObjs = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            gameObjs[i] = transform.GetChild(i).gameObject;
        }
        return gameObjs;
    }

    private void Awake(){
        Instance = this;
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    int GetObstacleTypeCount(GameObject[] obstacles, GameObject gameObject){
        int count = 0;
        for(int i = 0; i<obstacles.Length; i++){
            if(obstacles[i].GetComponent<Obstacle>().type == gameObject.GetComponent<Obstacle>().type){
                count++;
            }
        }
        return count;
    }    

    public void SpawnRandomObstacle(){
        spawnedObstacles = GetAllChildren();
        int obstacleIndex = Random.Range(0, obstaclesPrefabs.Length);
        Vector3 spawnPosition = new Vector3(spawnPositionX, 0, lastSpawnPosition.z + Random.Range(spawnMinDistance, spawnMaxDistance));
        GameObject availableObstacle = FindInObstacles(spawnedObstacles, obstaclesPrefabs[obstacleIndex]);
        if(availableObstacle != null){
            availableObstacle.transform.position = spawnPosition;
            availableObstacle.SetActive(true);
        }
        else if(GetObstacleTypeCount(spawnedObstacles, obstaclesPrefabs[obstacleIndex])<3){
            GameObject obstacle = Instantiate(obstaclesPrefabs[obstacleIndex], spawnPosition, Quaternion.identity);
            obstacle.transform.parent = transform;
        }
        lastSpawnPosition = spawnPosition;
        spawnInterval = Random.Range(0f, 1f);
        Invoke("SpawnRandomObstacle",spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
