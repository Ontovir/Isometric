using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatisticsScript : MonoBehaviour
{
    // ������ �������� �� ����������� ���������� � UI � �������������� ��������� TMPro
    //
    [SerializeField] GameObject playerForInformation;
    [SerializeField] GameObject attackInformationPrefab;

    // ������, ������� ��� �����, ����� ���������� ����
    //
    [Header("TMPro update")]
    [SerializeField] TextMeshProUGUI healthTMPro;
    [SerializeField] TextMeshProUGUI attackTMPro;
    [SerializeField] TextMeshProUGUI speedTMPro;
    [SerializeField] TextMeshProUGUI scoreTMPro;

    // ����������, ������������ � �������
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

    // ������� � ��������� ���������� ����� �����
    private void StartStats()
    {
        speedInformation = playerForInformation.GetComponent<PlayerController>();
        healthInformation = playerForInformation.GetComponent<PlayerAttack>();
        attackInformation = attackInformationPrefab.GetComponent<DamageDealerScript>();
        maxHealth = healthInformation.GetHealth();

        // ��������� �������� � TMPro
        healthTMPro.text = "Health: " + healthInformation.GetHealth().ToString() + " / " + maxHealth;
        attackTMPro.text = "Attack: " + attackInformation.GetDamage().ToString();
        speedTMPro.text = "Speed: " + speedInformation.GetSpeed().ToString();
        scoreTMPro.text = "Score: " + score.ToString();
    }

    // ��������� ������ � TMPro �����������
    private void UpdateStats()
    {
        healthTMPro.text = "Health: " + healthInformation.GetHealth().ToString() + " / " + maxHealth;
        attackTMPro.text = "Attack: " + attackInformation.GetDamage().ToString();
        speedTMPro.text = "Speed: " + speedInformation.GetSpeed().ToString();
        scoreTMPro.text = "Score: " + score.ToString();
    }

    // ��� ������ ����� ���������� ����� ������ StatisticsScript ScoreUpdate, ������� ����������� �������� ����� �� 1
    // �� ������� ������� ����� +1
    public void ScoreUpdate ()
    {
        score++;
    }

    // ������ ����������� �������� score ��� �������� �� ������ �����
    public int GetScore()
    {
        return score;
    }
}
