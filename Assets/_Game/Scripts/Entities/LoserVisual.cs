using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoserVisual : MonoBehaviour
{
    [SerializeField] ParticleSystem _deadPartile;
    ParticleSystem deadPartile;
    private float _duration = 0;
    private float _delay = 2;
    private bool _played = false;
   
    private void Update()
    {
        _duration += Time.deltaTime;
        if (_duration >= _delay && _played == false)
        {
            deadPartile = Instantiate(_deadPartile, transform.position, Quaternion.identity);
            deadPartile.Play();

            _played = true;
        }

        else if(_duration >= (_delay + 2) && deadPartile != null)
        {
            Destroy(deadPartile.gameObject);
        }
    }
}
