using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody), typeof(CapsuleCollider))]
[RequireComponent(typeof(PlayerControl))]
public class RootMotionPlayerMovement : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rbody;
    private PlayerControl cinput;

    private Transform leftFoot;
    private Transform rightFoot;
    private float camRayLength = 100f;
    private int floorMask;

    public float animationSpeed = 1f;
    public float rootMovementSpeed = 1f;
    public float rootTurnSpeed = 1f;

    void Awake()
    {
        floorMask = LayerMask.GetMask("Environment");
        anim = GetComponent<Animator>();

        if (anim == null)
            Debug.Log("Animator could not be found");

        rbody = GetComponent<Rigidbody>();

        if (rbody == null)
            Debug.Log("Rigid body could not be found");

        cinput = GetComponent<PlayerControl>();
        if (cinput == null)
            Debug.Log("CharacterInput could not be found");
    }

    // Use this for initialization
    void Start()
    {
        //never sleep so that OnCollisionStay() always reports for ground check
        rbody.sleepThreshold = 0f;
    }
    
    void Update()
    {
        anim.speed = animationSpeed;
    }
    
    void FixedUpdate()
    {
        float inputForward = 0f;
        float inputTurn = 0f;

        if (cinput.enabled)
        {
            inputForward = cinput.Forward;
            inputTurn = cinput.Turn;
        }

        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;
        Quaternion newRotation;
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;
            newRotation = Quaternion.LookRotation(playerToMouse);

            anim.SetFloat("velx", newRotation.w / 4 + inputTurn);
        } else {
            anim.SetFloat("velx", inputTurn);
        }
        
        anim.SetFloat("vely", inputForward);
        
    }


    void OnAnimatorMove()
    {

        Vector3 newRootPosition;
        Quaternion newRootRotation;

        newRootPosition = anim.rootPosition;
        newRootRotation = anim.rootRotation;
        newRootPosition.y = 0.21f;
        
        this.transform.position = Vector3.LerpUnclamped(this.transform.position, newRootPosition, rootMovementSpeed);

        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;
        Quaternion newRotation;
        if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask) && Time.timeScale == 1f)
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;
            newRotation = Quaternion.LookRotation(playerToMouse);

            this.transform.rotation = Quaternion.LerpUnclamped(this.transform.rotation, Quaternion.SlerpUnclamped(newRootRotation, newRotation, rootTurnSpeed), rootTurnSpeed);
        }
        
      
    }

    public void GainSpeed(float multiplier)
    {
        animationSpeed *= (1.0f + multiplier);
        rootMovementSpeed *= (1.0f + multiplier);
    }
}
