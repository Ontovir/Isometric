using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// ������ ���������� ����������. 
public class PlayerController : MonoBehaviour
{
    // ���������� � �������������� Rigidbody. 
    // ����� ����������� �������� ������������ ��������� � �������������� ���������� playerSpeed;
    private Rigidbody2D playerRigidbody2DComponent;
    public float playerSpeed = 1f;

    // Start is called before the first frame update

    // ���������� Rigidbody � ����������, ������� ������������ ��� ������������ ���������
    void Start()
    {
        playerRigidbody2DComponent = GetComponent<Rigidbody2D>();
    }
    

    // � update ������� �����, ���������� �� �������� ���������

    // Update is called once per frame
    void Update()
    {
        GetMove();
    }


    // ����� GetMove() �������� �� �������� ���������
    // �� ���� ��������� ��������� position � ���������� Rigidbody2D.
    // ���������� playerSpeed �������� �� �������� ����������� � ������������
    // Time.deltaTime ��� ���������� ������������ �� �������� � ������ �������������������
    private void GetMove()
    {
        Vector2 playerMoveInput = new Vector2
            (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        playerRigidbody2DComponent.MovePosition
            (playerRigidbody2DComponent.position + playerMoveInput * playerSpeed * Time.deltaTime); 
    }

    //���� ��� � ��������� �������� �� ������� �� ������ �����.
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
