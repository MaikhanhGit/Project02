using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GamePieceType
{
    PlayerOnePiece = 0,
    PlayerTwoPiece = 1
}
public class GamePiece : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] ParticleSystem _killedParticle;
    [SerializeField] ParticleSystem _landingParticle;
    [SerializeField] AudioClip _landingSFX;
    [SerializeField] AudioClip _killedSFX;

    public GamePieceType Type;
    public int Team;
    public int CurrentX;
    public int CurrentZ;
    private int _tileSize = 1;
    private float _happyAnimDuration = 1.5f;
    private float _downAnimDuration = 1;

    private bool _piecePickedUp = false;
    private bool _alreadySetUp = false;
    private Vector3 _currentTransform;    
    private Vector3 _originalSize;
    private GetAvailableMoves _getAvailableMoves;
    private string _animPickedUp = "PickedUp";
    private string _animKilled = "Killed";
    private string _animHappy = "Happy";
    private string _animDown = "Down";
    private KillCheck _killCheck;
    
    public bool PiecePickedUp => _piecePickedUp;

    private void Start()
    {        
        _killCheck = GetComponent<KillCheck>();               
        _killCheck.Happy += OnHappy;
        _originalSize = transform.localScale;
    }

    private void Update()
    {
        CurrentX = (int)transform.position.x;
        CurrentZ = (int)transform.position.z;

    }

    public void SetPosition(Vector3 position, bool force = false)
    {        
        if(force == true)
        {
            _animator.SetBool(_animPickedUp, false);            
            StartCoroutine(StartDownAnimation(_downAnimDuration));
            transform.position = position;
            ParticleSystem landParticle =
            Instantiate(_landingParticle, position, Quaternion.identity);
            landParticle.Play();
            if(_alreadySetUp == true)
            {
                AudioHelper.PlayClip2D(_landingSFX, 1);                
            }
            _alreadySetUp = true;
            _piecePickedUp = false;            
        }
    }

    public void PickedUp()
    {    
        if(_piecePickedUp == true)
        {            
            PutDown();
        }
        else if(_piecePickedUp == false)
        {
            _animator.SetBool(_animPickedUp, true);
            _currentTransform = gameObject.transform.position;
            Transform transform = gameObject.transform;
            transform.position = new Vector3(transform.position.x, 1, transform.position.z);            
            _piecePickedUp = true;            
        }                
    }

    public void PutDown()
    {
        _animator.SetBool(_animPickedUp, false);               
        StartCoroutine(StartDownAnimation(_downAnimDuration));
        Transform transform = this.gameObject.transform;
        transform.position = _currentTransform;
        ParticleSystem landParticle =
           Instantiate(_landingParticle, this.transform.position, Quaternion.identity);
        landParticle.Play();
        AudioHelper.PlayClip2D(_landingSFX, 1);
        _piecePickedUp = false;        
    }    
    
    public void OnKilled()    
    {        
        _animator.SetBool(_animKilled, true);
        ParticleSystem killedParticle = 
            Instantiate(_killedParticle, transform.position + new Vector3 (0, 1, 0), Quaternion.identity);        
        killedParticle.Play();
        AudioHelper.PlayClip2D(_killedSFX, 1);
    }
   

    public void OnHappy()
    {                
        StartCoroutine(StartHappyAnimation(_happyAnimDuration));
    }

    private IEnumerator StartHappyAnimation(float duration)
    {
        _animator.SetBool(_animHappy, true);
        yield return new WaitForSeconds(duration);
        _animator.SetBool(_animHappy, false);
        _killCheck.Happy -= OnHappy;
    }

    private IEnumerator StartDownAnimation(float duration)
    {        
        _animator.SetBool(_animDown, true);
        yield return new WaitForSeconds(duration);
        _animator.SetBool(_animDown, false);

    }
    
}
