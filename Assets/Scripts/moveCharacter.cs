using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveCharacter : MonoBehaviour
{

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

    string currentScene;

    // Start is called before the first frame update
    void Start()
    {
        
        cc = GetComponent<CharacterController>();
        speedPlayer = speed;
        jumpInitial = jumpSpeed;
        zeroGravity = 0;
        initialPos = transform.position;
        //Debug.Log(initialPos);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < 0)
        {
            gameObject.transform.position = initialPos;
        }

        if (fast)
        {
            speedPlayer = speedBoost;
        }
        else
        {
            speedPlayer = speed;
        }
        if (jump)
        {
            //Debug.Log("Jump");
            jumpInitial = jumpBoost;
        }
        else
        {
            jumpInitial = jumpSpeed;
        }
        
            //movement
            Vector3 movement = Vector3.zero;
        if (!gravityChange)
        {
           
            float xSpeed = Input.GetAxis("Vertical") * speedPlayer * Time.deltaTime;
            movement += body.transform.forward * xSpeed;
            float zSpeed = Input.GetAxis("Horizontal") * speedPlayer * Time.deltaTime;
            movement += body.transform.right * zSpeed;

            float aSpeed = xSpeed + zSpeed;
            float tSpeed = movement.magnitude * 10f;
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
            Debug.Log("aSpeed = " + aSpeed);
            Debug.Log("tSpeed = " + tSpeed);


            //if (xSpeed != 0 || ySpeed != 0)
            //{
            //    footSteps.Play();
            //}
        }
        else
        {

            float xSpeed = Input.GetAxis("Vertical") * speedPlayer * Time.deltaTime;
            movement += body.transform.forward * xSpeed;
            float zSpeed = Input.GetAxis("Horizontal") * speedPlayer * Time.deltaTime;
            movement += body.transform.right * zSpeed;

            float aSpeed = xSpeed + zSpeed;
            float tSpeed = movement.magnitude * 10f;
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
       
        //Gravtity
        if (!gravityChange)
        {
            verticalSpeed += Gravity * Time.deltaTime;

        }
        else if (gravityChange)
        {
            verticalSpeed -= Gravity * Time.deltaTime;
           

            
            //transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 180);
        }
        

        movement += transform.up * verticalSpeed * Time.deltaTime;

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
        //Jump
        if (!gravityChange)
        {
            if (Input.GetKeyDown(KeyCode.Space) && grounded)
            {
                verticalSpeed = jumpInitial;
                jump = false;
            }
        }
        else if (gravityChange)
        {
            if (Input.GetKeyDown(KeyCode.Space) && grounded)
            {
                verticalSpeed = -jumpInitial;
                jump = false;
            }
        }
        RaycastHit hit;
        if (Physics.Raycast(camTransform.position, camTransform.forward, out hit, 6))
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
    
   
    public static void RotateBody(Transform body)
    {
        body.transform.rotation = Quaternion.Euler(body.transform.rotation.x, body.transform.rotation.y, 180);
    }
    public static void RotateBodyBack(Transform body)
    {
        body.transform.rotation = Quaternion.Euler(0, 180, 0);
    }

}
