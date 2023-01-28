using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NonPlayerCharacter : MonoBehaviour
{
    //ќсновные пол€, которые задают здоровье и стартовую позицию NPC
    //ћожно расширить их будет, добавить атаку (тип), броню, ману или что-то такое
    //Spawning point €вл€етс€ игровым объектом и прив€зываетс€ к NPC в Unity

    [Header("NPC Main parameters")]

    [SerializeField] GameObject spawningPoint;

    //«десь пока что назначаю скорость, с которой передвигаетс€ NPC

    [Header("NPC Movement Speed Parameters")]
    [SerializeField] private float npcMoveSpeed = 5f;

    //Ёти переменные (xStartPosition, yStartPosition) определ€ют стартовую позицию NPC.
    //ќт стартовой позиции высчитываетс€ направление и рассто€ние, на которое NPC может двигатьс€.

    private float xStartPosition;
    private float yStartPosition;

    //Ёти переменные (xRandom, yRandom) нужны дл€ присвоени€ случайного значени€.
    //¬ зависимости от того, какие значени€ будут присвоены этим переменным
    //NPC будет двигатьс€ в определЄнном направлении, а так же будет происходить анимаци€ движени€.

    private float xMoveRandom;
    private float yMoveRandom;

    //Ёта переменна€ (npcAnimator) нужна дл€ анимации движени€ NPC

    private Animator npcAnimation;

    //ћетод StartCoordinates определ€ет значени€ дл€ переменных (координаты стартовой позиции)
    //и запускает метод поиска компонента Animator у NPC. 
    //ћетод Public, т.к. он вызываетс€ в наследнике - в EnemyScript
    public void StartCoordinates()
    {
        GetAnimatorComponent();
        xStartPosition = spawningPoint.transform.position.x;
        yStartPosition = spawningPoint.transform.position.y;
    }

    //ћетод дл€ поиска компонента Animator у NPC
    private void GetAnimatorComponent()
    {
        npcAnimation = GetComponent<Animator>();
    }

    //ћетод GetRandomCoordinates отвечает за создание новых координат дл€ движени€ NPC
    //ќн также запускает метод анимации движени€ NPC npcMovementAnimation
    public void GetRandomCoordinates()
    {
        xMoveRandom = Random.Range(-1f, 1f);
        yMoveRandom = Random.Range(-1f, 1f);
        npcMovementAnimation();

    }


    //ћетод Movement отвечает за плавное движение NPC к новым координатам
    public void Movement()
    {
        // —начала с помощью Time.deltaTime сглаживаем скорость движени€ на машинах с разной производительностью
        // ѕотом создаЄм вектор, имеющий новые координаты, основанные на стартовой позиции NPC
        // ЅерЄм RigidBody2D нашего NPC и двигаем с помощью метода Vector3.MoveTowards на новую позицию 

        float moveSpeed = npcMoveSpeed * Time.deltaTime;
        Vector3 moveVector = new Vector3(xStartPosition + xMoveRandom, yStartPosition + yMoveRandom, 0f);
        GetComponent<Rigidbody2D>().transform.position = Vector3.MoveTowards(transform.position, moveVector, moveSpeed);
    }


    // ћетод npcMovementAnimation определ€ет, какой тип анимации должен быть активирован
    // в зависимости от того, какие координаты были сгенерированы GetRandomCoordinates.
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

    // открытый метод StopNPCAnimation останавливает анимацию движени€ NPC и включает Idle анимацию
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
