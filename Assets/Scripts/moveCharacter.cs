using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCharacter : MonoBehaviour
{
    public CharacterController cc;
    public Transform checkPos;
    public LayerMask groundMask;
    public Transform camTransform;
    public Material[] newMaterial;
    public float speed = 5f;
    public float verticalSpeed = 0;
    public float Gravity = -9.8f;
    public float jumpSpeed = 9;
    bool grounded;
    int i;
    public static Vector2 coord;

    public GameObject bullet;
    public float bulletSpeed;
    public Transform barrel;
    public static bool fast = false;
    public static bool jump = false;
    public static bool gravityChange = false;


    public float boost = 3;
    float speedPlayer;

    public float jumpBoost = 11;
    float jumpInitial;

    float zeroGravity;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        speedPlayer = speed;
        jumpInitial = jumpSpeed;
        zeroGravity = 0;
    }

    // Update is called once per frame
    void Update()
    {
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
            jumpInitial = jumpBoost;
        }
        else
        {
            jumpInitial = jumpSpeed;
        }
        if (gravityChange)
        {
            Gravity = 0;
        }
        else
        {
            Gravity = -9.8f;
        }
        //movement
        Vector3 movement = Vector3.zero;
        float xSpeed = Input.GetAxis("Vertical") * speedPlayer * Time.deltaTime;
        movement += transform.forward * xSpeed;
        float ySpeed = Input.GetAxis("Horizontal") * speedPlayer * Time.deltaTime;
        movement += transform.right * ySpeed;

        //Gravtity
        verticalSpeed += Gravity * Time.deltaTime;

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
        }
        RaycastHit hit;
        if (Physics.Raycast(camTransform.position, camTransform.forward, out hit))
        {
            
            /*Paint*/
            //if (Input.GetMouseButtonDown(0))
            //{
            //    //i = Random.Range(0, newMaterial.Length);
            //    //hit.transform.gameObject.GetComponent<MeshRenderer>().material = newMaterial[i];
            //    coord = hit.textureCoord;
            //    Shoot();
                

            //}


        }

        cc.Move(movement);

        
    }
    void Shoot()
    {
        GameObject bulletObject = Instantiate(bullet, barrel.transform.position, camTransform.transform.rotation);
        bulletObject.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
    }
   
}
