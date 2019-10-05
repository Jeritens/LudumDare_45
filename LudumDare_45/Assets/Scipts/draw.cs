using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class draw : MonoBehaviour
{
    public float ink;
    public float currentInk;
    public GameObject linePrefab;
    LineRenderer currentLineR;
    EdgeCollider2D currentLineCol;

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetButtonDown("Fire1")&&currentInk>0){
                GameObject line = GameObject.Instantiate(linePrefab,Vector3.zero,Quaternion.identity);
                currentLineR = line.GetComponent<LineRenderer>();
                currentLineCol = line.GetComponent<EdgeCollider2D>();
        }
        if(Input.GetButton("Fire1")&&currentInk>0){
            
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentLineR.positionCount++;
            currentLineR.SetPosition(currentLineR.positionCount-1,mousePos);
            Vector2[] points= new Vector2[currentLineR.positionCount];
            for(int i= 0; i<currentLineR.positionCount;i++){
                points[i]=(Vector2)currentLineR.GetPosition(i);
            }
            currentLineCol.points = points;
            if(currentLineR.positionCount>1)
                currentInk-=Vector2.Distance(currentLineR.GetPosition(currentLineR.positionCount-1),currentLineR.GetPosition(currentLineR.positionCount-2));
        }
        
    }
}
