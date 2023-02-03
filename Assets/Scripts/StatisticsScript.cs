using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatisticsScript : MonoBehaviour
{
    [SerializeField] GameObject playerForInformation;
    [SerializeField] GameObject attackInformationPrefab;

    PlayerController speedInformation;
    PlayerAttack healthInformation;
    DamageDealerScript attackInformation;
    private int score = 0;
    private int maxHealth;

    [Header("TMPro update")]
    [SerializeField] TextMeshProUGUI healthTMPro;
    [SerializeField] TextMeshProUGUI attackTMPro;
    [SerializeField] TextMeshProUGUI speedTMPro;
    [SerializeField] TextMeshProUGUI scoreTMPro;
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

    private void StartStats()
    {

        speedInformation = playerForInformation.GetComponent<PlayerController>();
        healthInformation = playerForInformation.GetComponent<PlayerAttack>();
        attackInformation = attackInformationPrefab.GetComponent<DamageDealerScript>();
        maxHealth = healthInformation.GetHealth();

        healthTMPro.text = "Health: " + healthInformation.GetHealth().ToString() + " / " + maxHealth;
        attackTMPro.text = "Attack: " + attackInformation.GetDamage().ToString();
        speedTMPro.text = "Speed: " + speedInformation.GetSpeed().ToString();
        scoreTMPro.text = "Score: " + score.ToString();
    }

    private void UpdateStats()
    {
        healthTMPro.text = "Health: " + healthInformation.GetHealth().ToString() + " / " + maxHealth;
        attackTMPro.text = "Attack: " + attackInformation.GetDamage().ToString();
        speedTMPro.text = "Speed: " + speedInformation.GetSpeed().ToString();
        scoreTMPro.text = "Score: " + score.ToString();
    }

    public void ScoreUpdate ()
    {
        score++;
    }
    public int GetScore()
    {
        return score;
    }
}
