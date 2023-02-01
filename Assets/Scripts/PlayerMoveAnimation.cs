using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// —крипт, отвечающий за изменение анимации персонажа
public class PlayerMoveAnimation : MonoBehaviour
{
    // —оздаю переменную класса Animator
    private Animator playerAnimator;
    private PlayerAttack knowAttackStatus;
    // ѕрисваиваю переменной значение
    void Start()
    {
        knowAttackStatus = GetComponent<PlayerAttack>();
        playerAnimator = GetComponent<Animator>();
    }

    // ¬ update вызываю метод MovementUpdate(), который
    // отвечает за обновление статуса анимации в зависимости
    // от нажати€ клавиш управлени€, которые нажимает пользователь

    // Update is called once per frame
    void Update()
    {
        MovementUpdate();
        AttackUpdate();
    }


    // √руппирующий метод, чтобы в Update много не пихать
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

    // ћетоды ниже определ€ют, какие клавиши управлени€ нажаты
    // ¬ зависимости от этого, они вызывают переменные bool из аниматора
    // и присваивают им значение. ≈сли клавиша нажата - true,
    // если нет, тогда - false. Bool измен€ют анимацию.
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
