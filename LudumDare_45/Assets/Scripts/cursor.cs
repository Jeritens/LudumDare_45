using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursor : MonoBehaviour
{
    void Start()
    {
        Cursor.visible= false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector2 cursorPos= Input.mousePosition;
        transform.position = cursorPos;

    }
}
