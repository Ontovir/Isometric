using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    // Start is called before the first frame update
    void Start()
    {
        StatisticsScript stats = FindObjectOfType<StatisticsScript>();
        score.text += stats.GetScore().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
