﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSFX : MonoBehaviour
{
    [SerializeField] AudioSource nightSounds;

    private void Awake()
    {
        AudioListener.pause = false;
    }

    /// <summary>
    /// Plays background fx
    /// </summary>
    private void Update()
    {
        if (nightSounds.isPlaying == false)
        {
            nightSounds.Play();
            nightSounds.loop = true;
        }
    }
}
