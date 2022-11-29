using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ElephantAnimation : MonoBehaviour
{
    private Animator _animator;
    private bool _catchUp = false;
    private int _velocityHash;

    private float _velocity;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _velocityHash = Animator.StringToHash("Velocity");
        
        SetVelocity(true);

    }
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("ElephantPack"))
        {
            SetVelocity(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ElephantPack"))
        {
            SetVelocity(false);
        }
    }

    void SetVelocity(bool inPack)
    {
        _velocity = (inPack)? Random.Range(0.5f, 1.00f): Random.Range(1.70f, 2.00f);
        _animator.SetFloat(_velocityHash, _velocity);

    }
}