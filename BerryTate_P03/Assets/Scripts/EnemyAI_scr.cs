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

    bool _dead;

    // Start is called before the first frame update
    void Start()
    {
        _navMesh = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, _player.transform.position) < 40)

        if (_dead == false)
        {
            _navMesh.destination = _player.transform.position;

            _enemyS = _enemyStateobj.GetComponent<EnemyManager_scr>()._EnemyS;

            _dead = _enemyStateobj.GetComponent<EnemyManager_scr>()._dead;

            AIManagment();
        }
        else
        {
            _navMesh.enabled = false;
        }
    }

    void AIManagment()
    {
        //if enemy has all there limbs
        if (_enemyS == _EState.Full)
        {
            _navMesh.speed = 12f;
        }

        //if enemy is missing one arm
        if (_enemyS == _EState.misOneArm)
        {
            _navMesh.speed = 12f;
        }

        //if enemy is missing one leg
        if (_enemyS == _EState.misOneLeg)
        {
            _navMesh.speed = 7;
        }

        //if enemy only has arms
        if (_enemyS == _EState.Arms)
        {
            _navMesh.speed = 3f;
        }

        //if enemy only has legs
        if (_enemyS == _EState.Legs)
        {
            _navMesh.speed = 12f;
        }

        //if enemy only has one leg and one arm
        if (_enemyS == _EState.OneLegOneArm)
        {
            _navMesh.speed = 5f;
        }

        //if enemy only has one arm
        if (_enemyS == _EState.oneArm)
        {
            _navMesh.speed = 2f;
        }

        //if enemy only has one leg
        if (_enemyS == _EState.oneLeg)
        {
            _navMesh.speed = 4f;
        }

        //if enemy only has no limbs
        if (_enemyS == _EState.none)
        {
            _navMesh.speed = 1f;
        }
    }
}
