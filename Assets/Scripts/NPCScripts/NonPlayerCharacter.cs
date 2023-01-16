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
    public bool autoMove = true;
    public void StartCoordinates()
    {
        xStartPosition = spawningPoint.transform.position.x;
        yStartPosition = spawningPoint.transform.position.y;
    }

    public void GetMove()
    {
        StartCoroutine(GetRandomMovementPoint());
        float moveSpeed = npcMoveSpeed * Time.deltaTime;
        Debug.Log(xRandom);
        Debug.Log(yRandom);
        Vector2 moveVector = new Vector2(xStartPosition + xRandom, yStartPosition + yRandom);
        transform.position = Vector2.MoveTowards(transform.position, moveVector, moveSpeed);
    }
    IEnumerator GetRandomMovementPoint()
    {
        while (autoMove)
        {
            xRandom = Random.Range(-20, 20);
            yRandom = Random.Range(-20, 20);
            yield return new WaitForSeconds(5f);
        }
    }
}
