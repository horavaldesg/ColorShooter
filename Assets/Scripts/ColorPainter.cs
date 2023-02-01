using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;
public class ColorPainter : MonoBehaviour
{
    public bool magenta;
    public bool cyan;
    public bool yellow;
    public bool black;
    public AudioSource landAudio;
    public AudioClip clip;
    public Transform camTransform;
    [SerializeField] float ammo;
    [SerializeField] float depletionAmmo;
    public GameObject brush;
    [SerializeField] Material splatter;
    [SerializeField] Material part;
    public float BrushSize = 0.1f;
    private Color color;
    private Renderer _goRenderer;
    [SerializeField] private ParticleSystem suckParticles;
    [SerializeField] private ParticleSystem suckParticles_Color;

    [SerializeField] Image img;
    
    private void Start()
    {
        color = Color.magenta;
        img.color = color;
        part.color = color;

    }

    private void Update()
    {
        /*
        if (magenta)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                color = Color.magenta;
                part.color = color;
                img.color = color;
                //splatter.color = color;

            }
        }
        if (cyan)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                color = Color.cyan;
                part.color = color;
                img.color = color;
                //splatter.color = color;

            }
        }
        if (yellow)
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                color = Color.yellow;
                part.color = color;
                img.color = color;
                //splatter.color = color;
            }
        }
        */
        if (Physics.Raycast(camTransform.transform.position, camTransform.forward, out var splatterHit))
        {
            splatterHit.collider.transform.TryGetComponent(out ColorChoice colorChoice);
            if(colorChoice)
            {
                if (Input.GetKey(KeyCode.Mouse1))
                {
                    SuckPaint(splatterHit.collider.gameObject, colorChoice.CurrentColor());
                }
            }
            
            /*color = Color.black;
            part.color = color;
            img.color = color;*/

        }
            //splatter.color = color;

            if (black)
        {
            
        }

        if (!(ammo > 0)) return;
        if (!Input.GetMouseButton(0)) return;
        if (!Physics.Raycast(camTransform.transform.position, camTransform.forward, out var hit)) return;
        brush.tag = "Splatter";
        brush.layer = 10;
        if (hit.collider.tag == "Black" && hit.collider.tag != "Splatter" && hit.collider.tag != "Player" && hit.collider.tag != "Button" && hit.collider.tag != "SceneSwitch" && hit.collider.tag != "Respawn")
        {
            hit.collider.TryGetComponent(out _goRenderer);
            _goRenderer.material.color = color;
            landAudio.PlayOneShot(clip);
        }
        if (color != Color.black)
        {
            if (hit.collider.tag == "Splatter" || hit.collider.tag == "Player" || hit.collider.tag == "Button" ||
                hit.collider.tag == "Black") return;
            ammo -= depletionAmmo;
            if (hit.collider.gameObject.name == "XLeft")
            {
               
                SpawnSplatter(hit,Quaternion.Euler(90,0,0));
                //landAudio.loop = true;
            }
            else if (hit.collider.gameObject.name == "XRight")
            {
             
                SpawnSplatter(hit,Quaternion.Euler(-90, 0, 0));

            
            }
            else if (hit.collider.gameObject.name == "ZLeft")
            {
                SpawnSplatter(hit,Quaternion.Euler(0, 0, 90));
            }
            else if (hit.collider.gameObject.name == "ZRight")
            {
                SpawnSplatter(hit,Quaternion.Euler(0, 0, -90));
            }
            else if (hit.collider.gameObject.name == "YTop")
            {
                SpawnSplatter(hit,Quaternion.Euler(0,0,0));
            }
            else if (hit.collider.gameObject.name == "YBottom")
            {
                var go = Instantiate(brush, hit.point - Vector3.up * 0.1f, Quaternion.Euler(180, 0, 0), transform);
                go.GetComponent<Renderer>().material.color = color;
                var brushSize = Random.Range(go.transform.localScale.x - 0.05f, go.transform.localScale.x + 0.15f);
                go.transform.localScale = new Vector3(brushSize, go.transform.localScale.y, brushSize);
                go.TryGetComponent(out _goRenderer);
                _goRenderer.material.color = color;
                landAudio.PlayOneShot(clip);
            }
            else
            {
                SpawnSplatter(hit,Quaternion.Euler(0, 0, 0));
            }
        }
        else if (color == Color.black)
        {
            if (hit.collider.tag != "Splatter" || hit.collider.tag == "Player" || hit.collider.tag == "Button" ||
                hit.collider.gameObject.layer == 8) return;
            hit.collider.tag = "Black";
            hit.collider.TryGetComponent(out _goRenderer);
            _goRenderer.material.color = color;
            landAudio.PlayOneShot(clip);
        }
        //go.transform.localScale = Vector3.one * BrushSize;
    }

    private void SpawnSplatter(RaycastHit hit, Quaternion rotation)
    {
        var go = Instantiate(brush, hit.point + Vector3.up * 0.1f, rotation, transform);
        var brushSize = Random.Range(go.transform.localScale.x - 0.05f, go.transform.localScale.x + 0.15f);
        go.transform.localScale = new Vector3(brushSize, go.transform.localScale.y, brushSize);
        go.TryGetComponent(out _goRenderer);
        _goRenderer.material.color = color;
        landAudio.PlayOneShot(clip);
    }

    private void SuckPaint(GameObject splatterObj, Color color)
    {
        StartCoroutine(SuckDelay(splatterObj, color));
    }

    private IEnumerator SuckDelay(GameObject splatterObj, Color color)
    {
        var emissionColor = suckParticles.main;
        emissionColor.startColor = color;
        suckParticles.Play();
        
      //  suckParticles_Color.Play();
        ChangeColor(color);
        Destroy(splatterObj.gameObject);
        yield return new WaitUntil(() => Input.GetKeyUp(KeyCode.Mouse1));
        suckParticles.Stop();
       // suckParticles_Color.Stop();
        
        
    }

    public void ChangeColor(Color color)
    {
        this.color = color;
        part.color = color;
        img.color = color;
    }
}
    

