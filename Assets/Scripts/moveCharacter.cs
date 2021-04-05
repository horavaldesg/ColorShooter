using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveCharacter : MonoBehaviour
{
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
    public bool gravityChange = false;


    public float boost = 3;
    public float speedPlayer;

    public float jumpBoost = 11;
    float jumpInitial;

    float zeroGravity;
    Vector3 initialPos;

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
            speedPlayer = boost;
        }
        else
        {
            speedPlayer = speed;
        }
        if (jump)
        {
            Debug.Log("Jump");
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
            movement += transform.forward * xSpeed;
            float ySpeed = Input.GetAxis("Horizontal") * speedPlayer * Time.deltaTime;
            movement += transform.right * ySpeed;
        }
        else
        {
            float xSpeed = Input.GetAxis("Vertical") * speedPlayer * Time.deltaTime;
            movement += transform.forward * xSpeed;
            float ySpeed = Input.GetAxis("Horizontal") * speedPlayer * Time.deltaTime;
            movement += transform.right * ySpeed;
            

        }
        //Gravtity
        if (!gravityChange)
        {
            verticalSpeed += Gravity * Time.deltaTime;

        }
        else if (gravityChange)
        {
            verticalSpeed -= Gravity * Time.deltaTime;
        }
        

        movement += transform.up * verticalSpeed * Time.deltaTime;

       //Grounded
        if (Physics.CheckSphere(checkPos.position,0.5f, groundMask) && verticalSpeed <= 0)
        {
            grounded = true;
            verticalSpeed = 0;
        }
        else
        {
            grounded = false;
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            verticalSpeed = jumpInitial;
            jump = false;
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
    
   

}
