using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    SpriteRenderer sR;
    // Start is called before the first frame update
    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Vector2 parentPos = transform.position-transform.localPosition;
        transform.localPosition= new Vector3(-parentPos.x%transform.localScale.x,-parentPos.y%transform.localScale.y,10);
    }
}
