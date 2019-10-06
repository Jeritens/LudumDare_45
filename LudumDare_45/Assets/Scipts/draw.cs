using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class draw : MonoBehaviour
{
    public GameObject linePrefab;
    public GameObject speedLinePrefab;
    LineRenderer currentLineR;
    EdgeCollider2D currentLineCol;
    public PlayerStats stats;
    BallBehaviour ball;
    


    // Update is called once per frame
    void Update()
    {        
        if(Input.GetButtonDown("Fire1")&&stats.GetInk()>0&&!TestUI()){
            StartLine();
        }
        if(Input.GetButton("Fire1")&&stats.GetInk()>0){
            if(currentLineR!= null){
                DrawLine();
            }
        }
        else if(currentLineR != null){
            StopLine();
        }
        
    }

    public void AddRedInk(float amountInk){
        stats.AddRedInk(amountInk);
        if(currentLineR != null){
            StopLine();
            StartLine();
        }
    }


    private void StartLine(){
        if(stats.GetRedInk()>0){
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
                stats.AddInk(-distance);
                if(stats.GetRedInk() > 0){
                    stats.AddRedInk(-distance);
                    if(stats.GetRedInk()<=0){
                        StopLine();
                        StartLine();
                        stats.SetRedInk(0);
                    }
                }
            }
    }
    private void StopLine(){
        currentLineR.GetComponent<desolve>().startTimer();
        currentLineR = null;
        currentLineCol = null;
        stats.GetPlayer().GetComponent<BallBehaviour>().startGame();
    }
    bool TestUI(){
        return EventSystem.current.IsPointerOverGameObject();
    }
}
