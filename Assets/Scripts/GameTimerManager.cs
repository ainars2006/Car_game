using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimerManager : MonoBehaviour
{
    public float timeLimit = 300f;
    private float timer;
    private bool gameEnded = false;

    public Text timerText;
    public GameObject failPanel;

    void Update()
    {
        if (gameEnded) return;
        timer += Time.deltaTime;
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (timer >= timeLimit)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameEnded = true;
        failPanel.SetActive(true);
    }
}
