using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    public AudioSource _audio;

    public void Play()
    {
        _audio.Play();
    }
}
