using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacles : MonoBehaviour
{
    public ItemSpawner itemSpawner;
    public int maxObstaclesPerChunk;
    public float probability;
    public List<GameObject> obstacleList;

    public void spawnObstacles(){
        for(int i = 0; i < maxObstaclesPerChunk; i++){
            if(Random.Range(0.0f,1.0f)<probability){
                GameObject.Instantiate(obstacleList[randomObstacleIndex()],itemSpawner.randomLocation(), Quaternion.identity);
            }
        }
        
    
    }
    private int randomObstacleIndex(){
        return Random.Range(0,obstacleList.Count);
    }
}
