using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    // Скрипт, отвечающий за переход между сценами
    int scene = 0;
    public void GetNewScene()
    {
        scene++;
        SceneManager.LoadScene(scene);
    }
    public void EndGame()
    {
        SceneManager.LoadScene(3);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
