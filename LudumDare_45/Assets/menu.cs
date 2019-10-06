using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    [SerializeField]
    int ballCount=1;
    public void play(){
        SceneManager.LoadScene("game");
    }
    [ContextMenu("reset")]
    public void reset(){
        PlayerPrefs.SetFloat("highScore",0);
         PlayerPrefs.SetInt("heightUpgradeCount",0);
         PlayerPrefs.SetInt("initVelUpgradeCount",0);
         for(int i = 0; i<ballCount;i++){
              PlayerPrefs.SetInt("ball"+i.ToString(),0);
         }
         PlayerPrefs.SetInt("ball0",2);
    }
}
