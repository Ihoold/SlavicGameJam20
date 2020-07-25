using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public AudioMixer aduioMixer;
    public Slider slider; 

    public void Start() {
        float vol;
        aduioMixer.GetFloat("Volume", out vol);
        slider.value = vol;
    }

    public void Back() {
        SceneManager.LoadScene("Menu");
    }

    public void SetVolume(float volume) {
        aduioMixer.SetFloat("Volume", volume);
    }

    void Update() {
        if (Input.GetButtonDown("Cancel")) {
            Back();
        }
    }
}
