using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outerLimbManager_scr : MonoBehaviour
{

    [SerializeField] GameObject _neededLimb;

    void Update()
    {
        //checking for if a limb connecting to the main body is gone then so is this limb
        if (_neededLimb.activeSelf == false)
        {
            gameObject.SetActive(false);
        }
    }
}
