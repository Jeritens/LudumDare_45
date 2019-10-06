using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class scoring : MonoBehaviour
{
    float score;
    float highScore;
    bool active= true;
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI highScoreText;
    PlayerStats pS;
    // Start is called before the first frame update
    void Awake()
    {
        pS = GetComponent<PlayerStats>();
        if(PlayerPrefs.HasKey("highScore")){
            highScoreText.text = PlayerPrefs.GetFloat("highScore").ToString("0.0");
            pS.SetMaxInk(PlayerPrefs.GetFloat("highScore"));
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        if(active){
            score = pS.GetPlayer().transform.position.x;
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
    public void changeHS(float value){
        float HS = PlayerPrefs.GetFloat("highScore")+value;
        PlayerPrefs.SetFloat("highScore",HS);
        pS.SetMaxInk(HS);
        pS.SetInk(HS);
        

    }
}
