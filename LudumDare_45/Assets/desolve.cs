using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class desolve : MonoBehaviour
{
    public float timeSpan=0;
    LineRenderer l;
    EdgeCollider2D ed;
    public float desolveTime = 1;
    public Color col;


    public void startTimer(){
        l= GetComponent<LineRenderer>();
        ed = GetComponent<EdgeCollider2D>();
        StartCoroutine(timer());

    }
    
    void Desolve(){
        float lineLength = 0;
        for(int i = 0; i<l.positionCount-1;i++){
            lineLength+=Vector2.Distance(l.GetPosition(i),l.GetPosition(i+1));
        }
        //float desolveTime = lineLength/desolveSpeed;
        
        StartCoroutine(DesolveAnim(desolveTime, lineLength));
    }
    
    IEnumerator DesolveAnim(float desolveTime, float lineLength){
        float t= 0;
        bool calculated= false;
        float nextLength= 0;
        float deletedPath = 0;
        while(t<desolveTime){
            t+= Time.deltaTime;
            // l.colorGradient.alphaKeys[0].time = t/desolveTime+0.1f;
            // l.colorGradient.alphaKeys[1].time = t/desolveTime;
            
            // l.colorGradient.alphaKeys[1].alpha = Mathf.Clamp01(t/(desolveTime/10))*255;
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[] { new GradientColorKey(col, 0.0f), new GradientColorKey(col, 1.0f) },
                new GradientAlphaKey[] { new GradientAlphaKey(0, t/desolveTime-0.5f/lineLength), new GradientAlphaKey(1, t/desolveTime) }

            );
            l.colorGradient = gradient;
            float length = t/desolveTime * lineLength+0.5f/lineLength;
            if(!calculated){
                nextLength = Vector2.Distance(ed.points[0],ed.points[1]);
            }
            if(length>nextLength+deletedPath){
                deletedPath = nextLength+deletedPath;
                nextLength = 0;
                calculated = false;
                Vector2[] points = ed.points;
                RemoveAt(ref points,0);
                ed.points = points;
            }
            yield return null;
        }
        Destroy(gameObject);
    }
    IEnumerator timer(){
        yield return new WaitForSeconds(timeSpan);
        Desolve();
    }
     public static void RemoveAt<T>(ref T[] arr, int index)
    {
        for (int a = index; a < arr.Length - 1; a++)
        {
            // moving elements downwards, to fill the gap at [index]
            arr[a] = arr[a + 1];
        }
        // finally, let's decrement Array's size by one
        Array.Resize(ref arr, arr.Length - 1);
    }
}
