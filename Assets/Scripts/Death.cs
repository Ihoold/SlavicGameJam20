using UnityEngine.SceneManagement;
using UnityEngine;

public class Death : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("GoToLevel", 5);
    }
    
    void GoToLevel() {
        SceneManager.LoadScene("Level1");
    }

    void Update() {
        if (Input.GetButtonDown("Cancel") || Input.GetButtonDown("Fire1")) {
            GoToLevel();
        }
    }
}
