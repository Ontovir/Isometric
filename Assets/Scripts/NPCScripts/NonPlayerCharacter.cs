using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NonPlayerCharacter : MonoBehaviour
{
    [SerializeField] private float healthPoints = 100f;

    [Header("NPC Movement Speed Parameters")]
    [SerializeField] private float npcMoveSpeed = 5f;
    //[SerializeField] private float npcRandomCoordMin = 1f;
    //[SerializeField] private float npcRandomCoordMax = 3f;

    private float xStartPosition;
    private float yStartPosition;
    public GameObject npcGameObject;
    Rigidbody2D npcRigidbody2DComponent;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void StartCoordinates()
    {
        npcRigidbody2DComponent = GetComponent<Rigidbody2D>();
        xStartPosition = GetXSpawnPoint();
        yStartPosition = GetYSpawnPoint();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetMove()
    {
        //if (!IsEnemyOutOfRange(xStartPosition, yStartPosition))
        {
            float xMovePlus = Random.Range(-9f, 9f);
            float yMovePlus = Random.Range(-9f, 9f);
            Vector2 moveVector = new Vector2(xMovePlus, yMovePlus);

            npcRigidbody2DComponent.transform.position = Vector2.MoveTowards
                (transform.position, moveVector, npcMoveSpeed * Time.deltaTime);
        }
        //else
        //{
          //  Vector2 startVector = new Vector2(xStartPosition, yStartPosition);
            //npcRigidbody2DComponent.transform.position = Vector2.MoveTowards
              //  (transform.position, startVector, npcMoveSpeed * Time.deltaTime);
        //}
    }

    private bool IsEnemyOutOfRange(float xStart, float yStart)
    {
        float enemyXPosNow = npcGameObject.transform.position.x;
        float enemyYPosNow = npcGameObject.transform.position.y; 
        float xStartPos = xStart;
        float yStartPos = yStart;
        if ((enemyXPosNow + enemyYPosNow) >= (xStartPos + yStartPos))
        {
            return true;
        }
        else return false;
    }

    private float GetXSpawnPoint()
    {
        float xPos = GetComponent<Transform>().position.x;
        return xPos;
    }
    private float GetYSpawnPoint()
    {
        float yPos = GetComponent<Transform>().position.y;
        return yPos;
    }
}
