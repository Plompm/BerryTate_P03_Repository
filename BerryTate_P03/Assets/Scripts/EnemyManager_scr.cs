using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum _EState { Full, misOneLeg, misOneArm, Arms, Legs, OneLegOneArm, oneLeg, oneArm, none };

public class EnemyManager_scr : MonoBehaviour
{
    public _EState _EnemyS;
    _EState _SC;

    [SerializeField] GameObject _LeftA;
    [SerializeField] GameObject _RightA;
    [SerializeField] GameObject _LeftL;
    [SerializeField] GameObject _RightL;

    AudioSource ad;
    [SerializeField] AudioClip death;
    [SerializeField] AudioClip hit;
    [SerializeField] AudioClip notice;
    [SerializeField] AudioClip limbPop;

    [SerializeField] Transform _bloodRShoulder;
    [SerializeField] Transform _bloodLShoulder;
    [SerializeField] Transform _bloodRBicep;
    [SerializeField] Transform _bloodLBicep;
    [SerializeField] Transform _bloodRHip;
    [SerializeField] Transform _bloodLHip;
    [SerializeField] Transform _bloodRKnee;
    [SerializeField] Transform _bloodLKnee;


    [SerializeField] Transform _noLegTra;
    [SerializeField] Transform _noLimbTra;
    [SerializeField] Transform _deadPos;

    int _EHealth = 21;
    int _prevHealth = 21;

    float _speed;
    public bool _dead;

    // Start is called before the first frame update
    void Start()
    {
        _dead = false;
        _EnemyS = _EState.Full;
        _SC = _EState.Full;
        ad = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        _stateManger();
        print(_EnemyS);

        soundCheck();

        if (_dead == true)
        {
            transform.localPosition = _deadPos.localPosition;
            transform.localRotation = _deadPos.localRotation;
        }
    }
    void soundCheck()
    {
        if (_dead == false)
        {
            if (_EHealth < _prevHealth)
            {
                ad.clip = hit;
                ad.Play();
                _prevHealth = _EHealth;
            }
            if (_SC != _EnemyS)
            {
                ad.clip = limbPop;
                ad.Play();
                _SC = _EnemyS;
            }
            if (_EHealth <= 0)
            {
                ad.clip = death;
                ad.Play();
                _dead = true;
            }
        }
    }

    public void _EDamage(int _dmgAmount)
    {
        _EHealth -= _dmgAmount;
    }

    void _stateManger()
    {
        //check for all limbs still active
        if (_LeftA.activeSelf == true && _RightA.activeSelf == true && _LeftL.activeSelf == true && _RightL.activeSelf == true)
        {
            _EnemyS = _EState.Full;
        }

        //checking if only one arm is diabled
        if (
               (_LeftA.activeSelf == true && _RightA.activeSelf == false && _LeftL.activeSelf == true && _RightL.activeSelf == true) ||
               (_LeftA.activeSelf == false && _RightA.activeSelf == true && _LeftL.activeSelf == true && _RightL.activeSelf == true)
           )
        {
            _EnemyS = _EState.misOneArm;
        }

        //checking if only leg is disabled
        if (
               (_LeftA.activeSelf == true && _RightA.activeSelf == true && _LeftL.activeSelf == false && _RightL.activeSelf == true) ||
               (_LeftA.activeSelf == true && _RightA.activeSelf == true && _LeftL.activeSelf == true && _RightL.activeSelf == false)
           )
        {
            _EnemyS = _EState.misOneLeg;
        }


        //check for only arms active
        if (_LeftA.activeSelf == true && _RightA.activeSelf == true && _LeftL.activeSelf == false && _RightL.activeSelf == false)
        {
            _EnemyS = _EState.Arms;
            transform.localPosition = _noLegTra.localPosition;
            transform.localRotation = _noLegTra.localRotation;
        }

        //check for only legs active
        if (_LeftA.activeSelf == false && _RightA.activeSelf == false && _LeftL.activeSelf == true && _RightL.activeSelf == true)
        {
            _EnemyS = _EState.Legs;
        }

        //checking if only one leg and only one arm arm active
        if (
               (_LeftA.activeSelf == true && _RightA.activeSelf == false && _LeftL.activeSelf == false && _RightL.activeSelf == true) ||
               (_LeftA.activeSelf == true && _RightA.activeSelf == false && _LeftL.activeSelf == true && _RightL.activeSelf == false) ||
               (_LeftA.activeSelf == false && _RightA.activeSelf == true && _LeftL.activeSelf == false && _RightL.activeSelf == true) ||
               (_LeftA.activeSelf == false && _RightA.activeSelf == true && _LeftL.activeSelf == true && _RightL.activeSelf == false) 
           )
        {
            _EnemyS = _EState.OneLegOneArm;
        }

        //checking if only one leg is active
        if (
              (_LeftA.activeSelf == false && _RightA.activeSelf == false && _LeftL.activeSelf == true && _RightL.activeSelf == false) ||
              (_LeftA.activeSelf == false && _RightA.activeSelf == false && _LeftL.activeSelf == false && _RightL.activeSelf == true)
           )
        {
            _EnemyS = _EState.oneLeg;
        }

        //checking if only one arm is active
        if (
             (_LeftA.activeSelf == true && _RightA.activeSelf == false && _LeftL.activeSelf == false && _RightL.activeSelf == false) ||
             (_LeftA.activeSelf == false && _RightA.activeSelf == true && _LeftL.activeSelf == false && _RightL.activeSelf == false)
           )
        {
            _EnemyS = _EState.oneArm;
            transform.localPosition = _noLegTra.localPosition;
            transform.localRotation = _noLegTra.localRotation;
        }

        //checking if all the limbs are diabled 
        if (_LeftA.activeSelf == false && _RightA.activeSelf == false && _LeftL.activeSelf == false && _RightL.activeSelf == false)
        {
            _EnemyS = _EState.none;
            transform.localPosition = _noLimbTra.localPosition;
            transform.localRotation = _noLimbTra.localRotation;
        }



    }
}
