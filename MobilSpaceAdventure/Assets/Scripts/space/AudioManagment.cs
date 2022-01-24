using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagment : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip[] sounds;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Bullet()
    {
        audioSource.PlayOneShot(sounds[0]);
    }

    public void Coin()
    {
        audioSource.PlayOneShot(sounds[1]);
    }
}
