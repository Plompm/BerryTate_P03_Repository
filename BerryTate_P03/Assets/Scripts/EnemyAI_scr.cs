using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI_scr : MonoBehaviour
{
    NavMeshAgent _navMesh;
    GameObject _player;
    [SerializeField] GameObject _enemyStateobj;

    _EState _enemyS;

    // Start is called before the first frame update
    void Start()
    {
        _navMesh = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        _navMesh.destination = _player.transform.position;

        _enemyS = _enemyStateobj.GetComponent<EnemyManager_scr>()._EnemyS;

        AIManagment();
    }

    void AIManagment()
    {
        //if enemy has all there limbs
        if (_enemyS == _EState.Full)
        {
            _navMesh.speed = 3.5f;
        }

        //if enemy is missing one arm
        if (_enemyS == _EState.misOneArm)
        {
            _navMesh.speed = 3.5f;
        }

        //if enemy is missing one leg
        if (_enemyS == _EState.misOneLeg)
        {
            _navMesh.speed = 3;
        }

        //if enemy only has arms
        if (_enemyS == _EState.Arms)
        {
            _navMesh.speed = 1f;
        }

        //if enemy only has legs
        if (_enemyS == _EState.Legs)
        {
            _navMesh.speed = 3.5f;
        }

        //if enemy only has one leg and one arm
        if (_enemyS == _EState.OneLegOneArm)
        {
            _navMesh.speed = 1.5f;
        }

        //if enemy only has one arm
        if (_enemyS == _EState.oneArm)
        {
            _navMesh.speed = 0.5f;
        }

        //if enemy only has one leg
        if (_enemyS == _EState.oneLeg)
        {
            _navMesh.speed = 0.5f;
        }

        //if enemy only has no limbs
        if (_enemyS == _EState.none)
        {
            _navMesh.speed = 0.1f;
        }
    }
}
