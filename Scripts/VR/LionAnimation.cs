using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionAnimation : MonoBehaviour
{
    private Animator _animator;
    
    private int _walkingHash ;
    private int _directionHash;
    private bool _walking;
    public float _accelaration = 0.005f;
    AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _directionHash = Animator.StringToHash("Walk Direction Threshold");
        _walkingHash = Animator.StringToHash("Walking");
        Walk();
        _animator.SetFloat(_directionHash, _accelaration );

        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (_walking)
        {
            
            _accelaration = _accelaration > 1? 1: _accelaration + _animator.GetFloat(_directionHash);

            _animator.SetFloat(_directionHash, _accelaration );
        }
    }

    private void Walk()
    {
        _walking = true;
        int dir = Random.Range(-1, 2);
    }
}
