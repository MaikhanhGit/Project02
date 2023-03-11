using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class MusicPlayer : SingletonMB<MusicPlayer>
{    
    AudioSource _music;
    AudioSource _ambience;
    float _musicVolume = .3f;
    float _ambienceVolume = .5f;

    private void Awake()
    {
        _music = gameObject.AddComponent<AudioSource>();
        _music.loop = true;
        _ambience = gameObject.AddComponent<AudioSource>();
        _ambience.loop = true;
    }

    // this music player is specialized to play 2 audio clips at once
    public void PlayNewSong(AudioClip newSong01, AudioClip newSong02, float volume01, float volume02)
    {
        if (newSong01 == null && newSong02 == null) return;    // guard clause

        if (newSong01 != null)
        {
            _music.clip = newSong01;
            _music.volume = volume01;
            _music.Play();
        }
        if (newSong02 != null)
        {
            _ambience.clip = newSong02;
            _ambience.volume = volume02;
            _ambience.Play();
        }
    }

    private void Update()
    {
        _music.volume = _musicVolume;
        _ambience.volume = _ambienceVolume;
    }

    public void UpdateMusicVolume(float volume)
    {
        _musicVolume = volume;
    }

    public void UpdateAmbienceVolume(float volume)
    {
        _ambienceVolume = volume;
    }
}
