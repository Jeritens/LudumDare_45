using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class marker : MonoBehaviour
{
    public TextMeshPro text;
    public LineRenderer lr;
    public Color pencil;

    public void SetPos(int pos, bool ink){
        //transform.position = Vector2.right*pos;
        text.text = pos.ToString();
        if(!ink){
            text.color= pencil;
            lr.startColor= pencil;
            lr.endColor= pencil;
        }
    }
    public int GetPos(){
        return (int)transform.position.x;
    }
}
