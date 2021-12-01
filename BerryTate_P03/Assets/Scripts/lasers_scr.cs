using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lasers_scr : MonoBehaviour
{
    [SerializeField] Transform startPos;
    Vector3 endPos;
    float maxDis = 80;
    public RaycastHit hit;
    [SerializeField] GameObject orb;
    public bool shothit;
    float _xScale = 0.006426655f;

    void Start()
    {
        orb.SetActive(false);
    }
    
    /// <summary>
    /// Update here is used to send out a raycast to detect objects
    /// Using a plane to represent the laser modifying the scale and position to make it line up with the weapon
    /// And if there is no obejct collision then the lasers have a defualt distance to rest at
    /// </summary>
    void Update()
    {
        if (Physics.Raycast(startPos.position, startPos.forward, out hit, maxDis))
        {
            //setting size and pos based on raycast and where it ended
            endPos = hit.point;
            float zScale = (Mathf.Abs(startPos.position.z - endPos.z) - Mathf.Abs(startPos.position.x - endPos.x) - Mathf.Abs(startPos.position.y - endPos.y)) / 7;

            gameObject.transform.position = new Vector3((startPos.position.x + endPos.x) / 2, (startPos.position.y + endPos.y) / 2, (startPos.position.z + endPos.z) / 2);
            gameObject.transform.localScale = new Vector3(_xScale, 1, zScale);

            orb.SetActive(true);
            orb.transform.position = hit.point;
            shothit = true;
        }
        else
        {
            //if the raycast collided with nothing then the plane will default to the given length
            Ray ray = new Ray(startPos.position, startPos.forward * 20);
            gameObject.transform.position = new Vector3((startPos.position.x + ray.GetPoint(30).x) / 2, (startPos.position.y + ray.GetPoint(30).y) / 2, (startPos.position.z + ray.GetPoint(30).z) / 2);
            gameObject.transform.localScale = new Vector3(_xScale, 1, 5);

            orb.SetActive(false);
            shothit = false;
        }

    }
}
