using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GunAnimationController : MonoBehaviour
{ 
    Animator anim;
    AudioSource spraySound;
    [SerializeField] private GameObject inHandMag;
    [SerializeField] private GameObject gunMag;
    [SerializeField] private GameObject spawnedMag;
    [SerializeField] private Transform spawnPoint;
    private Color _previousColor;
    private Color _newColor;
    public static event Action<Color> changeColor ;
    private PlayerMag _playerMag;
    private GameObject magOnFloor;
    private void OnEnable()
    {
        PickUpCheck.triggerAnimation += SetColor;
    }

    private void OnDisable()
    {
        PickUpCheck.triggerAnimation -= SetColor;
    }

    private void Start()
    {
        _previousColor = gunMag.GetComponent<MeshRenderer>().materials[1].color;
        _playerMag = GetComponent<PlayerMag>();
        anim = GetComponent<Animator>();
        spraySound = GetComponent<AudioSource>();
        inHandMag.SetActive(false);
    }

    private void SetColor(Color color, GameObject magOnFloor)
    {
        this.magOnFloor = magOnFloor;
        _newColor = color;
        anim.SetBool("Unload", true);
    }
    private void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("GunShoot", true);
            spraySound.Play();
            //spraySound.loop = true;

        }

        if (Input.GetMouseButtonUp(0))
        {
            anim.SetBool("GunShoot", false);
            spraySound.Pause();
            //spraySound.loop = false;
        }*/
    }

    public void StartReload()
    {
        anim.SetBool("Unload", false);
        anim.SetBool("Reload", true);
        
    }
    public void Unload()
    {
        var mag = Instantiate(spawnedMag, spawnPoint.position, Quaternion.identity);
        mag.TryGetComponent(out PickupCubeManager pickupCubeManager);
        if(!pickupCubeManager)return;

        pickupCubeManager.ColorPickup = _playerMag.ColorPickup;
        
        gunMag.SetActive(false);
    }
    public void ShowMag()
    {
        inHandMag.SetActive(true);
        Destroy(magOnFloor);
        ColorPainter.colorPainter.ChangeColor(_newColor);
        if (_newColor == Color.magenta)
        {
            _playerMag.ChangeColor(ColorType.colorChoice.Magenta);
        }
        else if (_newColor == Color.cyan)
        {
            _playerMag.ChangeColor(ColorType.colorChoice.Cyan);
        }
        else if (_newColor == Color.yellow)
        {
            _playerMag.ChangeColor(ColorType.colorChoice.Yellow);
        }
    }

    public void HideMag()
    {
        
    }
    public void Reload()
    {
        
        inHandMag.SetActive(false);
        gunMag.SetActive(true);
    }

    public void EndReload()
    {
        anim.SetBool("Reload", false);
        //changeColor.Invoke(_newColor);
    }

    public void SpawnMag()
    {
        
    }
    
}
