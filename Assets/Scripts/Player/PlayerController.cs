using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour
{
    public AudioSource walking;
    public float moveSpeed;
    public float jumpForce;
    public CharacterController controller;

    private Vector3 moveDirection;
    public float gravityScale;

    private bool canDoubleJump = false;
    public float doubleJumpScale = 3.5f;

    public float knockBackForce;
    public float knockBackTime;
    private float knockBackCounter;

    public Animator anim;

    public Transform pivot;
    public float rotateSpeed;

    public GameObject playerModel;

    private float inputX;
    private float inputZ;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = playerModel.GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {

        if (knockBackCounter <= 0)
        {

            float yStore = moveDirection.y;
            inputX = Input.GetAxis("Horizontal");
            inputZ = Input.GetAxis("Vertical");
            moveDirection = (transform.forward * inputZ) + (transform.right * inputX);
            moveDirection = moveDirection.normalized * moveSpeed;
            moveDirection.y = yStore;



            knockBackCounter -= Time.deltaTime;
            //if (controller.isGrounded)
            //{
            //moveDirection.y = 0f;

            //if (Input.GetButtonDown("Jump"))
            //{
            //Jump.Play();
            //anim.SetBool("isJumping", true);
            //moveDirection.y = jumpForce;
            // }
            //}

        }
        //else
        //{
            //knockBackCounter -= Time.deltaTime;
        //}

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);

        //Move the player in different directions based on camera look direction
        if (inputX != 0 || inputZ != 0)
        {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
            walking.Play();
        else if (!Input.GetButton("Horizontal") && !Input.GetButton("Vertical") && walking.isPlaying)
            walking.Stop(); // or Pause()



        // Update Animator parameters
        float movementSpeed = Mathf.Abs(inputX) + Mathf.Abs(inputZ);
        anim.SetFloat("Speed", movementSpeed);
        anim.SetFloat("InputX", inputX);
        anim.SetFloat("InputZ", inputZ);
        anim.SetBool("isGrounded", controller.isGrounded);

    }

    private void OnTriggerEnter(Collider other)
    {

    }


    public void Knockback(Vector3 direction)
    {
        knockBackCounter = knockBackTime;

        moveDirection = direction * knockBackForce;
        moveDirection.y = knockBackForce;
    }


}