using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeedLine : MonoBehaviour
{

    public float amountSpeedInk;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D( Collider2D other){
    if (other.gameObject.tag == "Player") 
        {
            GameObject.FindObjectOfType<draw>().AddRedInk(amountSpeedInk);
            Destroy(gameObject);
        }
    }
}
