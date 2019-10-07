using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeSprite : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] sprites;
    public menu menu;
    void Start()
    {
        if(PlayerPrefs.HasKey("ball0")){
            for(int i = 0; i<menu.ballCount;i++){
                if(PlayerPrefs.GetInt("ball"+i.ToString())==2){
                    GetComponent<SpriteRenderer>().sprite = sprites[i];
                }
            }
        }
    }
}
