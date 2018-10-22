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

    public float animationSpeed = 1f;
    public float rootMovementSpeed = 1f;
    public float rootTurnSpeed = 1f;

    void Awake()
    {

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

        anim.SetFloat("velx", inputTurn);
        anim.SetFloat("vely", inputForward);
        
    }


    void OnAnimatorMove()
    {

        Vector3 newRootPosition;
        Quaternion newRootRotation;

        newRootPosition = anim.rootPosition;
        newRootRotation = anim.rootRotation;

        //TODO Here, you could scale the difference in position and rotation to make the character go faster or slower
        this.transform.position = Vector3.LerpUnclamped(this.transform.position, newRootPosition, rootMovementSpeed);
        this.transform.rotation = Quaternion.LerpUnclamped(this.transform.rotation, newRootRotation, rootTurnSpeed);
      
    }
}
