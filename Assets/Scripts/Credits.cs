
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("GoToMenu", 60);
    }
    
    void GoToMenu() {
        SceneManager.LoadScene("Menu");
    }

    void Update() {
        if (Input.GetButtonDown("Cancel")) {
            GoToMenu();
        }
    }
}
