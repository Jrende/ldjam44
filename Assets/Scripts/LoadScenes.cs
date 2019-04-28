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
}
