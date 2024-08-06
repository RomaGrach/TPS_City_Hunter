using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catsceneController : MonoBehaviour
{

    public GameObject catscene;
    public GameObject player;
    public GameObject heilout;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void endCatscene()
    {
        player.SetActive(true);
        catscene.SetActive(false);
        heilout.SetActive(true);
    }

    public void Helikout()
    {
        heilout.SetActive(false);
    }
}
