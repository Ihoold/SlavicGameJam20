using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public AudioMixer aduioMixer;
    public Slider slider; 

    public void Start() {
        slider.value = PlayerPrefs.GetFloat("Volume", 1f);
        aduioMixer.SetFloat("Volume", Mathf.Log10(slider.value) * 20);
    }

    public void Back() {
        SceneManager.LoadScene("Menu");
    }

    public void SetVolume(float volume) {
        PlayerPrefs.SetFloat("Volume", volume);
        aduioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
    }

    void Update() {
        if (Input.GetButtonDown("Cancel")) {
            Back();
        }
    }
}
