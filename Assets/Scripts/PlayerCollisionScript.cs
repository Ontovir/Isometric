using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//������ �������� �� Game Object Player
public class PlayerCollisionScript : MonoBehaviour
{
    //SerializeField ��� ������ TextMeshPro, ������� ����� ����������, ��� ��������� �������.
    //������������� ������� TextMeshPro ������ � Unity � ����� �������.
    [SerializeField] TextMeshProUGUI text;

    //����� OnCollisionEnter2D ��������� ����� ������ � ������� ������� ��������.
    //���� ������ ����� ��� "Enemy", �� ����������� ����� CollisionText � �������� TextClear.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            CollisionText();
            StartCoroutine(TextClear());
        }
    }

    //����� CollisionText ��������� �������� �� ����� (� ������� TextMeshPro) � � ������� �����
    private void CollisionText()
    {
        Debug.Log("Collision happened");
        text.text = "Collision happened!";
    }

    //�������� TextClear ����� ��� ����, ����� �������� ������� TextMeshPro ������ 2 ������� ����� ��������������
    IEnumerator TextClear()
    {
        yield return new WaitForSeconds(2f);
        text.text = "";
        StopCoroutine(TextClear());
    }
}
