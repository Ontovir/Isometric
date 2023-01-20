using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : NonPlayerCharacter
{

    // ћетод Start загружает метод StartCoordinates из абстрактного класса NonPlayerCharacter
    // и начинает корутину StartMove

    // Start is called before the first frame update
    void Start()
    {
        StartCoordinates();
        StartCoroutine(StartMove());
    }

    // ¬ методе Update загружаетс€ метод Movement из класса NonPlayerCharacter
    // ћетод Movement отвечает за плавное движение NPC к новым координатам

    // Update is called once per frame
    void Update()
    {
        Movement();
    }


    //  орутина StartMove вызывает открытый метод GetRandomCoordinates класса NonPlayerCharacter
    // ѕо€вл€ютс€ новые координаты и спуст€ 0.5f секунды отключаетс€ анимаци€. 
    //  орутина циклична, каждые 0.5f секунд по€вл€ютс€ новые координаты и NPC движетс€ к ним.
    IEnumerator StartMove()
    {
        while (1 > 0)
        {
            GetRandomCoordinates();
            yield return new WaitForSeconds(0.5f);
            StopNPCAnimation();
        }
    }

}
