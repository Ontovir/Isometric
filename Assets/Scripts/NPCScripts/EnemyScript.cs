using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class EnemyScript : NonPlayerCharacter
{
    [SerializeField] public int enemyHealth;
    [SerializeField] GameObject enemyAttackAnimation;
    [SerializeField] float attackCounter = 1f;
    [SerializeField] TextMeshProUGUI playerAttack;

    private bool isAlive = true;
    private bool isAttackOn;
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
        isAttackOn = true;
        Vector3 corrVec = new Vector3(0.1f, 0.1f, 0f);
        GameObject attack = Instantiate
            (enemyAttackAnimation, transform.position - corrVec, Quaternion.identity) as GameObject;
        Destroy(attack, 0.3f);
        Invoke("AttackOff", 0.3f);
    }

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
    private void AttackOff()
    {
        isAttackOn = false;
    }
    public bool IsAttackOn()
    {
        return isAttackOn;
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
        playerAttack.text = "DIED";
        StartCoroutine(textCleanCoroutine());
        Destroy(gameObject, 1f);

    }
    IEnumerator textCleanCoroutine()
    {
        yield return new WaitForSeconds(1f);
        playerAttack.text = "";
        StopCoroutine(textCleanCoroutine());
    }
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
}
