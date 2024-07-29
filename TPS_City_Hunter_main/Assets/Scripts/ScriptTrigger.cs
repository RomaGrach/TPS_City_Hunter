using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTrigger : MonoBehaviour
{
    public Rule[] CheckList = {
        new Rule("Dialog", false),
        new Rule("Quest", false),
        new Rule("AND", false),
        new Rule("Collision", false),
        new Rule("Click", false),
        new Rule("Start", false)
    };
    public Rule_Data AdditionalData;
    public QuestScript questObj;
    public DialogScript dialogObj;
    private bool Continue = true;
    
    // Start is called before the first frame update
    void Start()
    {
        if (CheckList[0].flag) dialogObj = gameObject.GetComponent<DialogScript>(); 
        if (CheckList[1].flag) questObj = gameObject.GetComponent<QuestScript>();
        if (dialogObj == null && questObj == null) { Debug.Log("No quest or dialog scripts");  Continue = false; }
        if (CheckList[5].flag && Continue)
        {
            Activate(CheckList[0].flag, CheckList[1].flag);
        }
    }

    private void Activate(bool dialog, bool quest)
    {
        Debug.Log("Activated!");
        if (dialog) dialogObj.trigger();
        if (quest) questObj.trigger();
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided!");
        if (CheckList[3].flag && Continue)
        {
            GameObject collider = collision.gameObject;
            if (AdditionalData.check(CheckList[3].flag, collider.tag, collider, collider.layer)) Activate(CheckList[0].flag, CheckList[1].flag);
        }
    }
    private void OnClick(GameObject activator = null)
    {
        Debug.Log("Clicked!");
        if (CheckList[4].flag && Continue)
        {
            if (AdditionalData.check(CheckList[3].flag, activator.tag, activator, activator.layer)) Activate(CheckList[0].flag, CheckList[1].flag);
        }
    }

    [System.Serializable]
    public class Rule
    {
        public string name;
        public bool flag;
        public Rule(string new_name, bool new_flag)
        {
            name = new_name;
            flag = new_flag;
        }
    }
    [System.Serializable]
    public class Rule_Data
    {
        public string Tag;
        public GameObject Object;
        public int Layer = -1;
        public bool check(bool and, string tag = null, GameObject obj = null, int layer = -1)
        {
            if (and) return (Tag == null || Tag == tag) && (Object == null || Object == obj) && (Layer == -1 || Layer == layer);
            return (Tag != null && Tag == tag)||(Object != null && Object == obj) ||(Layer > -1 && Layer == layer);
        }
    }
}
