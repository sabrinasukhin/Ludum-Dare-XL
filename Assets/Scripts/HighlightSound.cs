using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightSound : MonoBehaviour
{
    public AudioSource audioSource;

    public void PlayHLSound()
    {
        audioSource.Play();
    }
}