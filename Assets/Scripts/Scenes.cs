using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class Scenes : MonoBehaviour
{
    public void Start_Game()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit_Game()
    {
        SceneManager.LoadScene(0);
    }
}
