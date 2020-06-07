using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RestartButtonManager : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("Main_mouse"); // loads current scene
    }
}