using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatisticsScript : MonoBehaviour
{
    // Скрипт отвечает за отображение статистики в UI с использованием элементов TMPro
    //
    [SerializeField] GameObject playerForInformation;
    [SerializeField] GameObject attackInformationPrefab;

    // Данные, которые нам нужны, будем отправлять сюда
    //
    [Header("TMPro update")]
    [SerializeField] TextMeshProUGUI healthTMPro;
    [SerializeField] TextMeshProUGUI attackTMPro;
    [SerializeField] TextMeshProUGUI speedTMPro;
    [SerializeField] TextMeshProUGUI scoreTMPro;

    // Переменные, используемые в скрипте
    PlayerController speedInformation;
    PlayerAttack healthInformation;
    DamageDealerScript attackInformation;
    private int score = 0;
    private int maxHealth;


    // Start is called before the first frame update
    void Start()
    {
        StartStats();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateStats();
    }

    // Находим и связываем компоненты между собой
    private void StartStats()
    {
        speedInformation = playerForInformation.GetComponent<PlayerController>();
        healthInformation = playerForInformation.GetComponent<PlayerAttack>();
        attackInformation = attackInformationPrefab.GetComponent<DamageDealerScript>();
        maxHealth = healthInformation.GetHealth();

        // Переносим значения в TMPro
        healthTMPro.text = "Health: " + healthInformation.GetHealth().ToString() + " / " + maxHealth;
        attackTMPro.text = "Attack: " + attackInformation.GetDamage().ToString();
        speedTMPro.text = "Speed: " + speedInformation.GetSpeed().ToString();
        scoreTMPro.text = "Score: " + score.ToString();
    }

    // Обновляем данные в TMPro компонентах
    private void UpdateStats()
    {
        healthTMPro.text = "Health: " + healthInformation.GetHealth().ToString() + " / " + maxHealth;
        attackTMPro.text = "Attack: " + attackInformation.GetDamage().ToString();
        speedTMPro.text = "Speed: " + speedInformation.GetSpeed().ToString();
        scoreTMPro.text = "Score: " + score.ToString();
    }

    // При смерти врага вызывается метод класса StatisticsScript ScoreUpdate, который увеличивает значение очков на 1
    // за каждого убитого врага +1
    public void ScoreUpdate ()
    {
        score++;
    }

    // Отсюда сохраняется значение score для перехода на другую сцену
    public int GetScore()
    {
        return score;
    }
}
