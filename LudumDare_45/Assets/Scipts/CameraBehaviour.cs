using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    Transform ball;
    [SerializeField]
    private Vector3 offset = new Vector3(3,0,-10);
    [SerializeField]
    private float maxSpeed = 5;
    [SerializeField]
    private float maxDistance = 7;

    void LateUpdate()
    {   
        ball = PlayerStats.stats.GetPlayer().transform;
        Vector3  destination = new Vector3(ball.position.x,Mathf.Max(4,ball.position.y),0)+offset;
        //camera damping
        float distance = Mathf.Min((destination-transform.position).magnitude,maxDistance);
        float speed = distance/maxDistance*maxSpeed;
        transform.position = Vector3.Lerp(transform.position, destination, speed* Time.deltaTime);

    }
}
