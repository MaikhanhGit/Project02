using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitManager : MonoBehaviour
{   
    void Update()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {               
                if (SceneManager.GetActiveScene().buildIndex == 0)
                    Application.Quit();
                else
                    SceneManager.LoadScene(0);
            }
        }
        
    }
}