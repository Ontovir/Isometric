using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Скрипт, отвечающий за изменение анимации персонажа
public class PlayerMoveAnimation : MonoBehaviour
{
    // Создаю переменную класса Animator
    // Переменная PlayerAttack knowAttackStatus нужна для вызова метода IsAttackOn
    // Таким образом, проверяется статус атаки и при необходимости вызывается анимация атаки
    private Animator playerAnimator;
    private PlayerAttack knowAttackStatus;

    // Присваиваю переменным значения
    void Start()
    {
        knowAttackStatus = GetComponent<PlayerAttack>();
        playerAnimator = GetComponent<Animator>();
    }

    // В update вызываю метод MovementUpdate(), который
    // отвечает за обновление статуса анимации в зависимости
    // от нажатия клавиш управления, которые нажимает пользователь
    // AttackUpdate отвечает за вызов анимации атаки в состоянии Idle

    // Update is called once per frame
    void Update()
    {
        MovementUpdate();
        AttackUpdate();
    }


    // Группирующий метод, чтобы в Update много не пихать
    // В конце вызывает метод, сбрасывающий булевы переменные анимации атаки в аниматоре
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
        Invoke("AttackAnimationOff", 0.1f);
    }

    // Группирующий метод AttackUpdate вызывает анимации атаки в состоянии Idle
    // В конце вызывает метод, сбрасывающий булевы переменные анимации атаки в аниматоре
    private void AttackUpdate()
    {
        IfDAttack();
        IfSAttack();
        IfAAttack();
        IfWAttack();
        IfWDAttack();
        IfSDAttack();
        IfASAttack();
        IfAWAttack();
        Invoke("AttackAnimationOff", 0.1f);
    } 

    // Методы ниже определяют, какие клавиши управления нажаты
    // В зависимости от этого, они вызывают переменные bool из аниматора
    // и присваивают им значение. Если клавиша нажата - true,
    // если нет, тогда - false. Bool изменяют анимацию.
    // для анимации атаки в движении происходит проверка статуса атаки вызовом метода IsAttackOn()
    // если bool == true, тогда вызывается анимация атаки
    private void IfWDown()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerAnimator.SetBool("IsWDown", true);
            if (knowAttackStatus.IsAttackOn())
            {
                playerAnimator.Play("AttackW");
            }
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
            if (knowAttackStatus.IsAttackOn())
            {
                playerAnimator.Play("AttackD");
            }
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
            if (knowAttackStatus.IsAttackOn())
            {
                playerAnimator.Play("AttackS");
            }
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
            if (knowAttackStatus.IsAttackOn())
            {
                playerAnimator.Play("AttackA");
            }
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
            if (knowAttackStatus.IsAttackOn())
            {
                playerAnimator.Play("AttackWD");
            }
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
            if (knowAttackStatus.IsAttackOn())
            {
                playerAnimator.Play("AttackSD");
            }
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
            if (knowAttackStatus.IsAttackOn())
            {
                playerAnimator.Play("AttackAS");
            }
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
            if (knowAttackStatus.IsAttackOn())
            {
                playerAnimator.Play("AttackAW");
            }
        }
        else
        {
            playerAnimator.SetBool("IsAWDown", false);
        }
    }

    //Группа методов, которые я использую для анимации атаки в состоянии idle
    //Attack Animation
    private void IfWDAttack()
    {
        if (knowAttackStatus.IsAttackOn())
        {
            playerAnimator.SetBool("AttackWD", true);
            //playerAnimator.Play("AttackWD");
        }
        else playerAnimator.SetBool("AttackWD", false);
    }
    private void IfDAttack()
    {
        if (knowAttackStatus.IsAttackOn())
        {
            playerAnimator.SetBool("AttackD", true);
            //playerAnimator.Play("AttackD");
        }
        else playerAnimator.SetBool("AttackD", false);
    }
    private void IfSDAttack()
    {
        if (knowAttackStatus.IsAttackOn())
        {
            playerAnimator.SetBool("AttackSD", true);
            //playerAnimator.Play("AttackSD");
        }
        else playerAnimator.SetBool("AttackSD", false);
    }
    private void IfSAttack()
    {
        if (knowAttackStatus.IsAttackOn())
        {
            playerAnimator.SetBool("AttackS", true);
            //playerAnimator.Play("AttackS");
        }
        else playerAnimator.SetBool("AttackS", false);
    }
    private void IfASAttack()
    {
        if (knowAttackStatus.IsAttackOn())
        {
            playerAnimator.SetBool("AttackAS", true);
            //playerAnimator.Play("AttackAS");
        }
        else playerAnimator.SetBool("AttackAS", false);
    }
    private void IfAAttack()
    {
        if (knowAttackStatus.IsAttackOn())
        {
            playerAnimator.SetBool("AttackA", true);
            //playerAnimator.Play("AttackA");
        }
        else playerAnimator.SetBool("AttackA", false);
    }
    private void IfAWAttack()
    {
        if (knowAttackStatus.IsAttackOn())
        {
            playerAnimator.SetBool("AttackAW", true);
            //playerAnimator.Play("AttackAW");
        }
        else playerAnimator.SetBool("AttackAW", false);
    }
    private void IfWAttack()
    {
        if (knowAttackStatus.IsAttackOn())
        {
            playerAnimator.SetBool("AttackW", true);
            //playerAnimator.Play("AttackW");
        }
        else playerAnimator.SetBool("AttackW", false);
    }

    //отключение анимации атаки
    private void AttackAnimationOff()
    {
        playerAnimator.SetBool("AttackWD", false);
        playerAnimator.SetBool("AttackW", false);
        playerAnimator.SetBool("AttackSD", false);
        playerAnimator.SetBool("AttackD", false);
        playerAnimator.SetBool("AttackAS", false);
        playerAnimator.SetBool("AttackS", false);
        playerAnimator.SetBool("AttackAW", false);
        playerAnimator.SetBool("AttackA", false);
    }
}
