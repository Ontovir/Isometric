using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerAttack : MonoBehaviour
{
    // Класс PlayerAttack назначает модели игрока здоровье, его отображение в healthBar на Canvas и отвечает за анимацию атаки игрока
    // SerializeField для здоровья игрока, префаба атаки игрока, healthBar игрока, и для отображения урона по врагу в элементе textMeshPro 
    [SerializeField] int playerHealth = 100;
    [SerializeField] GameObject attackAnimation;
    [SerializeField] GameObject healthBarSlider;
    [SerializeField] TextMeshProUGUI enemyAttack;
    SceneLoader sceneLoader;

    // Bool isAttackOn нужна для анимации атаки игрока в скрипте PlayerMoveAnimation. Вызывается методом bool IsAttackOn()
    private bool isAttackOn;

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        PlayerMaxHealthInitialize();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerAttackAnimation();
        PlayerHealthUpdate();
    }

    // Метод PlayerAttackAnimation отвечает за вызов анимации атаки игрока
    // При нажатии на левую кнопку мыши происходит назначение переменной bool isAttackOn = ture
    // Добавляется корректирующий вектор для инстанциируемой анимации атаки
    // Происходит Instantiate игрового объекта Attack - префаба, имеющего анимацию и коллайдер со свойствами триггера
    // Спустя 0.3f этот игровой объект уничтожается
    // Спустя 0.2f переменной bool isAttackOff присваивается значение false
    private void PlayerAttackAnimation()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isAttackOn = true;
            Vector3 corrVec = new Vector3 (0.1f, 0.1f, 0f);
            GameObject attack = Instantiate
                (attackAnimation, transform.position-corrVec, Quaternion.identity);
            Destroy(attack, 0.3f);
            Invoke("AttackOff", 0.2f);
        }
    }

    // Метод назначает переменной isAttackOn = false
    private void AttackOff()
    {
        isAttackOn = false;
    }

    //Метод IsAttackOn() возвращает значение переменной isAttackOn
    public bool IsAttackOn()
    {
        return isAttackOn;
    }

    // Метод Collision триггер 
    // Если происходит trigger collision с объектом, имеющим тег Enemy (в нашем случае, это вызываемая анимация атаки врага с коллайдером)
    // Тогда, вызывается скрипт DamageDealerScript этой атаки. Если нет скрипта, тогда коллижн завершается. 
    // Если есть, тогда происходит вывод значения атаки вызовом метода из скрипта DamageDealerScript атаки GetDamage().ToString()
    // Запускается корутина очистки текста 
    // Значение атаки передаётся в метод PlayerDeath и метод PlayerDeath запускается.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            DamageDealerScript damageDealer =
                other.gameObject.GetComponent<DamageDealerScript>();
            if (!damageDealer) { return; }
            enemyAttack.text += "-" + damageDealer.GetDamage().ToString() + ", ";
            StartCoroutine(textCleanCoroutine());
            PlayerDeath(damageDealer);
        }
    }

    // Метод PlayerDeath принимает значение damageDealer
    // от здоровья игрока playerHealth отнимается значение урона вражеской атаки путём вызова метода GetDamage()
    // Запускается метод Hit(), происходит уничтожение instantiate объекта вражеской атаки
    // Если playerHealth в результате нанесённого урона становится меньше или равно нулю, тогда запускается метод Die()
    private void PlayerDeath(DamageDealerScript damageDealer)
    {
        playerHealth -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (playerHealth <= 0)
        {
            Die();
        }
    }

    // Метод Die вызывается при смерти персонажа
    // Отключает скрипт контроля персонажа
    // Выводит сообщение о смерти игрока
    // Запускает корутину очистки текстового поля урона
    // Спустя 1f уничтожает игрока
    private void Die()
    {
        GetComponent<PlayerController>().enabled = false;
        enemyAttack.text = "DIED";
        sceneLoader.EndGame();
        StartCoroutine(textCleanCoroutine());
        Destroy(gameObject, 1f);
    }

    // Корутина очистки текста спустя 2f после запуска
    IEnumerator textCleanCoroutine()
    {
        yield return new WaitForSeconds(2f);
        enemyAttack.text = "";
        StopCoroutine(textCleanCoroutine());
    }

    // Методы ниже отвечают за инициализацию healthBar игрока и за её обновление. 
    // Используется компонент slider пространства имён UnityEngine.UI
    private void PlayerMaxHealthInitialize()
    {
        healthBarSlider.GetComponent<Slider>().maxValue = playerHealth;
        healthBarSlider.GetComponent<Slider>().value = playerHealth;
    }
    private void PlayerHealthUpdate()
    {
        healthBarSlider.GetComponent<Slider>().value = playerHealth;
    }

    // Возврат значения здоровья для статистики
    public int GetHealth()
    {
        return playerHealth;
    }
}
