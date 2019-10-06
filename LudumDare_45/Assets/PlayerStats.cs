using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    float ink;
    float maxInk;
    float redInk;
    public display inkDisplay;
    Vector2 startPosition;
    float initVel;
    GameObject player;
    public static PlayerStats stats;
    void Awake()
    {
        stats = this;
        player= GameObject.FindGameObjectWithTag("Player");
    }
    void Start(){
        if(PlayerPrefs.HasKey("highScore")){
            maxInk = PlayerPrefs.GetFloat("highScore")+0.1f;
        }
        else{
            maxInk = 0.1f;
        }
        ink = maxInk;

        inkDisplay.change(ink,maxInk);
        
    }
    public float GetInk(){
        return ink;
    }
    public void SetInk(float value){
        ink = value;
        inkDisplay.change(GetInk(),GetMaxInk());
    }
    public void AddInk(float amount){
        ink += amount;
        inkDisplay.change(GetInk(),GetMaxInk());
    }
    public float GetMaxInk(){
        return maxInk;
    }
    public void SetMaxInk(float value){
        maxInk = value;
    }
    public float GetRedInk(){
        return redInk;
    }
    public void AddRedInk(float amount){
        redInk += amount;
    }
    public void SetRedInk(float value){
        redInk = value;
    }
    public Vector2 GetStartPosition(){
        return startPosition;
    }
    public void SetStartPosition(Vector2 position){
        startPosition = position;
        GameObject.FindGameObjectWithTag("Player").transform.position = position;
    }
    public float GetInitVel(){
        return initVel;
    }
    public void SetInitVel(float speed){
        initVel = speed;
    }
    public GameObject GetPlayer(){
        return player;
    }
    public void SetPlayer(GameObject p){
        player = p;
    } 
}
