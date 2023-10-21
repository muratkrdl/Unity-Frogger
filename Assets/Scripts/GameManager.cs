using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int increaseScoreAmount = 100;
    [SerializeField] GameObject player;

    int score;
    Vector3 playerStartPos;

    void Start() 
    {
        score = 0;
        playerStartPos = player.transform.position;
    }

    void Update() 
    {
        scoreText.text = score.ToString();
    }

    public void IncreaseScore()
    {
        score += increaseScoreAmount;
        player.transform.position = playerStartPos;
    }

}
