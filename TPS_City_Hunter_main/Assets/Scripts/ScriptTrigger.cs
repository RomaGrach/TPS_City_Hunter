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
    private bool Continue;
    public bool DebugCheck = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Continue = true;
        if (CheckList[0].flag) dialogObj = gameObject.GetComponent<DialogScript>(); 
        if (CheckList[1].flag) questObj = gameObject.GetComponent<QuestScript>();
        if (dialogObj == null && questObj == null) { Debug.Log("No quest or dialog scripts");  Continue = false; }
        if (CheckList[5].flag && Continue) Activate();
    }

    private void Activate()
    {
        if (DebugCheck) Debug.Log($"Activated! Continue:{Continue}");
        if (CheckList[0].flag) dialogObj.trigger();
        if (CheckList[1].flag) questObj.trigger();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (DebugCheck) Debug.Log($"Collided! Flag:{CheckList[3].flag} Continue:{Continue}");
        if (CheckList[3].flag && Continue)
        {
            GameObject collider = other.gameObject;

            if (AdditionalData.check(CheckList[2].flag, collider.tag, collider, collider.layer)) Activate();
        }
    }
    private void OnClick(GameObject activator = null)
    {
        if (DebugCheck) Debug.Log($"Clicked! Flag:{CheckList[4]} Continue:{Continue}");
        if (CheckList[4].flag && Continue)
        {
            if (AdditionalData.check(CheckList[2].flag, activator.tag, activator, activator.layer)) Activate();
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
            Debug.Log($"Check tag:{Tag}, name:{Object.name}, layer:{Layer}");
            Debug.Log($"Object tag:{tag}, name:{obj.name}, layer:{layer}");
            bool ans;
            if (and)
            {
                ans = (Tag == null || Tag == tag) && (Object == null || Object == obj) && (Layer <= -1 || Layer == layer);
                //Debug.Log($"check:{ans}");
                return ans;
            }
            ans = (Tag != null && Tag == tag) || (Object != null && Object == obj) || (Layer > -1 && Layer == layer);
            Debug.Log($"check:{ans}");
            return ans;
        }
    }
}
