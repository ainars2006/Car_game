using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeScript : MonoBehaviour
{
    public void ToLevel1Scene()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    public void ToLevel2Scene()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    public void ToMainMenue()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void Quit()
    {
        Application.Quit();
    }
    
}