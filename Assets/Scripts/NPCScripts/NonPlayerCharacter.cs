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
    public void StartCoordinates()
    {
        xStartPosition = spawningPoint.transform.position.x;
        yStartPosition = spawningPoint.transform.position.y;
    }

   /* public void GetMove()
    {

        float moveSpeed = npcMoveSpeed * Time.deltaTime;
        Debug.Log(xRandom);
        Debug.Log(yRandom);
        Vector2 moveVector = new Vector2(xStartPosition + xRandom, yStartPosition + yRandom);
        transform.position = Vector2.MoveTowards(transform.position, moveVector, moveSpeed);
    } */
   public void GetRandomCoordinates()
    {
        xRandom = Random.Range(-1f, 1f);
        yRandom = Random.Range(-1f, 1f);
    }

    public void Movement()
    {
        float moveSpeed = npcMoveSpeed * Time.deltaTime;
        Vector3 moveVector = new Vector3(xStartPosition + xRandom, yStartPosition + yRandom, 0f);
        GetComponent<Rigidbody2D>().transform.position = Vector3.MoveTowards(transform.position, moveVector, moveSpeed);
    }
}
