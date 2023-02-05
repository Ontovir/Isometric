using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScore : MonoBehaviour
{
    // ������, ������� ��������� ��������� ���
    // ������������ ��� �������� ���������� � ���������� ����� � ��������� �����
    // ���������� � ������������ ����� ������ �� ������� scoreStats
    // ����������� � int score

    int score;
    StatisticsScript scoreStats;

    //��������� DontDestroyOnLoad ��� ���������� SaveScore � �������� ��� � ������ �����
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        scoreStats = FindObjectOfType<StatisticsScript>(); 
    }


    // ��������� ������������ ����
    // Update is called once per frame
    void Update()
    {
        score = scoreStats.GetScore(); 
    }

    // ��������� ����� ��� ���������� ���������� �� ���������� score
    public int GetScore()
    {
        return score;
    }
}
