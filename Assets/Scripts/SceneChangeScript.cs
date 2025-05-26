using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Skripts kas atbild par ainu maiņu spēlē
public class SceneChangeScript : MonoBehaviour
{
    // Pārslēdz uz 1. līmeni
    public void ToLevel1Scene()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    // Pārslēdz uz 2. līmeni
    public void ToLevel2Scene()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    // Atgriežas uz galveno Menu
    public void ToMainMenue()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    // Aizver spēli
    public void Quit()
    {
        Application.Quit();
    }
}
