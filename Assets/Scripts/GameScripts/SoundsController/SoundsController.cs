using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsController : MonoBehaviour
{
    [SerializeField] AudioClip[] painScreams;
    [SerializeField] AudioClip neakBreak;

    AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayPainSound()
    {
        source.clip = painScreams[Random.Range(0, painScreams.Length)];
        source.Play();
    }

    public void PlayNeakBreak()
    {
        source.clip = neakBreak;
        source.Play();
    }

}
