using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class NewSceneAnimation : MonoBehaviour
{
    GameObject animObj;
    GameObject[] children;
    Color[] colors = new Color[3];
    // Start is called before the first frame update
    void Start()
    {
        colors[0] = Color.yellow;
        colors[1] = Color.cyan;
        colors[2] = Color.magenta;
        Debug.Log(SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name != "Start Scene" && SceneManager.GetActiveScene().name != "Level 1")
        {
            StartCoroutine(playAnim());
           
        }
    }
    IEnumerator playAnim()
    {
        animObj = GameObject.FindGameObjectWithTag("Die");
        children = GameObject.FindGameObjectsWithTag("DieSplatter");

        animObj.GetComponent<Animator>().Play("DeathTransition");
        animObj.GetComponent<Animator>().enabled = true;
        for (int i = 0; i < children.Length; i++)
        {
            int r = Random.Range(0, colors.Length);
            children[i].GetComponent<Image>().color = Color.red;
        }
        
        

        yield return new WaitForSeconds(animObj.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0).Length);


        foreach (GameObject children in children)
        {
            children.SetActive(false);
        }
        //animObj.GetComponent<Animator>().enabled = false;
    }
}
    