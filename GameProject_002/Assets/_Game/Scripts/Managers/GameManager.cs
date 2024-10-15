using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GameManager : Singleton<GameManager>
{
    public bool isLost;
    public int score = 0;
    public TMP_Text scoreText;

    public bool isGameStart = false;
    public bool isGamePause = false;

    [Header("UI")]
    public GameObject scoreHolder;
    public GameObject getReady;
    public GameObject gameOver;
    public GameObject settingGo;

    [Header("Bird")]
    public Bird currentBird;

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    public void ChangeBird()
    {
        currentBird.ChangeBirds();
    }

    public void OpenSetting()
    {
        isGamePause = true;
        settingGo.SetActive(true);
    }

    public void StartGame()
    {
        isGameStart = true;
        scoreHolder.SetActive(true);
        getReady.SetActive(false);

        // StartCoroutine(IEWaitGoUp());
        currentBird.GoUp();
    }

    //IEnumerator IEWaitGoUp()
    //{
    //    yield return new WaitForSeconds(0.1f);
    //    currentBird.GoUp();
    //}

    public void Lose()
    {
        isLost = true;

        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
        if (score > bestScore) PlayerPrefs.SetInt("BestScore", score);

        gameOver.SetActive(true);
    }

    public void Score()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
