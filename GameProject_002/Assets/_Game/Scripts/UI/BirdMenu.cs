using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMenu : MonoBehaviour
{
    public List<GameObject> arrows = new List<GameObject>();
    public GameObject currentArrow;
    public GameObject settingGo;

    private void OnEnable()
    {
        currentArrow = arrows[PlayerPrefs.GetInt("Bird", 0)];
        currentArrow.SetActive(true);
    }

    public void ChooseBird(int birdIndex)
    {
        currentArrow.SetActive(false);
        currentArrow = arrows[birdIndex];
        PlayerPrefs.SetInt("Bird", birdIndex);
        currentArrow.SetActive(true);
    }

    public void Confirm()
    {
        GameManager.instance.ChangeBird();
        GameManager.instance.isGamePause = false;
        settingGo.SetActive(false);
    }
}
