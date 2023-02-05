using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    // Назначаем, к какому врагу принадлежит этот конкретный healthBar
    [SerializeField] GameObject enemyObject;

    // Переменные класса EnemyHealthBar
    // HealthBarScale в последствии передаёт данные о масштабе HealthBar по оси X
    // enemy переменная для поиска скрипта EnemyScript, в котором содержится информация о здоровье конкретного врага
    // float maxHealth нужна для расчёта величины трансформации HealthBar'a
    Vector2 healthBarScale;
    EnemyScript enemy;
    private float maxHealth;

    // Назначаем размер и уровень здоровья для HealthBar
    // Start is called before the first frame update
    void Start()
    {
        AddHealthBarScale();
    }

    // Обновляем инфо о масштабе health bar по оси X
    // Update is called once per frame
    void Update()
    {
        HealthBarUpdate();   
    }


    // Метод HealthBarUpdate нужен для обновления информации об уровне здоровья NPC
    // В переменную Vector2 healthBarScale переносится информация о текущем масштабе спрайта
    // Переменной метода nowHealth присваивается значение. Происходит вызов метода EnemyHealth из скрипта EnemyScript, 
    // Текущий уровень здоровья из EnemyHealth делится на начальный уровень здоровья maxHealth
    // Если nowHealth больше или равно нулю, тогда масштабу healthBarScale по оси X присваивается значение из переменной nowHealth 
    // Промежуток значений от 0f до 1f
    // Масштаб спрайта изменяется присвоением healthBarScale
    // в противном случае, если значение nowHealth вдруг отрицательное, тогда переменной nowHealth присваивается 0
    private void HealthBarUpdate()
    {
        healthBarScale = transform.localScale;
        float nowHealth = enemy.EnemyHealth() / maxHealth;
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

    // Метод AddHealthBarScale выполняет функцию настройки отображения healthBar над моделькой врага
    // Переменной EnemyScript enemy присваивается значение EnemyScript из привязанного в SerializeField игрового объекта врага
    // Переменной maxHealth присваивается значение здоровья из скрипта enemy методом EnemyHealth()
    // Дебаг в тестовых целях, для проверки
    // Vector3 newPos нужен для правильного позиционирования HealthBar над моделькой врага
    private void AddHealthBarScale()
    {
        enemy = enemyObject.GetComponent<EnemyScript>();
        maxHealth = enemy.EnemyHealth();
        Debug.Log(maxHealth);
        Vector3 newPos = new Vector3(0f, 30f, 0f);
        transform.position = enemyObject.transform.position + newPos*Time.deltaTime;
    }
}
