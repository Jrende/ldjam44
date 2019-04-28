using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour
{
    public GameObject panel0;
    public GameObject panel1;
    public GameObject panel2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showNextPanel()
    {
        if (panel0.activeInHierarchy)
        {
            panel0.SetActive(false);
            panel1.SetActive(true);
        }
        else if (panel1.activeInHierarchy)
        {
            panel1.SetActive(false);
            panel2.SetActive(true);
        }
        else if (panel2.activeInHierarchy)
        {
            SceneManager.LoadScene("Level1");
        }
        
    }
}
