using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageDealerScript : MonoBehaviour
{
    // ������ ������������ � �������� �������� �����
    
    // ��������� �������� ����� int
    [SerializeField] int damage = 100;

    // ����� GetDamage() ���������� �������� int damage
    // ������������ ��� ��������� ����� NPC ��� ������
    public int GetDamage()
    {
        return damage;
    }
    // ����� Hit() ����������, ����� ���������� Collision �������� ����� � NPC ��� �������. 
    // ��� ������ ���������� ����� �������, �� ������� ����� ���� ������
    public void Hit()
    {
        Destroy(gameObject);
    }
}
