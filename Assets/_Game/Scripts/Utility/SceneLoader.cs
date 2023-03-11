using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{    
    [SerializeField] AudioClip _buttonSFX;
    [SerializeField] AudioClip _wonSFX;
    [SerializeField] ParticleSystem _winnerParticle;    
    [SerializeField] GameObject _winner;
    private Vector3 _offset = new Vector3 (0, 0.5f, 0);

    private void Start()
    {        
        AudioHelper.PlayClip2D(_wonSFX, 1);
        ParticleSystem winnerParticle = Instantiate(_winnerParticle, _winner.transform.position - _offset, Quaternion.identity);        
        winnerParticle.transform.localScale *= 2;
        winnerParticle.Play();        
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
