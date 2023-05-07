using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private Transform cameraTransform;

    private Vector3 cameraOffset;
    private float cameraMoveSpeed;
    
    // Start is called before the first frame update
    private void Start()
    {
        cameraOffset = new Vector3(0f, 8f, -12f);
        cameraMoveSpeed = 5f;
    }

    // Update is called once per frame
    private void Update()
    {
        // Figure out where the camera should be
        Vector3 cameraEndPosition = playerManager.playerTransform.position + cameraOffset;

        // Move the camera to the correct position progressively
        cameraTransform.position = Vector3.Lerp(cameraTransform.position, cameraEndPosition, Time.deltaTime * cameraMoveSpeed);
    }
}
