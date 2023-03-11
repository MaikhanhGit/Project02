using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] AudioClip _endGameMusic;
    [SerializeField] AudioClip _buttonSFX;

    private void Start()
    {
        AudioHelper.PlayClip2D(_endGameMusic, 1);
    }

    public void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void OnButtonClickSFX()
    {
        if (_buttonSFX)
            AudioHelper.PlayClip2D(_buttonSFX, 1);
    }
}
