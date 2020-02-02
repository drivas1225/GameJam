using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class skipMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(2);
    }
    public void FinishGame()
    {
        SceneManager.LoadScene(3);

    }
}

