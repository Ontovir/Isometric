using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NonPlayerCharacter : MonoBehaviour
{
    [SerializeField] private float healthPoints = 100f;
    [SerializeField] GameObject spawningPoint;

    [Header("NPC Movement Speed Parameters")]
    [SerializeField] private float npcMoveSpeed = 5f;

    private float xStartPosition;
    private float yStartPosition;
    private float xRandom;
    private float yRandom;
    private Animator npcAnimation;
    public void StartCoordinates()
    {
        npcAnimation = GetComponent<Animator>();
        xStartPosition = spawningPoint.transform.position.x;
        yStartPosition = spawningPoint.transform.position.y;
    }

   public void GetRandomCoordinates()
    {
        xRandom = Random.Range(-1f, 1f);
        yRandom = Random.Range(-1f, 1f);
        MovementAnimation();

    }

    public void Movement()
    {
        float moveSpeed = npcMoveSpeed * Time.deltaTime;
        Vector3 moveVector = new Vector3(xStartPosition + xRandom, yStartPosition + yRandom, 0f);
        GetComponent<Rigidbody2D>().transform.position = Vector3.MoveTowards(transform.position, moveVector, moveSpeed);
    }

    private void MovementAnimation()
    {
        if (xRandom > 0 && yRandom > 0)
        {
            npcAnimation.SetBool("IsWDDown", true);
        }

        if (xRandom < 0 && yRandom > 0)
        {
            npcAnimation.SetBool("IsAWDown", true);
        }

        if (xRandom < 0 && yRandom < 0)
        {
            npcAnimation.SetBool("IsASDown", true);
        }

        if (xRandom > 0 && yRandom < 0)
        {
            npcAnimation.SetBool("IsSDDown", true);
        }

        if (xRandom > 0 && yRandom == 0)
        {
            npcAnimation.SetBool("IsDDown", true);
        }

        if (xRandom < 0 && yRandom == 0)
        {
            npcAnimation.SetBool("IsADown", true);
        }

        if (xRandom == 0 && yRandom > 0)
        {
            npcAnimation.SetBool("IsWDown", true);
        }
        if (xRandom == 0 && yRandom < 0)
        {
            npcAnimation.SetBool("IsSDown", true);
        }


    }

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
