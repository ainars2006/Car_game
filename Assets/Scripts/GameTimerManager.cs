using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Atbild par spēles taimeri un laika limitu
public class GameTimerManager : MonoBehaviour
{
    public float timeLimit = 300f; // Spēles laika limits sekundēs
    private float timer; // Pašreizējais laiks
    private bool gameEnded = false; // Vai spēle ir beigusies

    public ObjectScript objectScript; // Atsauce uz citu skriptu ar UI elementiem
    public GameObject failPanel; // Panelis, kas parādās, ja laiks beidzas

    void Update()
    {
        if (gameEnded) return; // Ja spēle jau beigusies, neko nedarīt

        timer += Time.deltaTime; // Palielina taimeri

        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);

        // Atjauno taimeri UI tekstā
        if (objectScript != null && objectScript.timerText != null)
        {
            objectScript.timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            Debug.LogWarning("GameTimerManager: objectScript or timerText is not assigned!");
        }

        // Ja beidzas laiks beidz spēli
        if (timer >= timeLimit)
        {
            EndGame();
        }
    }

    // Funkcija, kas izsaucas, kad spēle beigusies
    void EndGame()
    {
        gameEnded = true;
        if (failPanel != null)
        {
            failPanel.SetActive(true); // Parāda zadējuma paneli
        }
    }
}
