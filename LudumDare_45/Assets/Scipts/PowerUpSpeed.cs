using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeed : MonoBehaviour
{

    public float speedPower;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.x>transform.position.x+20){
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
