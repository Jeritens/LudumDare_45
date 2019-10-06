using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeed : MonoBehaviour
{

    public float speedPower;

    // Update is called once per frame
    void Update()
    {
        if(PlayerStats.stats.GetPlayer().transform.position.x>transform.position.x+20){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D( Collider2D other){
        if (other.gameObject.tag == "Player") 
         {
             other.GetComponent<BallBehaviour>().AddSpeed(speedPower);
             Destroy(gameObject);
         }
    }
}
