using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogCore : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject DialogObject;
    private bool Continue;
    void Start()
    {
        Check();
    }

    public void Check()
    {
        DialogObject = FindObjectOfType<GameObject>(DialogObject);
        if (DialogObject != null) Continue = true;
        else Continue = false;
    }

    public void InvokeDialog(string name, string message)
    {
        if (Continue)
        {

        }
        else
        {
            Debug.LogError("No DialogObject Found");
        }
    }
}
