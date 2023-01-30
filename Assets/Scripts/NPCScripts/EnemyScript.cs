using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class EnemyScript : NonPlayerCharacter
{
    [SerializeField] public int enemyHealth = 100;
    [SerializeField] GameObject enemyAttackAnimation;
    [SerializeField] float attackCounter = 1f;
    [SerializeField] TextMeshProUGUI playerAttack;

    private bool isAlive = true;
    // ћетод Start загружает метод StartCoordinates из абстрактного класса NonPlayerCharacter
    // и начинает корутину StartMove

    // Start is called before the first frame update
    void Start()
    {
        StartCoordinates();
        StartCoroutine(StartMove());
    }

    public int EnemyHealth()
    {
        return enemyHealth;
    }
    // ¬ методе Update загружаетс€ метод Movement из класса NonPlayerCharacter
    // ћетод Movement отвечает за плавное движение NPC к новым координатам

    // Update is called once per frame
    void Update()
    {
        Movement();
        AttackCountdown();
    }


    //  орутина StartMove вызывает открытый метод GetRandomCoordinates класса NonPlayerCharacter
    // ѕо€вл€ютс€ новые координаты и спуст€ 0.5f секунды отключаетс€ анимаци€. 
    //  орутина циклична, каждые 0.5f секунд по€вл€ютс€ новые координаты и NPC движетс€ к ним.
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
    private void EnemyAttackAnimation()
    {
        Vector3 corrVec = new Vector3(0.1f, 0.1f, 0f);
        GameObject attack = Instantiate
            (enemyAttackAnimation, transform.position - corrVec, Quaternion.identity) as GameObject;
        Destroy(attack, 0.3f);
    }
    private void AttackCountdown()
    {
        attackCounter -= Time.deltaTime;
        if (attackCounter <= 0f)
        {
            EnemyAttackAnimation();
            attackCounter = Random.Range(0.1f, 1f);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            DamageDealerScript damageDealer =
                other.gameObject.GetComponent<DamageDealerScript>();
            if (!damageDealer) { return; }
            playerAttack.text += "-" + damageDealer.GetDamage().ToString() + ", ";
            EnemyDeath(damageDealer);
        }
    }

    private void EnemyDeath(DamageDealerScript damageDealer)
    {
        enemyHealth -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (enemyHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        isAlive = false;
        StartCoroutine(textCleanCoroutine());
        Destroy(gameObject, 1f);

    }
    IEnumerator textCleanCoroutine()
    {
        playerAttack.text = "DIED";
        yield return new WaitForSeconds(2f);
        playerAttack.text = "";
        StopCoroutine(textCleanCoroutine());
    }
}
