using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public GameObject ball;
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private float maxSpeed = 5f;
    [SerializeField]
    private float maxDistance = 7f;

    // Start is called before the first frame update
    void Start()
    {
    }

    void LateUpdate()
    {   
        Vector3  destination = new Vector3(ball.transform.position.x,Mathf.Max(0,ball.transform.position.y),0)+offset;
        //camera damping
        float distance = Mathf.Min((destination-transform.position).magnitude,maxDistance);
        float speed = distance/maxDistance*maxSpeed;
        transform.position = Vector3.Lerp(transform.position, destination, speed* Time.deltaTime);

    }
}
