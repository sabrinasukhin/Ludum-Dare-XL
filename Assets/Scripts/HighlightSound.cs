using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightSound : MonoBehaviour
{
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayHLSound()
    {
        audioSource.Play();
    }
}