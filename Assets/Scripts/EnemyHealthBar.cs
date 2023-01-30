using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    Vector2 healthBarScale;
    EnemyScript enemy;
    [SerializeField] GameObject enemyObject;
    private float health;
    // Start is called before the first frame update
    void Start()
    {
        AddHealthBarPosition();
        AddHealthBarScale();
    }

    // Update is called once per frame
    void Update()
    {
        HealthBarUpdate();   
    }

    private void HealthBarUpdate()
    {
        float nowHealth = enemy.EnemyHealth() / health;
        if (nowHealth >= 0)
        {
            healthBarScale.x = nowHealth;
            transform.localScale = healthBarScale;
        }
        else
        {
            nowHealth = 0;
            healthBarScale.x = nowHealth;
            transform.localScale = healthBarScale;
        }
    }
    private void AddHealthBarScale()
    { 
        enemy = FindObjectOfType<EnemyScript>(enemyObject);
        health = enemy.EnemyHealth();
        healthBarScale = transform.localScale;
    }

    private void AddHealthBarPosition()
    {
        Vector2 newPos = new Vector2(transform.position.x, transform.position.y + 0.8f);
        transform.position = newPos;
    }
}
