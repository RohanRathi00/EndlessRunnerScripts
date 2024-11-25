using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_EndGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI distance;
    [SerializeField] private TextMeshProUGUI coins;
    [SerializeField] private TextMeshProUGUI score;

    void Start()
    {
        GameManager gameManager = GameManager.instance;

        Time.timeScale = 0;

        distance.text = "Distance : " + gameManager.distance.ToString("#,#");
        coins.text = "Coins : " + gameManager.coins.ToString("#,#");
        score.text = "Score : " + gameManager.score.ToString("#,#");
    }
}
