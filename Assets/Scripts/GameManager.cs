using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public PlayerManager player;

    public void Awake()
    {
        // Check to see if singleton already exists
        if (instance == null)
        {
            // Create singleton by assigning it to this game object
            instance = this;

            // Prevents this game object from getting destroyed when we change scenes
            DontDestroyOnLoad(gameObject);
        }
        // The singleton exists already -> destroy this game object
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
