using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager_scr : MonoBehaviour
{

    enum _EState { X, Y, Dash, Line, Dot};

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
        _EnemyS = _EState.X;
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
        if (!_LeftA)
        { 
        
        }
        if (!_RightA)
        { 
        
        }
        if (!_LeftL)
        { 
        
        }
        if (!_RightL)
        { 
            
        }
    }
}
