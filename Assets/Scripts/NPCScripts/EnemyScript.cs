using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : NonPlayerCharacter
{
    [SerializeField] private int enemyHealth = 100;
    [SerializeField] GameObject enemyAttackAnimation;
    [SerializeField] float attackCounter = 1f;
    [SerializeField] GameObject enemyHealthBar;
    private GameObject enemyHealthBarInit;
    private bool enemyHealthBarActive = false;
    private bool isAlive = true;
    // ����� Start ��������� ����� StartCoordinates �� ������������ ������ NonPlayerCharacter
    // � �������� �������� StartMove

    // Start is called before the first frame update
    void Start()
    {
        //EnemyHealthBarInit();
        StartCoordinates();
        StartCoroutine(StartMove());
    }
    private void EnemyHealthBarInit()
    {
        Vector3 corrVec = new Vector3(0.1f, 0.1f, 0f);
        enemyHealthBarInit = Instantiate
            (enemyHealthBar, transform.position - corrVec, Quaternion.identity) as GameObject;
        enemyHealthBarInit.GetComponent<Slider>().maxValue = enemyHealth;
        enemyHealthBarActive = true;
    }
    private void EnemyHealthBarUpdate()
    {
        if (enemyHealthBarActive)
        {
            enemyHealthBarInit.GetComponent<Slider>().value = enemyHealth;
        }
    }

    // � ������ Update ����������� ����� Movement �� ������ NonPlayerCharacter
    // ����� Movement �������� �� ������� �������� NPC � ����� �����������

    // Update is called once per frame
    void Update()
    {
        //EnemyHealthBarUpdate();
        Movement();
        AttackCountdown();
    }


    // �������� StartMove �������� �������� ����� GetRandomCoordinates ������ NonPlayerCharacter
    // ���������� ����� ���������� � ������ 0.5f ������� ����������� ��������. 
    // �������� ��������, ������ 0.5f ������ ���������� ����� ���������� � NPC �������� � ���.
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
        enemyHealthBarActive = false;
        Destroy(enemyHealthBar, 1f);
        Destroy(gameObject, 1f);
    }
}
