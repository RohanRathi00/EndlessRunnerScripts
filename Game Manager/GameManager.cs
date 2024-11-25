using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public UI_Main uiMain;
    public Player player;
    [Header("Platform Header Color Info")]
    public Color platformHeaderColor;
    public Color playerColor = Color.white;

    [Header("Score info")]
    public int coins;
    public float distance;
    public float score;

    private void Awake()
    {
        instance = this;
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (player.transform.position.x > distance)
        {
            distance = player.transform.position.x;
        }
    }

    public void SaveColor(float r, float g, float b)
    {
        PlayerPrefs.SetFloat("ColorR", r);
        PlayerPrefs.SetFloat("ColorG", g);
        PlayerPrefs.SetFloat("ColorB", b);
    }

    private void LoadColor()
    {
        SpriteRenderer sr = player.GetComponent<SpriteRenderer>();

        Color newColor = new Color(PlayerPrefs.GetFloat("ColorR"),
                                   PlayerPrefs.GetFloat("ColorG"),
                                   PlayerPrefs.GetFloat("ColorB"),
                                   PlayerPrefs.GetFloat("ColorA", 1));

        sr.color = newColor;
    }

    public void UnlockPlayer() => player.playerUnlocked = true;

    public void SaveInfo()
    {
        int savedCoins = PlayerPrefs.GetInt("Coins");

        PlayerPrefs.SetInt("Coins", savedCoins + coins);

        score = distance * coins;

        PlayerPrefs.SetFloat("LastScore", score);

        if (PlayerPrefs.GetFloat("HighScore") < score)
        {
            PlayerPrefs.SetFloat("HighScore", score);
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void GameEnded()
    {
        SaveInfo();
        uiMain.OpenEndGameUI();
    }
}
