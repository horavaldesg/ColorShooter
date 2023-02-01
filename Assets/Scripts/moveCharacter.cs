using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class moveCharacter : MonoBehaviour
{
    public Transform player;
    public AudioSource footSteps;
    public Animator anim;
    public GameObject body;
    public string scene;
    public GameObject interactButtonText;

    public CharacterController cc;
    public Transform checkPos;
    public LayerMask groundMask;
    public Transform camTransform;
    public Material[] newMaterial;
    public float speed = 5f;
    public float verticalSpeed = 0;
    public float Gravity = -9.8f;
    public float jumpSpeed = 9;
    public bool grounded;
    int i;
    public static Vector2 coord;

    public GameObject bullet;
    public float bulletSpeed;
    public Transform barrel;
    public static bool fast = false;
    public static bool jump = false;
    public static bool gravityChange = false;


    public float speedBoost = 3;
    public float speedPlayer;

    public float jumpBoost = 11;
    float jumpInitial;

    float zeroGravity;
    Vector3 initialPos;
    public bool startedJumping;
    public bool startJumping;
    string currentScene;

    private void Start()
    {
        gameObject.layer = 2;
        RotateBodyBack(player);
        fast = false;
        jump = false;
        gravityChange = false;
        cc = GetComponent<CharacterController>();
        speedPlayer = speed;
        jumpInitial = jumpSpeed;
        zeroGravity = 0;
        initialPos = transform.position;
        //Debug.Log(initialPos);
    }

    private void Update()
    {

        speedPlayer = fast ? speedBoost : speed;
        //Debug.Log("Jump");
        jumpInitial = jump ? jumpBoost : jumpSpeed;

        //movement
        var movement = Vector3.zero;
        if (!gravityChange)
        {

            var xSpeed = Input.GetAxis("Vertical") * speedPlayer * Time.deltaTime;
            movement += body.transform.forward * xSpeed;
            var zSpeed = Input.GetAxis("Horizontal") * speedPlayer * Time.deltaTime;
            movement += body.transform.right * zSpeed;

            var aSpeed = xSpeed + zSpeed;
            var tSpeed = movement.magnitude * 10f;
            anim.SetFloat("MoveSpeed", tSpeed);
            if (Mathf.Abs(aSpeed) > 0f)
            {
                footSteps.Pause();
            }

            if (Mathf.Abs(aSpeed) < 0.1f)
            {
                footSteps.Play();
            }

            //Debug.Log("xSpeed = " + xSpeed);
            //Debug.Log("aSpeed = " + aSpeed);
            // Debug.Log("tSpeed = " + tSpeed);


            //if (xSpeed != 0 || ySpeed != 0)
            //{
            //    footSteps.Play();
            //}
        }
        else
        {

            var xSpeed = Input.GetAxis("Vertical") * speedPlayer * Time.deltaTime;
            movement += body.transform.forward * xSpeed;
            var zSpeed = Input.GetAxis("Horizontal") * speedPlayer * Time.deltaTime;
            movement += body.transform.right * zSpeed;

            var aSpeed = xSpeed + zSpeed;
            var tSpeed = movement.magnitude * 10f;
            anim.SetFloat("MoveSpeed", tSpeed);
            if (Mathf.Abs(aSpeed) > 0f)
            {
                footSteps.Pause();
            }

            if (Mathf.Abs(aSpeed) < 0.1f)
            {
                footSteps.Play();
            }


        }

        //Gravity
        if (!gravityChange)
        {
            verticalSpeed += Gravity * Time.deltaTime;

        }
        else if (gravityChange)
        {
            verticalSpeed -= Gravity * Time.deltaTime;



            //transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 180);
        }


        movement += transform.up * (verticalSpeed * Time.deltaTime);

        //Grounded
        if (!grounded)
        {
            footSteps.Pause();
        }

        if (!gravityChange)
        {
            if (Physics.CheckSphere(checkPos.position, 0.5f, groundMask) && verticalSpeed <= 0)
            {
                grounded = true;
                verticalSpeed = 0;
            }
            else
            {
                grounded = false;
            }
        }
        else
        {
            if (Physics.CheckSphere(checkPos.position, 0.5f, groundMask) && verticalSpeed >= 0)
            {
                grounded = true;
                verticalSpeed = 0;

            }
            else
            {
                grounded = false;
            }

        }

        // Blue Jump
        if (!jump && grounded) startJumping = false;
        if (startJumping && grounded && jump)
        {
            Jump(jumpInitial);
            Debug.Log(grounded);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            startJumping = false;
            startedJumping = false;
            var camDown = Mathf.Lerp(camTransform.localPosition.y, 0, 0.75f);
            camTransform.localPosition =
                new Vector3(camTransform.localPosition.x, camDown, camTransform.localPosition.z);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            var camDown = Mathf.Lerp(camTransform.localPosition.y, 1, 0.75f);
            camTransform.localPosition =
                new Vector3(camTransform.localPosition.x, camDown, camTransform.localPosition.z);
        }


        //Jump
        if (!gravityChange)
        {
            if (Input.GetKeyDown(KeyCode.Space) && grounded)
            {

                if (jump)
                {
                    startJumping = true;
                }
                else
                {
                    startJumping = false;
                    Jump(jumpInitial);
                }
            }
        }
        else if (gravityChange)
        {
            if (Input.GetKeyDown(KeyCode.Space) && grounded)
            {
                if (jump)
                {
                    startJumping = true;
                }
                else
                {
                    startJumping = false;
                    Jump(-jumpInitial);
                }
            }

        }


        if (Physics.Raycast(camTransform.position, camTransform.forward, out var hit, 6))
        {
            if (hit.collider.CompareTag("Button"))
            {
                interactButtonText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.GetComponentInParent<Animator>().Play("ButtonPushed");
                    interactButtonText.SetActive(false);
                    DoorMoveScript.buttonPushed = true;
                }

            }


            else
            {
                interactButtonText.SetActive(false);
                //DoorMoveScript.buttonPushed = false;
            }

            if (hit.collider.CompareTag("SceneSwitch"))
            {
                interactButtonText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    SceneManager.LoadScene(scene);
                }
            }
        }
        else
            interactButtonText.SetActive(false);



        cc.Move(movement);



    }

    public void Jump(float jumpInitial)
    {
        verticalSpeed = jumpInitial;
        jump = false;

    }


    public static void RotateBody(Transform body)
    {
        var rotation = body.transform.rotation;
        rotation = Quaternion.Euler(rotation.x, rotation.y, 180);
        body.transform.rotation = rotation;
    }

    public static void RotateBodyBack(Transform body)
    {
        body.transform.rotation = Quaternion.Euler(0, 180, 0);
    }
}
