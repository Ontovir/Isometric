using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadScore : MonoBehaviour
{
    // В этом TMPro будет отображаться значение score
    [SerializeField] TextMeshProUGUI score;

    // При загрузке сцены нахожу сохранённый из предыдущей сцены скрипт SaveScore
    // Назначаю тексту score.text значение с использованием открытого метода из SaveScore

    // Start is called before the first frame update
    void Start()
    {
        SaveScore stats = FindObjectOfType<SaveScore>();
        score.text = "Score: " + stats.GetScore().ToString();
    }
}
