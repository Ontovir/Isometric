using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScore : MonoBehaviour
{
    // Скрипт, который сохраняет результат боя
    // Используется для переноса информации о полученных очках в следующую сцену
    int score;
    StatisticsScript scoreStats;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        scoreStats = FindObjectOfType<StatisticsScript>(); 
    }

    // Update is called once per frame
    void Update()
    {
        score = scoreStats.GetScore(); 
    }
    public int GetScore()
    {
        return score;
    }
}
