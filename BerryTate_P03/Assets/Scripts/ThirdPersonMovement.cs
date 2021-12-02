using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ThirdPersonMovement : MonoBehaviour
{
    public static ThirdPersonMovement Instance { get; private set; }

    [SerializeField] CharacterController controller;
    [SerializeField] Transform cam;
    [SerializeField] CinemachineFreeLook vCam;
    [SerializeField] GameObject _flashLight;

    float speed = 6;

    float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    float shakeTimer;

    [SerializeField]Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        aiming();
        timer();
    }

    void movement()
    {
        float Hori = Input.GetAxisRaw("Horizontal");
        float Vert = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(Hori, 0, Vert).normalized;

        if (direction.magnitude >= 0.1f)
        {
            anim.enabled = true;
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        else { anim.enabled = false; }
    }

    void aiming()
    {
        //chaning the direction player is facing and fov of lense to give aiming effect
        if (Input.GetMouseButton(1))
        {
            _flashLight.SetActive(true);
            transform.rotation = cam.rotation;
            this.vCam.m_Lens.FieldOfView = 30;
        }
        else { this.vCam.m_Lens.FieldOfView = 40; _flashLight.SetActive(false); }
    }

    void timer()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0f)
            {
                //this.vCam.GetComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
            }
        }
    }
    public void screenShake(float intensity, float time)
    {
        //vCam.GetComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = intensity;
        shakeTimer = time;
    }
}
