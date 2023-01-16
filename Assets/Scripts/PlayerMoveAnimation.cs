using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ������, ���������� �� ��������� �������� ���������
public class PlayerMoveAnimation : MonoBehaviour
{
    // ������ ���������� ������ Animator
    private Animator playerAnimator;

    // ���������� ���������� ��������
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // � update ������� ����� MovementUpdate(), �������
    // �������� �� ���������� ������� �������� � �����������
    // �� ������� ������ ����������, ������� �������� ������������

    // Update is called once per frame
    void Update()
    {
        MovementUpdate();
    }


    // ������������ �����, ����� � Update ����� �� ������
    private void MovementUpdate()
    {
        IfWDown();
        IfDDown();
        IfSDown();
        IfADown();
        IfWDown();
        IfWDDown();
        IfSDDown();
        IfASDown();
        IfAWDown();
    }

    // ������ ���� ����������, ����� ������� ���������� ������
    // � ����������� �� �����, ��� �������� ���������� bool �� ���������
    // � ����������� �� ��������. ���� ������� ������ - true,
    // ���� ���, ����� - false. Bool �������� ��������.
    private void IfWDown()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerAnimator.SetBool("IsWDown", true);
        }
        else
        {
            playerAnimator.SetBool("IsWDown", false);
        }
    }

    private void IfDDown()
    {
        if (Input.GetKey(KeyCode.D))
        {
            playerAnimator.SetBool("IsDDown", true);

        }
        else
        {
            playerAnimator.SetBool("IsDDown", false);
        }
    }
    private void IfSDown()
    {
        if (Input.GetKey(KeyCode.S))
        {
            playerAnimator.SetBool("IsSDown", true);
        }
        else
        {
            playerAnimator.SetBool("IsSDown", false);
        }
    }
    private void IfADown()
    {
        if (Input.GetKey(KeyCode.A))
        {
            playerAnimator.SetBool("IsADown", true);
        }
        else
        {
            playerAnimator.SetBool("IsADown", false);
        }
    }
    private void IfWDDown()
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            playerAnimator.SetBool("IsDDown", false);
            playerAnimator.SetBool("IsWDown", false); 
            playerAnimator.SetBool("IsWDDown", true);
            
        }
        else
        {
            playerAnimator.SetBool("IsWDDown", false);
        }
    }
    private void IfSDDown()
    {
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            playerAnimator.SetBool("IsSDown", false);
            playerAnimator.SetBool("IsDDown", false);
            playerAnimator.SetBool("IsSDDown", true);
        }
        else
        {
            playerAnimator.SetBool("IsSDDown", false);
        }
    }
    private void IfASDown()
    {
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            playerAnimator.SetBool("IsADown", false);
            playerAnimator.SetBool("IsSDown", false);
            playerAnimator.SetBool("IsASDown", true);
        }
        else
        {
            playerAnimator.SetBool("IsASDown", false);
        }
    }
    private void IfAWDown()
    {
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {
            playerAnimator.SetBool("IsADown", false);
            playerAnimator.SetBool("IsWDown", false);
            playerAnimator.SetBool("IsAWDown", true);
        }
        else
        {
            playerAnimator.SetBool("IsAWDown", false);
        }
    }
}
