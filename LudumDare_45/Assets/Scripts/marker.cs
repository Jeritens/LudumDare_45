using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class marker : MonoBehaviour
{
    public TextMeshPro text;
    public LineRenderer lr;
    public Color pencil;
    Color normal;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        normal = lr.startColor;
    }

    public void SetPos(int pos, bool ink){
        //transform.position = Vector2.right*pos;
        text.text = pos.ToString();
        if(!ink){
            text.color= pencil;
            lr.startColor= pencil;
            lr.endColor= pencil;
        }
        else{
            text.color= normal;
            lr.startColor= normal;
            lr.endColor= normal;
        }
    }
    public int GetPos(){
        return (int)transform.position.x;
    }
}
