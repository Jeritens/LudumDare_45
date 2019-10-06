using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public GameObject ball;
    [SerializeField]
    private Vector3 offset = new Vector3(3,0,-10);
    [SerializeField]
    private float maxDistance = 7;

    // Start is called before the first frame update
    void Start()
    {
    }

    void LateUpdate()
    {   
        Vector3  destination = new Vector3(ball.transform.position.x,Mathf.Max(4,ball.transform.position.y),0)+offset;
        //camera damping
        float distance = Mathf.Min((destination-transform.position).magnitude,maxDistance); 
        float x = distance/maxDistance;
        float speed = Mathf.Pow(x,7)*60;
        transform.position = Vector3.Lerp(transform.position, destination, speed* Time.deltaTime);

    }
}
