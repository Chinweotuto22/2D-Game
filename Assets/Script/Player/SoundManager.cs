using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }//this is used to make this script accessible to other scripts
    private AudioSource source;
    private void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
    }


    public void PlaySound(AudioClip _sound)
    {
        source.PlayOneShot(_sound);
    } 


}