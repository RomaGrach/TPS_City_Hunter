using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogScript : MonoBehaviour
{
    public string CharacterName = null;
    public int DialogInd = -1;
    public DialogCore dialogCore;
    private bool Continue = true;

    void Start()
    {
        Check();
    }
    public void Check()
    {
        try { dialogCore = GameObject.FindGameObjectWithTag("EventCore").GetComponent<DialogCore>(); Continue = true; }
        catch { Continue = false; }
    }
    public void trigger()
    {
        if (Continue)
        {
            dialogCore.ChangeDialog(DialogInd, CharacterName);
            Continue = false;
        }

    }
}
