using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour
{
    public Color moon;
    public Color marbel;
    public Color boing;
    public SpriteRenderer sR;
    // Start is called before the first frame update
    void Start()
    {
        Color col;
        switch (PlayerStats.stats.GetBall())
        {
            case 0:
                col = marbel;
                break;
            case 1:
                col = boing;
                break;
            case 2:
                col = moon;
                break;
            default:
                col = Color.black;
                break;
        }
        sR.color = col;
    }
}
