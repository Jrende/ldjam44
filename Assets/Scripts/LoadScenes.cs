using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    public string sceneToLoad;
    public void Load()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
    public void Load(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LoadNextLevel()
    {
        string name = SceneManager.GetActiveScene().name;

        if (name == "IntroScene")
        {
            Load("Level1");
        }
        else if (name == "Level1")
        {
            Load("Level2");
        }
        else if (name == "Level2")
        {
            Load("Level3");
        }
        else if (name == "Level3")
        {
            Load("Level4");
        }
        else if (name == "Level4")
        {
            Load("EndScene");
        }
    }
}
