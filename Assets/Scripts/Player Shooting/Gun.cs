using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class Gun : MonoBehaviour
{
    [SerializeField] private Projection projection;
    [SerializeField]
    private GameObject KineticBullet;
    [SerializeField] private GameObject GhostBullet;
    [SerializeField] private GameObject GravityBullet;
    [SerializeField] private GameObject LiftBullet;
    [SerializeField]
    private GameObject firingPoint;
    [SerializeField]
    private Vector3 bulletSpeed;
    public float _Force;

    public GunChangeMode gunChangeMode;

    private bool isGhostInit = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if(!isGhostInit)
        //{
            //projection.Initialize(GhostBullet.GetComponent<Bullet>(), firingPoint.transform.position, firingPoint.transform.forward * _Force);
        //    isGhostInit = true;
        //}


        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        if(Input.GetMouseButton(0))
        {
            projection.SimulateTrajectory(GhostBullet.GetComponent<Bullet>(), firingPoint.transform.position, firingPoint.transform.forward * _Force);
        }
    

    }

    private void FixedUpdate()
    {
    }
    public void Shoot()
    {
        Debug.Log("ShooTING");
        if(gunChangeMode.mode == 0)
        {
            GameObject bullet = Instantiate(KineticBullet, firingPoint.transform.position, transform.rotation);
            Bullet _bulletCode = bullet.GetComponent<Bullet>();
            _bulletCode.Init(firingPoint.transform.forward * _Force, false);
        }
        else if(gunChangeMode.mode == 1)
        {
            GameObject bullet = Instantiate(GravityBullet, firingPoint.transform.position, transform.rotation);
            Bullet _bulletCode = bullet.GetComponent<Bullet>();
            _bulletCode.Init(firingPoint.transform.forward * _Force, false);
        }
        else if (gunChangeMode.mode == 2)
        {
            GameObject bullet = Instantiate(LiftBullet, firingPoint.transform.position, transform.rotation);
            Bullet _bulletCode = bullet.GetComponent<Bullet>();
            _bulletCode.Init(firingPoint.transform.forward * _Force, false);
        }

    }



}
