using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreLine : MonoBehaviour
{
    public GameObject markerPrefab;
    public Transform cam;
    public Transform line;
    public Transform markerParent;
    public List<marker> markers = new List<marker>();
    public LineRenderer pencil;
    public Transform HSMarker;
    public TextMeshPro HSText;
    float hs;
    // Start is called before the first frame update
    void Start()
    {
        hs = PlayerStats.stats.GetMaxInk();
        HSMarker.position= Vector2.right*hs;
        HSText.text= hs.ToString("0.0");
        pencil.SetPosition(1,Vector2.right*hs);
        for(int i = 0; i<8; i++){
            GameObject g = GameObject.Instantiate(markerPrefab,Vector3.right*i*5,Quaternion.identity,markerParent);
            marker m = g.GetComponent<marker>();
            m.SetPos(i*5,i*5>hs);
            markers.Add(m);
        }
        
    }
    void rewritemarkers(int pos){
        for(int i = 0; i<markers.Count; i++){
            markers[i].SetPos(pos+i*5,pos+i*5>hs);
        }
    }
    
    // void forwards(){

    //     marker m = markers.First.Value;
    //     markers.RemoveFirst();
    //     m.SetPos(markers.Last.Value.GetPos()+5);
    //     markers.AddLast(m);
    //     // lowest++;
    // }
    // void backwards(){
    //     marker m = markers.Last.Value;
    //     markers.RemoveLast();
    //     m.SetPos(markers.First.Value.GetPos()-5);
    //     markers.AddFirst(m);
    // }

    // Update is called once per frame
    void Update()
    {
        line.position = Vector2.right* Mathf.Max((cam.position.x-20),hs);
        if(Mathf.Abs(cam.position.x-(markerParent.position.x+10))>5){
            int pos = Mathf.Max(Mathf.FloorToInt((cam.position.x-10f)/5f)*5,0);
            markerParent.position = Vector2.right*pos;
            rewritemarkers(pos);
        }
        // bool outOfRange = true;
        // while(outOfRange){
        //     if(cam.position.x-markers.First.Value.GetPos()>10){
        //         forwards();
        //     }
        //     else if(cam.position.x-markers.First.Value.GetPos()<5 && markers.First.Value.GetPos()>0){
        //         backwards();
        //     }
        //     else{
        //         outOfRange = false;
        //     }
        // }
    }
}
