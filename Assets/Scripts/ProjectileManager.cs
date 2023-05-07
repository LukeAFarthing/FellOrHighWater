using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{

    [SerializeField] Transform projectileTransform;
    [SerializeField] GameObject projectileGameObject;

    private float projectileSpeed;
    private Vector3 origPosition;
    private float destroyTimer;

    // Start is called before the first frame update
    void Start()
    {
        projectileSpeed = 10f;
        origPosition = projectileTransform.position;
        destroyTimer = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0f, 0f, projectileSpeed * Time.deltaTime));
        destroyTimer -= Time.deltaTime;
        if (destroyTimer <= 0)
        {
            Destroy(projectileGameObject);
        }
    }
}
