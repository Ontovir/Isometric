using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerAttack : MonoBehaviour
{
    // ����� PlayerAttack ��������� ������ ������ ��������, ��� ����������� � healthBar �� Canvas � �������� �� �������� ����� ������
    // SerializeField ��� �������� ������, ������� ����� ������, healthBar ������, � ��� ����������� ����� �� ����� � �������� textMeshPro 
    [SerializeField] int playerHealth = 100;
    [SerializeField] GameObject attackAnimation;
    [SerializeField] GameObject healthBarSlider;
    [SerializeField] TextMeshProUGUI enemyAttack;
    SceneLoader sceneLoader;

    // Bool isAttackOn ����� ��� �������� ����� ������ � ������� PlayerMoveAnimation. ���������� ������� bool IsAttackOn()
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

    // ����� PlayerAttackAnimation �������� �� ����� �������� ����� ������
    // ��� ������� �� ����� ������ ���� ���������� ���������� ���������� bool isAttackOn = ture
    // ����������� �������������� ������ ��� ��������������� �������� �����
    // ���������� Instantiate �������� ������� Attack - �������, �������� �������� � ��������� �� ���������� ��������
    // ������ 0.3f ���� ������� ������ ������������
    // ������ 0.2f ���������� bool isAttackOff ������������� �������� false
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

    // ����� ��������� ���������� isAttackOn = false
    private void AttackOff()
    {
        isAttackOn = false;
    }

    //����� IsAttackOn() ���������� �������� ���������� isAttackOn
    public bool IsAttackOn()
    {
        return isAttackOn;
    }

    // ����� Collision ������� 
    // ���� ���������� trigger collision � ��������, ������� ��� Enemy (� ����� ������, ��� ���������� �������� ����� ����� � �����������)
    // �����, ���������� ������ DamageDealerScript ���� �����. ���� ��� �������, ����� ������� �����������. 
    // ���� ����, ����� ���������� ����� �������� ����� ������� ������ �� ������� DamageDealerScript ����� GetDamage().ToString()
    // ����������� �������� ������� ������ 
    // �������� ����� ��������� � ����� PlayerDeath � ����� PlayerDeath �����������.
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

    // ����� PlayerDeath ��������� �������� damageDealer
    // �� �������� ������ playerHealth ���������� �������� ����� ��������� ����� ���� ������ ������ GetDamage()
    // ����������� ����� Hit(), ���������� ����������� instantiate ������� ��������� �����
    // ���� playerHealth � ���������� ���������� ����� ���������� ������ ��� ����� ����, ����� ����������� ����� Die()
    private void PlayerDeath(DamageDealerScript damageDealer)
    {
        playerHealth -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (playerHealth <= 0)
        {
            Die();
        }
    }

    // ����� Die ���������� ��� ������ ���������
    // ��������� ������ �������� ���������
    // ������� ��������� � ������ ������
    // ��������� �������� ������� ���������� ���� �����
    // ������ 1f ���������� ������
    private void Die()
    {
        GetComponent<PlayerController>().enabled = false;
        enemyAttack.text = "DIED";
        sceneLoader.EndGame();
        StartCoroutine(textCleanCoroutine());
        Destroy(gameObject, 1f);
    }

    // �������� ������� ������ ������ 2f ����� �������
    IEnumerator textCleanCoroutine()
    {
        yield return new WaitForSeconds(2f);
        enemyAttack.text = "";
        StopCoroutine(textCleanCoroutine());
    }

    // ������ ���� �������� �� ������������� healthBar ������ � �� � ����������. 
    // ������������ ��������� slider ������������ ��� UnityEngine.UI
    private void PlayerMaxHealthInitialize()
    {
        healthBarSlider.GetComponent<Slider>().maxValue = playerHealth;
        healthBarSlider.GetComponent<Slider>().value = playerHealth;
    }
    private void PlayerHealthUpdate()
    {
        healthBarSlider.GetComponent<Slider>().value = playerHealth;
    }

    // ������� �������� �������� ��� ����������
    public int GetHealth()
    {
        return playerHealth;
    }
}
