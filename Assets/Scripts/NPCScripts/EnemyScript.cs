using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class EnemyScript : NonPlayerCharacter
{
    // В SerializeField происходит назначение уровня здоровья врага, привязывается префаб анимации его атаки
    // AttackCounter нужен для случайного вызова атаки врага во времени
    // Привязка к textMeshPro нужна для отображения наносимого игроку урона
    [SerializeField] public int enemyHealth;
    [SerializeField] GameObject enemyAttackAnimation;
    [SerializeField] float attackCounter = 1f;
    [SerializeField] TextMeshProUGUI playerAttack;

    // Булевы переменные показывают статус врага. Жив он и атакует ли на данный момент
    // StatisticsScript нужен для подсчёта убитых врагов
    private bool isAlive = true;
    private bool isAttackOn;
    StatisticsScript stats;

    // Метод Start загружает метод StartCoordinates из абстрактного класса NonPlayerCharacter
    // и начинает корутину StartMove

    // Start is called before the first frame update
    void Start()
    {
        stats = FindObjectOfType<StatisticsScript>();
        StartCoordinates();
        StartCoroutine(StartMove());
    }
   
    // В методе Update загружается метод Movement из класса NonPlayerCharacter
    // Метод Movement отвечает за плавное движение NPC к новым координатам

    // Update is called once per frame
    void Update()
    {
        Movement();
        AttackCountdown();
    }


    // Корутина StartMove вызывает открытый метод GetRandomCoordinates класса NonPlayerCharacter
    // Появляются новые координаты и спустя 0.5f секунды отключается анимация. 
    // Корутина циклична, каждые 0.5f секунд появляются новые координаты и NPC движется к ним.
    IEnumerator StartMove()
    {
        if (isAlive)
        {
            while (1 > 0)
            {
                GetRandomCoordinates();
                yield return new WaitForSeconds(0.5f);
                StopNPCAnimation();
            }
        }
    }

    // Метод EnemyAttackAnimation отвечает за вызов анимации атаки врага
    // При нажатии на левую кнопку мыши происходит назначение переменной bool isAttackOn = ture
    // Добавляется корректирующий вектор для инстанциируемой анимации атаки
    // Происходит Instantiate игрового объекта Attack - префаба, имеющего анимацию и коллайдер со свойствами триггера
    // Спустя 0.3f этот игровой объект уничтожается
    // Спустя 0.3f переменной bool isAttackOff присваивается значение false
    private void EnemyAttackAnimation()
    {
        isAttackOn = true;
        Vector3 corrVec = new Vector3(0.1f, 0.1f, 0f);
        GameObject attack = Instantiate
            (enemyAttackAnimation, transform.position - corrVec, Quaternion.identity) as GameObject;
        Destroy(attack, 0.3f);
        Invoke("AttackOff", 0.3f);
    }


    // Метод AttackCountdown() нужен для вызова атаки спустя определённое количество времени (генерируется случайным образом)
    // Из переменной attackCounter вычитается Time.deltaTime
    // Если после этого переменная attackCounter больше или равна нулю, тогда вызывается метод instantiate атаки врага (EnemyAttackAnimation)
    // Вызывается метод, изменяющий анимацию врага на анимацию атаки
    // Рассчитывается новая величина attackCounter вызовом метода Random.Range
    // Invoke возвращает статус переменной isAttackOn = false, отключает анимацию атаки
    private void AttackCountdown()
    {
        attackCounter -= Time.deltaTime;
        if (attackCounter <= 0f)
        {
            EnemyAttackAnimation();
            npcAttackAnimation();
            attackCounter = Random.Range(0.1f, 1f);
            Invoke("AttackOff", 0.3f);
            Invoke("npcAttackAnimationSetOff", 0.3f);
        }
    }

    // Метод Collision триггер 
    // Если происходит trigger collision с объектом, имеющим тег Player (в нашем случае, это вызываемая анимация атаки игрока с коллайдером)
    // Тогда, вызывается скрипт DamageDealerScript этой атаки. Если нет скрипта, тогда коллижн завершается. 
    // Если есть, тогда происходит вывод значения атаки вызовом метода из скрипта DamageDealerScript атаки GetDamage().ToString()
    // Запускается корутина очистки текста 
    // Значение атаки передаётся в метод EnemyDeath и метод PlayerDeath запускается.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            DamageDealerScript damageDealer =
                other.gameObject.GetComponent<DamageDealerScript>();
            if (!damageDealer) { return; }
            playerAttack.text += "-" + damageDealer.GetDamage().ToString() + ", ";
            StartCoroutine(textCleanCoroutine());
            EnemyDeath(damageDealer);
        }
    }
    // Метод EnemyDeath принимает значение damageDealer
    // от здоровья игрока enemyHealth отнимается значение урона вражеской атаки путём вызова метода GetDamage()
    // Запускается метод Hit(), происходит уничтожение instantiate объекта атаки игрока
    // Если enemyHealth в результате нанесённого урона становится меньше или равно нулю, тогда запускается метод Die()
    private void EnemyDeath(DamageDealerScript damageDealer)
    {
        enemyHealth -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (enemyHealth <= 0)
        {
            Die();
        }
    }

    // Метод Die вызывается при смерти врага
    // назначает переменной isAlive = false
    // Выводит сообщение о смерти врага
    // Запускает корутину очистки текстового поля урона
    // Спустя 0.2f уничтожает врага
    private void Die()
    {
        isAlive = false;
        playerAttack.text = "DIED";
        StartCoroutine(textCleanCoroutine());
        Destroy(gameObject, 0.01f);
        stats.ScoreUpdate();
    }

    // Корутина очистки текста спустя 1f после запуска
    IEnumerator textCleanCoroutine()
    {
        yield return new WaitForSeconds(1f);
        playerAttack.text = "";
        StopCoroutine(textCleanCoroutine());
    }

    // Метод npcAttackAnimation проверяет статус переменной isAttackOn вызовом метода IsAttackOn
    // Если её статус true, тогда проверяется список булевых переменных аниматора врага
    // В зависимости от направления движения вызывается анимация атаки врага
    private void npcAttackAnimation()
    {
        if (IsAttackOn() && npcAnimation.GetBool("IsWDown"))
        {
            //npcAnimation.SetBool("AttackW", true);
            npcAnimation.Play("AttackW");
        }
        if (IsAttackOn() && npcAnimation.GetBool("IsDDown"))
        {
            //npcAnimation.SetBool("AttackD", true);
            npcAnimation.Play("AttackD");
        }
        if (IsAttackOn() && npcAnimation.GetBool("IsSDown"))
        {
            //npcAnimation.SetBool("AttackS", true);
            npcAnimation.Play("AttackS");
        }
        if (IsAttackOn() && npcAnimation.GetBool("IsADown"))
        {
            //npcAnimation.SetBool("AttackA", true);
            npcAnimation.Play("AttackA");
        }
        if (IsAttackOn() && npcAnimation.GetBool("IsWDDown"))
        {
            //npcAnimation.SetBool("AttackWD", true);
            npcAnimation.Play("AttackWD");
        }
        if (IsAttackOn() && npcAnimation.GetBool("IsSDDown"))
        {
            //npcAnimation.SetBool("AttackSD", true);
            npcAnimation.Play("AttackSD");
        }
        if (IsAttackOn() && npcAnimation.GetBool("IsASDown"))
        {
            //npcAnimation.SetBool("AttackAS", true);
            npcAnimation.Play("AttackAS");
        }
        if (IsAttackOn() && npcAnimation.GetBool("IsAWDown"))
        {
            //npcAnimation.SetBool("AttackAW", true);
            npcAnimation.Play("AttackAW");
        }
    }

    // Статус атак во всех направлениях Off
    private void npcAttackAnimationSetOff()
    {
            npcAnimation.SetBool("AttackW", false);
            npcAnimation.SetBool("AttackD", false);
            npcAnimation.SetBool("AttackS", false);
            npcAnimation.SetBool("AttackA", false);
            npcAnimation.SetBool("AttackWD", false);
            npcAnimation.SetBool("AttackSD", false);
            npcAnimation.SetBool("AttackAS", false);
            npcAnimation.SetBool("AttackAW", false);
    }

    // Метод передаёт значение уровня здоровья врага при вызове метода
    public int EnemyHealth()
    {
        return enemyHealth;
    }
    // Внутренний метод, назначает статус переменной isAttackOn = false
    private void AttackOff()
    {
        isAttackOn = false;
    }
    // Метод, необходимый для назначения правильной анимации атаки
    public bool IsAttackOn()
    {
        return isAttackOn;
    }
}
