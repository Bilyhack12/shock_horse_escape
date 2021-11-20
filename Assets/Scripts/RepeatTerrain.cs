using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatTerrain : MonoBehaviour
{
    public GameObject backLocator;
    private GameObject player;
    public Terrain[] terrainPieces;
    public float terrainHeight = 100.0f;
    private int actualTerrainIndex = 0;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        backLocator = GameObject.FindGameObjectWithTag("BackLocator");
    }

    void Update()
    {
        for(int i = 0; i < terrainPieces.Length; i++){
            if(backLocator.transform.position.z > (terrainPieces[i].transform.position + new Vector3(0, 0, terrainHeight)).z){
                Vector3 nextPosition = terrainPieces[actualTerrainIndex].transform.position + new Vector3(0, 0, terrainHeight);
                int nextTerrainIndex = 1-actualTerrainIndex;
                SpawnTerrain(terrainPieces[nextTerrainIndex], nextPosition);
                actualTerrainIndex = nextTerrainIndex;
            }
        }
    }

    void SpawnTerrain(Terrain terrain, Vector3 position){
        terrain.transform.position = position;
    }
}
