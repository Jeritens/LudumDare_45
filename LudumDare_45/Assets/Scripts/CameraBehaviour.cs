using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    Transform ball;
    Rigidbody2D ballRB;
    [SerializeField]
    private Vector3 offset = new Vector3(3,0,-10);
    [SerializeField]
    private float maxDistance = 7;
    [SerializeField]
    private float speed = 7;
    float ballSpeed;
    void Start()
    {
        ball = PlayerStats.stats.GetPlayer().transform;
        ballRB= ball.GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if(ball == null){
            ball = PlayerStats.stats.GetPlayer().transform;
            ballRB= ball.GetComponent<Rigidbody2D>();
        }
        ballSpeed= ballRB.velocity.magnitude;
    }


    void LateUpdate()
    {   
        if(ball == null){
            ball = PlayerStats.stats.GetPlayer().transform;
            ballRB= ball.GetComponent<Rigidbody2D>();
        }
        
        Vector3  destination = new Vector3(ball.position.x,Mathf.Max(4,ball.position.y),0)+offset;
        //camera damping
        float distance = Mathf.Min(Vector2.Distance(destination,transform.position),maxDistance);
        float x = distance/maxDistance;
        float speed = Mathf.Sqrt(ballSpeed)*this.speed+1;//Mathf.Pow(x,7)*60;
        transform.position = Vector3.Lerp(transform.position, destination, speed* Time.deltaTime);

    }
}
