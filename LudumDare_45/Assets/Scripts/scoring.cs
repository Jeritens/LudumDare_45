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
    public float deathTime=1f;
    public GameObject deathAnim;
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
        if(!active)
            return;
        active = false;
        
        if(PlayerPrefs.GetFloat("highScore")<score){
            PlayerPrefs.SetFloat("highScore",score);
            highScoreText.text = score.ToString("0.0");
            
        }
        GameObject.Instantiate(deathAnim,pS.GetPlayer().transform.position,Quaternion.identity);
        pS.GetPlayer().GetComponent<SpriteRenderer>().enabled= false;
        Rigidbody2D p = pS.GetPlayer().GetComponent<Rigidbody2D>();
        p.velocity = Vector2.zero;
        p.isKinematic = true;
        StartCoroutine(deathTimer());
        
    }
    IEnumerator deathTimer(){
        yield return new WaitForSeconds(deathTime);
        SceneManager.LoadScene("game");
    }
    public void changeHS(float value){
        float HS = PlayerPrefs.GetFloat("highScore")+value;
        PlayerPrefs.SetFloat("highScore",HS);
        pS.SetMaxInk(HS);
        

    }
}
