using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{   
    private AudioSource audioSource;
    [SerializeField] AudioClip dotSound;
    [SerializeField] AudioClip dashSound;
   

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayDotSound()
    {
        audioSource.PlayOneShot(dotSound);
    }
    public void PlayDashSound()
    {
        audioSource.PlayOneShot(dashSound);
    }
    
}
