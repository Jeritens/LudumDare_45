using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class escape : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Exit")){
            SceneManager.LoadScene("Menu");
        }
    }
}
