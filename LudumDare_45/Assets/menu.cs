using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void play(){
        SceneManager.LoadScene("game");
    }
    [ContextMenu("reset")]
    public void reset(){
        PlayerPrefs.SetFloat("highScore",0);
    }
}
