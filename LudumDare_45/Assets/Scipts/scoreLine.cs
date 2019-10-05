using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreLine : MonoBehaviour
{
    public GameObject markerPrefab;
    public Transform cam;
    public Transform line;
    public LinkedList<marker> markers = new LinkedList<marker>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i<8; i++){
            GameObject g = GameObject.Instantiate(markerPrefab,Vector3.zero,Quaternion.identity);
            marker m = g.GetComponent<marker>();
            m.SetPos(i*5);
            markers.AddLast(m);
        }
    }
    
    void forwards(){

        marker m = markers.First.Value;
        markers.RemoveFirst();
        m.SetPos(markers.Last.Value.GetPos()+5);
        markers.AddLast(m);
        // lowest++;
    }
    void backwards(){
        marker m = markers.Last.Value;
        markers.RemoveLast();
        m.SetPos(markers.First.Value.GetPos()-5);
        markers.AddFirst(m);
    }

    // Update is called once per frame
    void Update()
    {
        line.position = Vector2.right* Mathf.Max((cam.position.x-10),0);
        bool outOfRange = true;
        while(outOfRange){
            if(cam.position.x-markers.First.Value.GetPos()>10){
                forwards();
            }
            else if(cam.position.x-markers.First.Value.GetPos()<5 && markers.First.Value.GetPos()>0){
                backwards();
            }
            else{
                outOfRange = false;
            }
        }
    }
}
