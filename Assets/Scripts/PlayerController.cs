using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// —крипт управлени€ персонажем. 
public class PlayerController : MonoBehaviour
{
    // ”правление с использованием Rigidbody. 
    // ћожно настраивать скорость передвижени€ персонажа с использованием переменной playerSpeed;
    private Rigidbody2D playerRigidbody2DComponent;
    public float playerSpeed = 1f;

    // Start is called before the first frame update

    // ѕрисваиваю Rigidbody к переменной, котора€ используетс€ при передвижении персонажа
    void Start()
    {
        playerRigidbody2DComponent = GetComponent<Rigidbody2D>();
    }
    

    // ¬ update вызываю метод, отвечающий за движение персонажа

    // Update is called once per frame
    void Update()
    {
        GetMove();
    }


    // ћетод GetMove() отвечает за контроль персонажа
    // за счЄт изменени€ параметра position у компонента Rigidbody2D.
    // ѕеременна€ playerSpeed отвечает за скорость перемещени€ в пространстве
    // Time.deltaTime дл€ унификации передвижени€ на системах с разной производительностью
    private void GetMove()
    {
        Vector2 playerMoveInput = new Vector2
            (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        playerRigidbody2DComponent.MovePosition
            (playerRigidbody2DComponent.position + playerMoveInput * playerSpeed * Time.deltaTime); 
    }

    //Ётот код с корутиной отвечает за переход на другую сцену.
    /* private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<PlayerController>().enabled = false;
        StartCoroutine(LoadNextScene());
    }
    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
        GetComponent<PlayerController>().enabled = true;
        StopCoroutine(LoadNextScene());
    }
    */
}   
