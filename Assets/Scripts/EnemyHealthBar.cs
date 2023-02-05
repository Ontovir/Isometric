using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    // ���������, � ������ ����� ����������� ���� ���������� healthBar
    [SerializeField] GameObject enemyObject;

    // ���������� ������ EnemyHealthBar
    // HealthBarScale � ����������� ������� ������ � �������� HealthBar �� ��� X
    // enemy ���������� ��� ������ ������� EnemyScript, � ������� ���������� ���������� � �������� ����������� �����
    // float maxHealth ����� ��� ������� �������� ������������� HealthBar'a
    Vector2 healthBarScale;
    EnemyScript enemy;
    private float maxHealth;

    // ��������� ������ � ������� �������� ��� HealthBar
    // Start is called before the first frame update
    void Start()
    {
        AddHealthBarScale();
    }

    // ��������� ���� � �������� health bar �� ��� X
    // Update is called once per frame
    void Update()
    {
        HealthBarUpdate();   
    }


    // ����� HealthBarUpdate ����� ��� ���������� ���������� �� ������ �������� NPC
    // � ���������� Vector2 healthBarScale ����������� ���������� � ������� �������� �������
    // ���������� ������ nowHealth ������������� ��������. ���������� ����� ������ EnemyHealth �� ������� EnemyScript, 
    // ������� ������� �������� �� EnemyHealth ������� �� ��������� ������� �������� maxHealth
    // ���� nowHealth ������ ��� ����� ����, ����� �������� healthBarScale �� ��� X ������������� �������� �� ���������� nowHealth 
    // ���������� �������� �� 0f �� 1f
    // ������� ������� ���������� ����������� healthBarScale
    // � ��������� ������, ���� �������� nowHealth ����� �������������, ����� ���������� nowHealth ������������� 0
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

    // ����� AddHealthBarScale ��������� ������� ��������� ����������� healthBar ��� ��������� �����
    // ���������� EnemyScript enemy ������������� �������� EnemyScript �� ������������ � SerializeField �������� ������� �����
    // ���������� maxHealth ������������� �������� �������� �� ������� enemy ������� EnemyHealth()
    // ����� � �������� �����, ��� ��������
    // Vector3 newPos ����� ��� ����������� ���������������� HealthBar ��� ��������� �����
    private void AddHealthBarScale()
    {
        enemy = enemyObject.GetComponent<EnemyScript>();
        maxHealth = enemy.EnemyHealth();
        Debug.Log(maxHealth);
        Vector3 newPos = new Vector3(0f, 30f, 0f);
        transform.position = enemyObject.transform.position + newPos*Time.deltaTime;
    }
}
