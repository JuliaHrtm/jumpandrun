using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;

public class ControlVolume : MonoBehaviour
{
    public AudioMixer Mixer;

    public void SetVolume(float val)
    {
        Mixer.SetFloat("VolumeControl", Mathf.Log10 (val) * 20);
    }
}
