using UnityEngine;
using UnityEngine.Audio;

public class ControlVolume : MonoBehaviour {
    public AudioMixer mixer;

    public void SetVolume(float val) {
        mixer.SetFloat("VolumeControl", Mathf.Log10(val) * 20);
    }
}