using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    int scene = 0;

    private void Start()
    {

    }

    public void GetNewScene()
    {
        scene++;
        SceneManager.LoadScene(scene);
    }
    public void EndGame()
    {
        SceneManager.LoadScene(2);
    }
}
