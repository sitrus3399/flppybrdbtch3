using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    public float seconds;

    private IEnumerator IeWaitForSecond(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        //membuka scene dengan nama sesuai dengan variable name
        SceneManager.LoadScene("Main");
    }

public void LoadScene(string name)
    {
        //Melakukan pengecekan jika name tidak null atau empty
        if (name == "Opening")
        {
            //membuka scene dengan nama sesuai dengan variable name
            SceneManager.LoadScene("Opening");
        }
        else if (name == "Main")
        {
            StartCoroutine(IeWaitForSecond(seconds));
        }
    }


}
