using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    Vector2 healthBarScale;
    [SerializeField] GameObject enemyObject;
    EnemyScript enemy;
    private float health;
    // Start is called before the first frame update
    void Start()
    {
        AddHealthBarScale();
    }

    // Update is called once per frame
    void Update()
    {
        HealthBarUpdate();   
    }

    private void HealthBarUpdate()
    {
        healthBarScale = transform.localScale;
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
        enemy = enemyObject.GetComponent<EnemyScript>();
        health = enemy.EnemyHealth();
        Debug.Log(health);
        Vector2 newPos = new Vector2(transform.position.x, transform.position.y + (36f*Time.deltaTime));
        transform.position = newPos;
    }
}
