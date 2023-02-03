using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class EnemyScript : NonPlayerCharacter
{
    // � SerializeField ���������� ���������� ������ �������� �����, ������������� ������ �������� ��� �����
    // AttackCounter ����� ��� ���������� ������ ����� ����� �� �������
    // �������� � textMeshPro ����� ��� ����������� ���������� ������ �����
    [SerializeField] public int enemyHealth;
    [SerializeField] GameObject enemyAttackAnimation;
    [SerializeField] float attackCounter = 1f;
    [SerializeField] TextMeshProUGUI playerAttack;

    // ������ ���������� ���������� ������ �����. ��� �� � ������� �� �� ������ ������
    // StatisticsScript ����� ��� �������� ������ ������
    private bool isAlive = true;
    private bool isAttackOn;
    StatisticsScript stats;

    // ����� Start ��������� ����� StartCoordinates �� ������������ ������ NonPlayerCharacter
    // � �������� �������� StartMove

    // Start is called before the first frame update
    void Start()
    {
        stats = FindObjectOfType<StatisticsScript>();
        StartCoordinates();
        StartCoroutine(StartMove());
    }
   
    // � ������ Update ����������� ����� Movement �� ������ NonPlayerCharacter
    // ����� Movement �������� �� ������� �������� NPC � ����� �����������

    // Update is called once per frame
    void Update()
    {
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

    // ����� EnemyAttackAnimation �������� �� ����� �������� ����� �����
    // ��� ������� �� ����� ������ ���� ���������� ���������� ���������� bool isAttackOn = ture
    // ����������� �������������� ������ ��� ��������������� �������� �����
    // ���������� Instantiate �������� ������� Attack - �������, �������� �������� � ��������� �� ���������� ��������
    // ������ 0.3f ���� ������� ������ ������������
    // ������ 0.3f ���������� bool isAttackOff ������������� �������� false
    private void EnemyAttackAnimation()
    {
        isAttackOn = true;
        Vector3 corrVec = new Vector3(0.1f, 0.1f, 0f);
        GameObject attack = Instantiate
            (enemyAttackAnimation, transform.position - corrVec, Quaternion.identity) as GameObject;
        Destroy(attack, 0.3f);
        Invoke("AttackOff", 0.3f);
    }


    // ����� AttackCountdown() ����� ��� ������ ����� ������ ����������� ���������� ������� (������������ ��������� �������)
    // �� ���������� attackCounter ���������� Time.deltaTime
    // ���� ����� ����� ���������� attackCounter ������ ��� ����� ����, ����� ���������� ����� instantiate ����� ����� (EnemyAttackAnimation)
    // ���������� �����, ���������� �������� ����� �� �������� �����
    // �������������� ����� �������� attackCounter ������� ������ Random.Range
    // Invoke ���������� ������ ���������� isAttackOn = false, ��������� �������� �����
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

    // ����� Collision ������� 
    // ���� ���������� trigger collision � ��������, ������� ��� Player (� ����� ������, ��� ���������� �������� ����� ������ � �����������)
    // �����, ���������� ������ DamageDealerScript ���� �����. ���� ��� �������, ����� ������� �����������. 
    // ���� ����, ����� ���������� ����� �������� ����� ������� ������ �� ������� DamageDealerScript ����� GetDamage().ToString()
    // ����������� �������� ������� ������ 
    // �������� ����� ��������� � ����� EnemyDeath � ����� PlayerDeath �����������.
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
    // ����� EnemyDeath ��������� �������� damageDealer
    // �� �������� ������ enemyHealth ���������� �������� ����� ��������� ����� ���� ������ ������ GetDamage()
    // ����������� ����� Hit(), ���������� ����������� instantiate ������� ����� ������
    // ���� enemyHealth � ���������� ���������� ����� ���������� ������ ��� ����� ����, ����� ����������� ����� Die()
    private void EnemyDeath(DamageDealerScript damageDealer)
    {
        enemyHealth -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (enemyHealth <= 0)
        {
            Die();
        }
    }

    // ����� Die ���������� ��� ������ �����
    // ��������� ���������� isAlive = false
    // ������� ��������� � ������ �����
    // ��������� �������� ������� ���������� ���� �����
    // ������ 0.2f ���������� �����
    private void Die()
    {
        isAlive = false;
        playerAttack.text = "DIED";
        StartCoroutine(textCleanCoroutine());
        Destroy(gameObject, 0.01f);
        stats.ScoreUpdate();
    }

    // �������� ������� ������ ������ 1f ����� �������
    IEnumerator textCleanCoroutine()
    {
        yield return new WaitForSeconds(1f);
        playerAttack.text = "";
        StopCoroutine(textCleanCoroutine());
    }

    // ����� npcAttackAnimation ��������� ������ ���������� isAttackOn ������� ������ IsAttackOn
    // ���� � ������ true, ����� ����������� ������ ������� ���������� ��������� �����
    // � ����������� �� ����������� �������� ���������� �������� ����� �����
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

    // ������ ���� �� ���� ������������ Off
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

    // ����� ������� �������� ������ �������� ����� ��� ������ ������
    public int EnemyHealth()
    {
        return enemyHealth;
    }
    // ���������� �����, ��������� ������ ���������� isAttackOn = false
    private void AttackOff()
    {
        isAttackOn = false;
    }
    // �����, ����������� ��� ���������� ���������� �������� �����
    public bool IsAttackOn()
    {
        return isAttackOn;
    }
}
