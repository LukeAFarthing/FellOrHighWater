using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyManager : MonoBehaviour
{

    [SerializeField] private GameObject playerBody;
    [SerializeField] private GameObject playerPatch;
    [SerializeField] private bool inGame;

    public static bool hard = false;
    public static bool red = false;

    private void Start()
    {
        if(inGame && red)
        {
            //Debug.Log("Changing color");
            var playerRenderer = playerBody.GetComponent<Renderer>();
            var patchRenderer = playerPatch.GetComponent<Renderer>();
            Color customColor = new Color(1f, 0f, 0f, 1.0f);
            playerRenderer.material.SetColor("_Color", customColor);
            patchRenderer.material.SetColor("_Color", customColor);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Menu")
        {
            hard = SettingsManager.isHardMode;
            red = SettingsManager.isRedMode;
        }
        //Debug.Log("Hard mode: " + hard + " Red mode: " + red);
    }
}
