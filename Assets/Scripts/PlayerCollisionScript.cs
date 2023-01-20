using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Скрипт вешается на Game Object Player
public class PlayerCollisionScript : MonoBehaviour
{
    //SerializeField для текста TextMeshPro, который будет показывать, что произошёл коллижн.
    //Привязывается элемент TextMeshPro холста в Unity к этому скрипту.
    [SerializeField] TextMeshProUGUI text;

    //Метод OnCollisionEnter2D запускает показ текста с помощью булевой проверки.
    //Если объект имеет тэг "Enemy", то запускается метод CollisionText и корутина TextClear.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            CollisionText();
            StartCoroutine(TextClear());
        }
    }

    //Метод CollisionText позволяет выводить на экран (в элемент TextMeshPro) и в консоль текст
    private void CollisionText()
    {
        Debug.Log("Collision happened");
        text.text = "Collision happened!";
    }

    //Корутина TextClear нужна для того, чтобы очистить элемент TextMeshPro спустя 2 секунды после взаимодействия
    IEnumerator TextClear()
    {
        yield return new WaitForSeconds(2f);
        text.text = "";
        StopCoroutine(TextClear());
    }
}
