using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tramp : MonoBehaviour
{
    public Transform ancor2;
    public float length;
    public LineRenderer lineRenderer;
    public EdgeCollider2D edge;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 point = Random.insideUnitCircle.normalized*length;
        ancor2.localPosition= point;
        lineRenderer.SetPosition(1,point);
        Vector2[] points = new Vector2[]{Vector2.zero,point};
        edge.points= points;
    }
}
