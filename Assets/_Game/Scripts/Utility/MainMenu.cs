using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   
    [SerializeField] AudioClip _music;
    [SerializeField] AudioClip _ambience;
    [SerializeField] AudioClip _onButtonClick;    
    [SerializeField] float _musicVolume = .3f;
    [SerializeField] float _ambienceVolume = .5f;

    private void Start()
    {
        MusicPlayer.Instance.PlayNewSong(_music, _ambience, _musicVolume, _ambienceVolume);
    }

    public void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void OnButtonClickSFX()
    {
        if (_onButtonClick)
            AudioHelper.PlayClip2D(_onButtonClick, 1);
    }

    public void ChangeMusicVolume(float newVolume)
    {
        MusicPlayer.Instance.UpdateMusicVolume(newVolume);
    }

    public void ChangeAmbiencecVolume(float newVolume)
    {
        MusicPlayer.Instance.UpdateAmbienceVolume(newVolume);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
