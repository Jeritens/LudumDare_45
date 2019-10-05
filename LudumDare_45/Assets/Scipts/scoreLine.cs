using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreLine : MonoBehaviour
{
    public GameObject markerPrefab;
    public Transform player;
    public List<marker> markers = new List<marker>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i<8; i++){
            GameObject g = GameObject.Instantiate(markerPrefab,Vector3.zero,Quaternion.identity);
            marker m = g.GetComponent<marker>();
            m.SetPos(i*5);
            markers.Add(m);
        }
    }
    int lowest = 0;
    void forwards(){
        marker m = markers[lowest];
        m.SetPos(markers[(int)Mathf.Repeat(lowest-1,markers.Count-1)].GetPos()+5);
        lowest++;
    }
    void backwards(){
        marker m = markers[(int)Mathf.Repeat(lowest-1,markers.Count-1)];
        m.SetPos(markers[lowest].GetPos()-5);
        lowest= (int)Mathf.Repeat(lowest-1,markers.Count-1);
    }

    // Update is called once per frame
    void Update()
    {
        bool zuweit = true;
        while(zuweit){
            if(player.position.x-markers[lowest].GetPos()>10){
                forwards();
            }
            else if(player.position.x-markers[lowest].GetPos()<2){
                backwards();
            }
            else{
                zuweit = false;
            }
        }
    }
}
