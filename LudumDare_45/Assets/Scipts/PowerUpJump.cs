using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpJump : MonoBehaviour
{

    public float strengh;
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
            other.GetComponent<BallBehaviour>().AddForce(transform.up.normalized*strengh);

            Destroy(gameObject);
        }
    }
}
