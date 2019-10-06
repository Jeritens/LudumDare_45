using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeedLine : MonoBehaviour
{

    public float amountSpeedInk;
    public AudioClip audioClip;

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
            GameObject.FindObjectOfType<draw>().AddRedInk(amountSpeedInk);
            AudioSource.PlayClipAtPoint(audioClip,transform.position);
            Destroy(gameObject);
        }
    }
}
