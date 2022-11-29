using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using OpenCover.Framework.Model;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class RhinoAnimations : MonoBehaviour
{
    private Animator _animator;

    private int _walkingHash ;
    private int _idleHash ;
    private int _chewingHash ;
    private int _lookingFfHash ;
    private int _grazingHash ;
    private int _walkGrazingHash ;


    public int nextState;
    private UnityAction _nextMethod;
    private bool _newAnim;
    
    private int[] _states ;
    private UnityAction[] _methods ;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _walkingHash = Animator.StringToHash("Walking");
        _idleHash = Animator.StringToHash("Idle");
        _chewingHash = Animator.StringToHash("Chewing");
        _lookingFfHash = Animator.StringToHash("Looking for Food");
        _grazingHash = Animator.StringToHash("Grazing");
        _walkGrazingHash = Animator.StringToHash("Walk Grazing");
        
        _states = new[] { _idleHash, _walkingHash, _chewingHash, _lookingFfHash, _grazingHash, _walkGrazingHash };
        _methods = new UnityAction[] { Idle, Walk, Chew, LookForFood, Graze, WalkGrazing };

        _newAnim = true;
        nextState = _idleHash;
        _animator.SetBool(nextState, true);
        _nextMethod = Idle;
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetBool(nextState, true);

        if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.4f) _newAnim = true;
        
        if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && _animator.IsInTransition(0) && _newAnim)
        {
            _nextMethod();
            _newAnim = false;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject && _animator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
        {
            Debug.Log("stop waalking");
            _animator.StopPlayback();
            
            _nextMethod();
            _animator.Play("Chew");
        }
    }
    private void SetNextStateAndMethod(int[] ps)
    {
        int randomNumber = Random.Range(0, 10);
        int index = ps[randomNumber];
        nextState = _states[index];
        _nextMethod = _methods[index];
    }
    
    private void Idle()
    {
        _animator.SetBool(_idleHash, false);
        int[] ps = new[] {0 ,0, 1, 2, 3, 4, 4, 4, 5, 5};
        
        SetNextStateAndMethod(ps);
    }

    private void Walk()
    {
        _animator.SetBool(_walkingHash, false);
        int[] ps = new[] {0,0,0, 1, 2, 3, 4,4, 5,5};
        
        SetNextStateAndMethod(ps);
    }

    private void WalkGrazing()
    {
        _animator.SetBool(_walkGrazingHash, false);
        int[] ps = new[] {0, 1, 2,2,2, 3, 4, 4, 5, 5};
        
        SetNextStateAndMethod(ps);
    }
    private void Graze()
    {
        _animator.SetBool(_grazingHash, false);
        int[] ps = new[] {0, 1, 2,2,2, 3, 4, 4, 5, 5};
        
        SetNextStateAndMethod(ps);
    }
    private void Chew()
    {
        _animator.SetBool(_chewingHash, false);
        int[] ps = new[] {0 , 1, 2, 3,3, 4, 4, 4, 5, 5};
        
        SetNextStateAndMethod(ps);
    }
    private void LookForFood()
    {
        _animator.SetBool(_lookingFfHash, false);
        int[] ps = new[] {0 ,0, 1, 2, 3, 4, 4, 4, 5, 5};
        
        SetNextStateAndMethod(ps);
    }
}
