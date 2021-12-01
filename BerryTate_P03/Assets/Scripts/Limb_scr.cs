using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limb_scr : MonoBehaviour
{

    int _LHealth = 3;

    // Update is called once per frame
    void Update()
    {
        if (_LHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void _LimbDamage(int _dmgAmount)
    {
        _LHealth -= _dmgAmount;
    }
}
