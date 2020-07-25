using UnityEngine;
using UnityEngine.SceneManagement;


public class Victory : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            // TODO: play some cheering sound effect
            // TODO: it should go to Menu scene or next level, not reset the current one
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
