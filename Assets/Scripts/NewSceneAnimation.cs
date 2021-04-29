using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class NewSceneAnimation : MonoBehaviour
{
    GameObject animObj;
    GameObject[] children;
    Color[] colors = { Color.cyan, Color.yellow, Color.magenta };
    // Start is called before the first frame update
    void Start()
    {
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

        
        animObj.GetComponent<Animator>().enabled = true;
        for (int i = 0; i < children.Length; i++)
        {
            int r = Random.Range(0, colors.Length);
            children[i].GetComponent<Image>().color = colors[r];
        }
        
        animObj.GetComponent<Animator>().Play("DeathTransition");

        yield return new WaitForSeconds(1.5f);
        animObj.GetComponent<Animator>().enabled = false;

        foreach (GameObject children in children)
        {
            children.SetActive(false);
        }
    }
}
    