using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{

    [SerializeField] public Text tutText;
    [SerializeField] public Text orbText;
    [SerializeField] public string newText;
    [SerializeField] public bool isOrbTut;

    //private float destroyTimer;
    //private Color textColO;
    //private Color textColT;

    // Start is called before the first frame update
    void Start()
    {
        //destroyTimer = -1;
        /*
        textColO = tutText.color;
        //textColT = tutText.color;  //  makes a new color
        textColO.a = 0.0f; // makes the color transparent
        if(isOrbTut)
        {
            //orbText.enabled = false;
        }
        //tutText.enabled = false;
        */
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(destroyTimer > 0)
        {
            destroyTimer -= Time.deltaTime;
        }
        else
        {
            //tutText.enabled = false;
            //tutText.color = textColT;
            tutText.text = "";
        }
        */
    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Tutorial");
        if(isOrbTut)
        {
            //orbText.enabled = true;
            //orbText.color = textColO;
            orbText.text = "Orbs Collected 0/5";
        }
        //tutText.enabled = true;
        //tutText.color = textColO;
        //textColO.a = 1;
        //tutText.text = newText;
        //Debug.Log(newText);
        tutText.text = newText;
        //destroyTimer = 5f;
    }
    private void OnCollisionExit(Collision collision)
    {
        tutText.text = "";
    }
}
