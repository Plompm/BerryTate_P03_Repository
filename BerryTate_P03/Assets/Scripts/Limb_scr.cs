using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limb_scr : MonoBehaviour
{

    int _LHealth = 100;

    // Update is called once per frame
    void Update()
    {
        if (_LHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void _LimbDamage(int _dmgAmount)
    {
        _LHealth -= _dmgAmount;
    }
}
