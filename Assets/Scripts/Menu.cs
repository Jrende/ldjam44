﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void restartScene()
    {
        SceneManager.LoadScene("JoesScem");
        //Debug.Log("Restart");
    }

    public void quit()
    {
        Application.Quit();
        //Debug.Log("quit");
    }
}