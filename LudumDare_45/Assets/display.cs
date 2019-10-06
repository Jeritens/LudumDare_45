using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class display : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI text;

    public void change(float value, float max){
        text.text = Mathf.Max(value,0).ToString("0.0");
        image.fillAmount = value/max;
    }
}
