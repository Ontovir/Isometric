using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : NonPlayerCharacter
{

    // ����� Start ��������� ����� StartCoordinates �� ������������ ������ NonPlayerCharacter
    // � �������� �������� StartMove

    // Start is called before the first frame update
    void Start()
    {
        StartCoordinates();
        StartCoroutine(StartMove());
    }

    // � ������ Update ����������� ����� Movement �� ������ NonPlayerCharacter
    // ����� Movement �������� �� ������� �������� NPC � ����� �����������

    // Update is called once per frame
    void Update()
    {
        Movement();
    }


    // �������� StartMove �������� �������� ����� GetRandomCoordinates ������ NonPlayerCharacter
    // ���������� ����� ���������� � ������ 0.5f ������� ����������� ��������. 
    // �������� ��������, ������ 0.5f ������ ���������� ����� ���������� � NPC �������� � ���.
    IEnumerator StartMove()
    {
        while (1 > 0)
        {
            GetRandomCoordinates();
            yield return new WaitForSeconds(0.5f);
            StopNPCAnimation();
        }
    }

}
