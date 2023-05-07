using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform shootPointTransform;
    [SerializeField] private ParticleSystem smokeEffect;
    [SerializeField] private float fireRate;
    [SerializeField] private float fireRateDelta;

    //private float fireRate;
    //private float fireRateDelta;

    public void Fire()
    {
        if(fireRateDelta <= 0)
        {
            Instantiate(projectile, shootPointTransform.position, shootPointTransform.rotation);
            smokeEffect.Play();
        }
    }

    public void Start()
    {
        //fireRate = 2f;
        //fireRateDelta = 0;
    }

    public void Update()
    {
        fireRateDelta -= Time.deltaTime;
        if (fireRateDelta <= 0)
        {
            Fire();
            fireRateDelta = fireRate;
        }
    }
}
