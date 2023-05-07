using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingWallManager : MonoBehaviour
{
    public Transform wallTransform;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(wallTransform.position.y <= -500)
        {
            Destroy(gameObject);
        }
    }
}
