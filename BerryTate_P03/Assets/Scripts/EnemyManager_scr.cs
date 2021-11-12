using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager_scr : MonoBehaviour
{

    enum _EState { Full, misOneLeg, misOneArm, Arms, Legs, OneLegOneArm, oneLeg, oneArm, none};

    _EState _EnemyS;

    [SerializeField] GameObject _LeftA;
    [SerializeField] GameObject _RightA;
    [SerializeField] GameObject _LeftL;
    [SerializeField] GameObject _RightL;

    int _EHealth;

    float _speed;

    // Start is called before the first frame update
    void Start()
    {
        _EnemyS = _EState.Full;
    }

    // Update is called once per frame
    void Update()
    {
        _stateManger();
        print(_EnemyS);
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
        }

        //checking if all the limbs are diabled 
        if (_LeftA.activeSelf == false && _RightA.activeSelf == false && _LeftL.activeSelf == false && _RightL.activeSelf == false)
        {
            _EnemyS = _EState.none;
        }



    }
}
