using UnityEngine.SceneManagement;
using UnityEngine;

public class Options : MonoBehaviour
{
    public void Back() {
        Debug.Log("LoadScene");
        SceneManager.LoadScene("Menu");
    }

    public void Update() {
        if (Input.GetButtonDown("Cancel")) {
            Back();
        }
    }
}
