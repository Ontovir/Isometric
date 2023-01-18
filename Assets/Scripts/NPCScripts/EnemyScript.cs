using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : NonPlayerCharacter
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoordinates();
        StartCoroutine(StartMove());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator StartMove()
    {
        while (1 > 0)
        {
            GetMove();
            yield return new WaitForSeconds(1f);
        }
    }

}
