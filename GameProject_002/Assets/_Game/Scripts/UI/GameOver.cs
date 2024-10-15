using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text bestText;

    public GameObject silverMedal;
    public GameObject goldMedal;

    private void OnEnable()
    {
        scoreText.text = GameManager.instance.score.ToString();
        bestText.text = PlayerPrefs.GetInt("BestScore", 0).ToString();

        if (GameManager.instance.score >= 3) goldMedal.SetActive(true);
        else if (GameManager.instance.score >= 1) silverMedal.SetActive(true);

    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }
}
