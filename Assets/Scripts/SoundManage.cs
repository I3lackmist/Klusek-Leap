using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SoundManage : MonoBehaviour {
    [SerializeField] AudioClip fall, scratch;
    [SerializeField] AudioClip[] meows,bonk;
    [SerializeField] AudioSource source;

    private void Start() {
        if (!PlayerPrefs.HasKey("Mute")) {
            PlayerPrefs.SetInt("Mute", -1);
        }
        if (PlayerPrefs.GetInt("Mute") == 1) source.mute = true;
        else if (PlayerPrefs.GetInt("Mute") == -1) source.mute = false;
    }

    public void Meow() {
        source.PlayOneShot(meows[Random.Range(0,meows.Length)]);
    }
    public void Fall() {
        source.PlayOneShot(fall);

    }
    public void Mute() {
        source.mute = !source.mute;
        PlayerPrefs.SetInt("Mute", PlayerPrefs.GetInt("Mute") * -1); 
    }
    public void Bonk() {
        source.PlayOneShot(bonk[Random.Range(0,bonk.Length)]);
    }
    public void Scratch() {
        source.PlayOneShot(scratch);
    }
}
