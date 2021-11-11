using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager_scr : MonoBehaviour
{

    enum _EState {Full, OneArm, OneLeg, OneArmOneLeg, NoLegs, NoArms, None};

    _EState _EnemyS;

    GameObject _LeftA;
    GameObject _RightA;
    GameObject _LeftL;
    GameObject _RightL;

    // Start is called before the first frame update
    void Start()
    {
        _EnemyS = _EState.Full;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
