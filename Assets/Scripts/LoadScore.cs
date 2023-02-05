using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadScore : MonoBehaviour
{
    // � ���� TMPro ����� ������������ �������� score
    [SerializeField] TextMeshProUGUI score;

    // ��� �������� ����� ������ ���������� �� ���������� ����� ������ SaveScore
    // �������� ������ score.text �������� � �������������� ��������� ������ �� SaveScore

    // Start is called before the first frame update
    void Start()
    {
        SaveScore stats = FindObjectOfType<SaveScore>();
        score.text = "Score: " + stats.GetScore().ToString();
    }
}
