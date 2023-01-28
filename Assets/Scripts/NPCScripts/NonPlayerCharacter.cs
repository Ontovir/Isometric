using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NonPlayerCharacter : MonoBehaviour
{
    //�������� ����, ������� ������ �������� � ��������� ������� NPC
    //����� ��������� �� �����, �������� ����� (���), �����, ���� ��� ���-�� �����
    //Spawning point �������� ������� �������� � ������������� � NPC � Unity

    [Header("NPC Main parameters")]

    [SerializeField] GameObject spawningPoint;

    //����� ���� ��� �������� ��������, � ������� ������������� NPC

    [Header("NPC Movement Speed Parameters")]
    [SerializeField] private float npcMoveSpeed = 5f;

    //��� ���������� (xStartPosition, yStartPosition) ���������� ��������� ������� NPC.
    //�� ��������� ������� ������������� ����������� � ����������, �� ������� NPC ����� ���������.

    private float xStartPosition;
    private float yStartPosition;

    //��� ���������� (xRandom, yRandom) ����� ��� ���������� ���������� ��������.
    //� ����������� �� ����, ����� �������� ����� ��������� ���� ����������
    //NPC ����� ��������� � ����������� �����������, � ��� �� ����� ����������� �������� ��������.

    private float xMoveRandom;
    private float yMoveRandom;

    //��� ���������� (npcAnimator) ����� ��� �������� �������� NPC

    private Animator npcAnimation;

    //����� StartCoordinates ���������� �������� ��� ���������� (���������� ��������� �������)
    //� ��������� ����� ������ ���������� Animator � NPC. 
    //����� Public, �.�. �� ���������� � ���������� - � EnemyScript
    public void StartCoordinates()
    {
        GetAnimatorComponent();
        xStartPosition = spawningPoint.transform.position.x;
        yStartPosition = spawningPoint.transform.position.y;
    }

    //����� ��� ������ ���������� Animator � NPC
    private void GetAnimatorComponent()
    {
        npcAnimation = GetComponent<Animator>();
    }

    //����� GetRandomCoordinates �������� �� �������� ����� ��������� ��� �������� NPC
    //�� ����� ��������� ����� �������� �������� NPC npcMovementAnimation
    public void GetRandomCoordinates()
    {
        xMoveRandom = Random.Range(-1f, 1f);
        yMoveRandom = Random.Range(-1f, 1f);
        npcMovementAnimation();

    }


    //����� Movement �������� �� ������� �������� NPC � ����� �����������
    public void Movement()
    {
        // ������� � ������� Time.deltaTime ���������� �������� �������� �� ������� � ������ �������������������
        // ����� ������ ������, ������� ����� ����������, ���������� �� ��������� ������� NPC
        // ���� RigidBody2D ������ NPC � ������� � ������� ������ Vector3.MoveTowards �� ����� ������� 

        float moveSpeed = npcMoveSpeed * Time.deltaTime;
        Vector3 moveVector = new Vector3(xStartPosition + xMoveRandom, yStartPosition + yMoveRandom, 0f);
        GetComponent<Rigidbody2D>().transform.position = Vector3.MoveTowards(transform.position, moveVector, moveSpeed);
    }


    // ����� npcMovementAnimation ����������, ����� ��� �������� ������ ���� �����������
    // � ����������� �� ����, ����� ���������� ���� ������������� GetRandomCoordinates.
    private void npcMovementAnimation()
    {
        if (xMoveRandom > 0 && yMoveRandom > 0)
        {
            npcAnimation.SetBool("IsWDDown", true);
        }

        if (xMoveRandom < 0 && yMoveRandom > 0)
        {
            npcAnimation.SetBool("IsAWDown", true);
        }

        if (xMoveRandom < 0 && yMoveRandom < 0)
        {
            npcAnimation.SetBool("IsASDown", true);
        }

        if (xMoveRandom > 0 && yMoveRandom < 0)
        {
            npcAnimation.SetBool("IsSDDown", true);
        }

        if (xMoveRandom > 0 && yMoveRandom == 0)
        {
            npcAnimation.SetBool("IsDDown", true);
        }

        if (xMoveRandom < 0 && yMoveRandom == 0)
        {
            npcAnimation.SetBool("IsADown", true);
        }

        if (xMoveRandom == 0 && yMoveRandom > 0)
        {
            npcAnimation.SetBool("IsWDown", true);
        }
        if (xMoveRandom == 0 && yMoveRandom < 0)
        {
            npcAnimation.SetBool("IsSDown", true);
        }


    }

    // �������� ����� StopNPCAnimation ������������� �������� �������� NPC � �������� Idle ��������
    public void StopNPCAnimation()
    {
        npcAnimation.SetBool("IsAWDown", false);
        npcAnimation.SetBool("IsWDown", false);
        npcAnimation.SetBool("IsSDown", false);
        npcAnimation.SetBool("IsASown", false);
        npcAnimation.SetBool("IsWDown", false);
        npcAnimation.SetBool("IsSDown", false);
        npcAnimation.SetBool("IsADown", false);
        npcAnimation.SetBool("IsDDown", false);
    }

}
