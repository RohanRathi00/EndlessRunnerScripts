using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UI_Main : MonoBehaviour
{
    private bool gamePaused;

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject endGame;

    [SerializeField] private TextMeshProUGUI lastScoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI coinsText;

    [Header("Volume Sliders")]
    [SerializeField] private UI_VolumeSlider[] slider;

    private void Start()
    {
        for (int i = 0; i < slider.Length; i++)
        {
            slider[i].SetupSlider();
        }

        SwitchMenuTo(mainMenu);

        lastScoreText.text = ("Last Score : ") + PlayerPrefs.GetFloat("LastScore").ToString("#,#");
        highScoreText.text = ("High Score : ") + PlayerPrefs.GetFloat("HighScore").ToString("#,#");
    }

    public void SwitchMenuTo(GameObject uiMenu)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        uiMenu.SetActive(true);

        AudioManager.instance.PlaySFX(4);
        coinsText.text = PlayerPrefs.GetInt("Coins").ToString("#,#");
    }

    public void StartGameButton() => GameManager.instance.UnlockPlayer();

    public void PauseGameButton()
    {
        if (gamePaused)
        {
            Time.timeScale = 1;
            gamePaused = false;
        }
        else
        {
            Time.timeScale = 0;
            gamePaused = true;
        }
    }

    public void RestartGameButton() => GameManager.instance.RestartLevel();

    public void OpenEndGameUI()
    {
        SwitchMenuTo(endGame);
    }
}
