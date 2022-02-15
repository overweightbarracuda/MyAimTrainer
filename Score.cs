using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text ScoreText;
    
    int score;
    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = score.ToString();
    }
    void ScoreIncrease(){
        score += 1;
    }
    // Update is called once per frame
    void OnEnable()
    {
        Enemy.OnEnemyKilled += ScoreIncrease;
        Debug.Log(score);
    }
}
