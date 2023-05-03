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



    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        anim = playerModel.GetComponent<Animator>();
        //count = 0;

        //SetCountText();
        //winTextObject.SetActive(false);


    }

    //void SetCountText()
    //{
    //countText.text = "Count: " + count.ToString();

    //  if (count == 1)
    //{
    //  Win.Play();
    //winTextObject.SetActive(true);
    //}
    //}






    // Update is called once per frame
    void Update()
    {
        /*rb.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y, Input.GetAxis("Vertical") * moveSpeed);

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        } */

        //moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);
        if (knockBackCounter <= 0)
        {

            float yStore = moveDirection.y;
            moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
            moveDirection = moveDirection.normalized * moveSpeed;
            moveDirection.y = yStore;




            if (controller.isGrounded)
            {
                moveDirection.y = 0f;

                if (Input.GetButtonDown("Jump"))
                {
                    //Jump.Play();
                    anim.SetBool("isJumping", true);
                    moveDirection.y = jumpForce;
                }
            }
            //else
            //{
            // if (Input.GetButtonDown("Jump") && canDoubleJump)
            // {
            //Jump.Play();
            //  moveDirection.y = jumpForce * doubleJumpScale;
            //anim.SetBool("isGrounded", true);
            // canDoubleJump = false;
            //}

            //}

        }
        else
        {
            knockBackCounter -= Time.deltaTime;
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);

        //Move the player in different directions based on camera look direction
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
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
        anim.SetFloat("Speed", Mathf.Abs(moveDirection.x) + Mathf.Abs(moveDirection.z));
        anim.SetBool("isGrounded", controller.isGrounded);
        if (controller.isGrounded)
        {
            anim.SetBool("isJumping", false);
        }


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