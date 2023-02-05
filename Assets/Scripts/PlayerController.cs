using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Скрипт управления персонажем. 
public class PlayerController : MonoBehaviour
{
    // Управление с использованием Rigidbody. 
    // Можно настраивать скорость передвижения персонажа с использованием переменной playerSpeed;
    private Rigidbody2D playerRigidbody2DComponent;
    public float playerSpeed = 1f;

    // Start is called before the first frame update

    // Присваиваю Rigidbody к переменной, которая используется при передвижении персонажа
    void Start()
    {
        playerRigidbody2DComponent = GetComponent<Rigidbody2D>();
    }
    

    // В update вызываю метод, отвечающий за движение персонажа

    // Update is called once per frame
    void Update()
    {
        GetMove();
    }


    // Метод GetMove() отвечает за контроль персонажа
    // за счёт изменения параметра position у компонента Rigidbody2D.
    // Переменная playerSpeed отвечает за скорость перемещения в пространстве
    // Time.deltaTime для унификации передвижения на системах с разной производительностью
    private void GetMove()
    {
        Vector2 playerMoveInput = new Vector2
            (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        playerRigidbody2DComponent.MovePosition
            (playerRigidbody2DComponent.position + playerMoveInput * playerSpeed * Time.deltaTime); 
    }

    //Этот код с корутиной отвечает за переход на другую сцену.
    //Здесь я его закомментировал, т.к. он не используется в текущей игровой сцене
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Next")
        {
            GetComponent<PlayerController>().enabled = false;
            StartCoroutine(LoadNextScene());
        }
    }
    // Корутина запускается при коллижне персонажа с триггер-зоной
    // Отвечает за переход к конечной сцене
    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(2);
        GetComponent<PlayerController>().enabled = true;
        StopCoroutine(LoadNextScene());
    }

    // Метод возвращает значение скорости передвижения персонажа в UI
    public float GetSpeed()
    {
        return playerSpeed;
    }
}   
