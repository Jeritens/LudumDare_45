using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{

    Rigidbody2D rb;
    public scoring scoring;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGameOver();
    }

    public void AddSpeed(float speed)
    {
        rb.AddForce(rb.velocity.normalized*speed);
    }
    public void SetDirection(Vector2 direction){
        
        rb.velocity = direction.normalized*rb.velocity.magnitude;
    }

    private void isGameOver(){
        if(transform.position.y < 0){
            scoring.Death();
        }
    }

}
