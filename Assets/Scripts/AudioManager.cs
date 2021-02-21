using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;
/// <summary>
/// A singleton that manages the sounds that are being played
/// </summary>
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    /// <summary>
    /// Add an audio source to each sound
    /// </summary>
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.isLoop;
        }
    }

    /// <summary>
    /// Play the sound with the name if it exists. Stop playing other sounds
    /// </summary>
    /// <param name="name"></param>
    public void Play(string name)
    {
        foreach(Sound sound in sounds)
        {
            if(sound.source.isPlaying)
            {
                sound.source.Stop();
            }
        }
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogError($"Sound {name} not found.");
            return;
        }
        s.source.Play();
    }
}
