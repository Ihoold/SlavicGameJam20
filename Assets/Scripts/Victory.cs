using UnityEngine;
using UnityEngine.SceneManagement;


public class Victory : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            var soundEffect = GetComponent<AudioSource>();
            soundEffect.volume = PlayerPrefs.GetFloat("Volume", 1f);
            soundEffect.Play();
            Invoke("NextScene", soundEffect.clip.length);
        }
    }

    void NextScene() {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings);
    }
}
