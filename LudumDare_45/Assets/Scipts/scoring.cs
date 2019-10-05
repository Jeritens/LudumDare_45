using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class scoring : MonoBehaviour
{
    public Transform player;
    float score;
    float highScore;
    bool active= true;
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("highScore")){
            highScoreText.text = PlayerPrefs.GetFloat("highScore").ToString("0.0");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(active){
            score = player.position.x;
            distanceText.text = score.ToString("0.0");
        }
        
    }
    public void Death(){
        active = false;
        if(PlayerPrefs.GetFloat("highScore")<score){
            PlayerPrefs.SetFloat("highScore",score);
            highScoreText.text = score.ToString("0.0");
        }
        SceneManager.LoadScene("game");
    }
}
