using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScore : MonoBehaviour
{
    // Скрипт, который сохраняет результат боя
    // Используется для переноса информации о полученных очках в следующую сцену
    // Информация о заработанных очках берётся из скрипта scoreStats
    // Сохраняется в int score

    int score;
    StatisticsScript scoreStats;

    //Использую DontDestroyOnLoad для сохранения SaveScore и переноса его в другую сцену
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        scoreStats = FindObjectOfType<StatisticsScript>(); 
    }


    // Обновляем заработанные очки
    // Update is called once per frame
    void Update()
    {
        score = scoreStats.GetScore(); 
    }

    // публичный метод для извлечения информации из переменной score
    public int GetScore()
    {
        return score;
    }
}
