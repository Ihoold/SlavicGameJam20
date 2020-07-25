﻿using UnityEngine;
using UnityEngine.SceneManagement;


public class Victory : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            var soundEffect = GetComponent<AudioSource>();
            soundEffect.Play();
            Invoke("NextScene", soundEffect.clip.length);
        }
    }

    void NextScene() {
        Debug.Log(SceneManager.GetActiveScene().buildIndex + " " + SceneManager.sceneCountInBuildSettings);
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings);
    }
}
