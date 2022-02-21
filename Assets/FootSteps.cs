using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{

    [SerializeField] private AudioClip[] _stepClips;

    [SerializeField] private AudioSource _audioSource;


    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }


    private void Step()
    {
        AudioClip clip = GetRandomClip();
        _audioSource.PlayOneShot(clip);
    }
    
    private AudioClip GetRandomClip()
    {
        return _stepClips[UnityEngine.Random.Range(0, _stepClips.Length)]; 
    }

}
