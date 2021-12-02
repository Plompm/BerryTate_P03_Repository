using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunManager_scr : MonoBehaviour
{
    [SerializeField] Transform aimTransform;
    [SerializeField] Transform restTransform;
    GameObject[] lasers = new GameObject[3];
    [SerializeField] GameObject _dustVFX;
    [SerializeField] GameObject _bloodVFX;
    [SerializeField] GameObject _ammoUI;
    [SerializeField] Text ammoCounter;
    [SerializeField] AudioClip _shot;
    [SerializeField] AudioClip _switchPos;
    [SerializeField] AudioClip _aim;

    AudioSource ad;

    int ammo = 11;

    bool vert = false;
    Vector3 horiScale = new Vector3(0.75f, 0.1f, 0.5f);
    Vector3 vertScale = new Vector3(0.5f, 0.1f, 0.75f);

    // Start is called before the first frame update
    void Start()
    {
        //setting up the array for the laser gameobjects
        for (int i = 0; i < 3; i++)
        {
            lasers[i] = GameObject.Find("laser" + i);
        }

        ad = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ammoCounter.text = ammo.ToString();

        //aiming down all lasers will be set to active
        if (Input.GetMouseButton(1))
        {
            gameObject.transform.position = aimTransform.position;
            _ammoUI.SetActive(true);
            for (int i = 0; i < 3; i++)
            {
                lasers[i].SetActive(true);
            }

            shooting();
        }
        //if the player isnt aiming down then all the lasers are set to false
        else
        {
            gameObject.transform.position = restTransform.position;
            _ammoUI.SetActive(false);
            for (int i = 0; i < 3; i++)
            {
                lasers[i].SetActive(false);
            }
        }

        directionSwitch();
        reloding();

        if (Input.GetMouseButtonDown(1))
        {
            ad.clip = _aim;
            ad.Play();
        }
    }

    void shooting()
    {
        //mouse buttonleft pressed
        if (Input.GetMouseButtonDown(0) && ammo > 0)
        {
            //ThirdPersonMovement.Instance.screenShake(5f,0.1f);
            ammo -= 1;
            ad.clip = _shot;
            ad.Play();

            for (int i = 0; i < 3; i++)
            {
                //getting a bool from the laser script to see if raycast hit anything
                bool shothit = lasers[i].GetComponent<lasers_scr>().shothit;
                //if the raycast did then this...
                if (shothit == true)
                {
                    RaycastHit hit = lasers[i].GetComponent<lasers_scr>().hit;
                    //if it hit enemy anywhere create blood particles
                    if (hit.transform.gameObject.tag == "Enemy" || hit.transform.gameObject.tag == "Limb")
                    {
                        Instantiate(_bloodVFX, hit.point, new Quaternion(0, 0, 0, 0));
                        hit.transform.gameObject.GetComponentInParent<EnemyManager_scr>()._EDamage(1);
                    } //if collided but not an enemy create dust particles
                    else
                    {
                        Instantiate(_dustVFX, hit.point, new Quaternion(0, 0, 0, 0));
                    }//this is for specifically dealing limb damage
                    if (hit.transform.gameObject.tag == "Limb")
                    {
                        print("hit");
                        hit.transform.gameObject.GetComponent<Limb_scr>()._LimbDamage(1);
                    }
                }
            }
        }
    }

    void directionSwitch()
    {
        //on keypress change the rotaition the weapon fires in
        if (Input.GetKeyDown(KeyCode.E))
        {
            ad.clip = _switchPos;
            ad.Play();
            vert = !vert;
        }
        //horizontal shot
        if (vert == false)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            transform.localScale = horiScale;
        }//vertical shot
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, -90);
            transform.localScale = vertScale;
        }
    }

    void reloding()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ammo = 11;
        }
    }
}
