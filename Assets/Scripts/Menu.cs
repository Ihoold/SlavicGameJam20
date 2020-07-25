﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    
    public void Play() {
        SceneManager.LoadScene("PrototypeScene");
    }

    public void Options() {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void Quit() {
        Application.Quit();
    }
}
