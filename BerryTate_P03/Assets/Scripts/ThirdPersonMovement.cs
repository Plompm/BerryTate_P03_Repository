using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ThirdPersonMovement : MonoBehaviour
{

    [SerializeField] CharacterController controller;
    [SerializeField] Transform cam;
    [SerializeField] CinemachineFreeLook vCam;

    float speed = 6;

    float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        aiming();
    }

    void movement()
    {
        float Hori = Input.GetAxisRaw("Horizontal");
        float Vert = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(Hori, 0, Vert).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }

    void aiming()
    {
        //chaning the direction player is facing and fov of lense to give aiming effect
        if (Input.GetMouseButton(1))
        {
            transform.rotation = cam.rotation;
            vCam.m_Lens.FieldOfView = 30;
        }
        else { vCam.m_Lens.FieldOfView = 40; }
    }
}
