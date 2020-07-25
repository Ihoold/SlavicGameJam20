using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public AudioMixer audio;
    public Slider slider; 

    public void Start() {
        float vol;
        audio.GetFloat("Volume", out vol);
        slider.value = vol;
    }

    public void Back() {
        Debug.Log("LoadScene");
        SceneManager.LoadScene("Menu");
    }

    public void SetVolume(float volume) {
        audio.SetFloat("Volume", volume);
    }

    void Update() {
        if (Input.GetButtonDown("Cancel")) {
            Back();
        }
    }
}
