using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class marker : MonoBehaviour
{
    public TextMeshPro text;

    public void SetPos(int pos){
        transform.position = Vector2.right*pos;
        text.text = pos.ToString();
    }
    public int GetPos(){
        return (int)transform.position.x;
    }
}
