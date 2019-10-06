using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class draw : MonoBehaviour
{
    public float ink;
    public float redInk;
    public GameObject linePrefab;
    public GameObject speedLinePrefab;
    LineRenderer currentLineR;
    EdgeCollider2D currentLineCol;
    void Start(){
        if(PlayerPrefs.HasKey("highScore")){
            ink = PlayerPrefs.GetFloat("highScore")+0.1f;
        }
        else{
            ink = 0.1f;
        }
        
    }


    // Update is called once per frame
    void Update()
    {        
        if(Input.GetButtonDown("Fire1")&&ink>0){
            StartLine();
        }
        if(Input.GetButton("Fire1")&&ink>0){
            DrawLine();
        }
        else if(currentLineR != null){
            StopLine();
        }
        
    }

    public void AddRedInk(float amountInk){
        redInk += amountInk;
        if(currentLineR != null){
            StopLine();
            StartLine();
        }
    }


    private void StartLine(){
        if(redInk>0){
            GameObject line = GameObject.Instantiate(speedLinePrefab,Vector3.zero,Quaternion.identity);
            currentLineR = line.GetComponent<LineRenderer>();
            currentLineCol = line.GetComponent<EdgeCollider2D>();
        }
        else{
            GameObject line = GameObject.Instantiate(linePrefab,Vector3.zero,Quaternion.identity);
            currentLineR = line.GetComponent<LineRenderer>();
            currentLineCol = line.GetComponent<EdgeCollider2D>();
        }
        DrawLine();
    }

    private void DrawLine(){
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentLineR.positionCount++;
            currentLineR.SetPosition(currentLineR.positionCount-1,mousePos);
            Vector2[] points= new Vector2[currentLineR.positionCount];
            for(int i= 0; i<currentLineR.positionCount;i++){
                points[i]=(Vector2)currentLineR.GetPosition(i);
            }
            currentLineCol.points = points;
            if(currentLineR.positionCount>1){
                float distance = Vector2.Distance(currentLineR.GetPosition(currentLineR.positionCount-1),currentLineR.GetPosition(currentLineR.positionCount-2));
                ink-= distance;
                if(redInk > 0){
                    redInk -= distance;
                    if(redInk<=0){
                        StopLine();
                        StartLine();
                        redInk = 0;
                    }
                }
            }
    }

    private void StopLine(){
        currentLineR.GetComponent<desolve>().startTimer();
        currentLineR = null;
        currentLineCol = null;
    }
}
