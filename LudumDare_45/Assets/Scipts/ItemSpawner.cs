using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    GameObject player;
    public List<GameObject> powerUpList;
    public float probability;
    public float spawnChunkdistance;
    public int maxItemPerChunk;
    [SerializeField]
    private int chunkCount;
    private float offScreenDistance = 15f;
    private float yVariety = 5f;
    

    // Start is called before the first frame update
    void Start()
    {
        chunkCount=0;
         player= PlayerStats.stats.GetPlayer();
        while( chunkCount * spawnChunkdistance < offScreenDistance){
            SpawnItems();
            chunkCount++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        player= PlayerStats.stats.GetPlayer();
        if(player.transform.position.x >chunkCount *spawnChunkdistance - offScreenDistance){
            SpawnItems();
            chunkCount++;
        }
    }

    private void SpawnItems(){
        for(int i = 0; i < maxItemPerChunk; i++){
            if(Random.Range(0.0f,1.0f)<probability){
                GameObject.Instantiate(powerUpList[randomItemIndex()],randomLocation(), Quaternion.identity);
            }
        }
        
    }

    private int randomItemIndex(){
        return Random.Range(0,powerUpList.Count);
    }

    private Vector2 randomLocation(){
        float x = chunkCount *spawnChunkdistance +  Random.Range(0,spawnChunkdistance);

        float y = 0;
        //80% below player spawn
        // if(Random.Range(0.0f,1.0f)<0.8){
        //     y =  Random.Range(Mathf.Max(0.5f,player.transform.position.y - yVariety),  player.transform.position.y);
        // }
        //20% anywhere in yVariety range
   
        y =  Random.Range(Mathf.Max(0.5f,player.transform.position.y - yVariety),  player.transform.position.y +  yVariety);
   
        return new Vector2(x,y);
    }
}
