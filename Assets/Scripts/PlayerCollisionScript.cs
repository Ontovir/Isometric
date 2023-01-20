using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCollisionScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            CollisionText();
            StartCoroutine(TextClear());
        }
    }

    private void CollisionText()
    {
        Debug.Log("Collision happened");
        text.text = "Collision happened!";
    }

    IEnumerator TextClear()
    {
        yield return new WaitForSeconds(2f);
        text.text = "";
        StopCoroutine(TextClear());
    }
}
