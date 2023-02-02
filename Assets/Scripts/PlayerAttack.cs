using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] int playerHealth = 100;
    [SerializeField] GameObject attackAnimation;
    [SerializeField] GameObject healthBarSlider;
    [SerializeField] TextMeshProUGUI enemyAttack;
    private bool isAttackOn;

    // Start is called before the first frame update
    void Start()
    {
        PlayerMaxHealthInitialize();
    }

    private void PlayerHealthUpdate()
    {
        healthBarSlider.GetComponent<Slider>().value = playerHealth;
    }
    private void PlayerMaxHealthInitialize()
    {
        healthBarSlider.GetComponent<Slider>().maxValue = playerHealth;
        healthBarSlider.GetComponent<Slider>().value = playerHealth;
    }
    // Update is called once per frame
    void Update()
    {
        PlayerAttackAnimation();
        PlayerHealthUpdate();
    }
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
    private void AttackOff()
    {
        isAttackOn = false;
    }

    public bool IsAttackOn()
    {
        return isAttackOn;
    }
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

    private void PlayerDeath(DamageDealerScript damageDealer)
    {
        playerHealth -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (playerHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        GetComponent<PlayerController>().enabled = false;
        enemyAttack.text = "DIED";
        StartCoroutine(textCleanCoroutine());
        Destroy(gameObject, 1f);
    }
    IEnumerator textCleanCoroutine()
    {
        yield return new WaitForSeconds(2f);
        enemyAttack.text = "";
        StopCoroutine(textCleanCoroutine());
    }
}
