using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerControl : MonoBehaviour {

    Rigidbody rbd;
    Camera cam;
    public int speedFactor = 40;
    public float fireDelay = 0.1f;
    public float delayBeforeNextFire = 0;
    public GameObject bulletPrefab;

	// Use this for initialization
	void Start () {
        rbd = GetComponent<Rigidbody>();
        cam = FindObjectOfType<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(inputX, 0, inputY);
        rbd.MovePosition(rbd.position + movement * speedFactor * Time.deltaTime);
        OrientatePlayer();
        ProcessFire();
    }

    private void ProcessFire()
    {
        delayBeforeNextFire -= Time.deltaTime;
        if (Input.GetAxis("Fire1") != 0)
        {
            if(delayBeforeNextFire <= 0)
            {
                ShotBullet();
                delayBeforeNextFire = fireDelay;
            }
        }
    }

    private void ShotBullet()
    {
        GameObject bulletObject = Instantiate(bulletPrefab, transform.position + (transform.forward * 2), transform.rotation);
    }

    private Vector3 FindPositionOfMouse()
    {
        Vector3 result = new Vector3();
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000))
        {
            result.x = hit.point.x;
            result.y = hit.point.y;
            result.z = hit.point.z;
        }

        return result;
    }

    private void OrientatePlayer()
    {
        Vector3 result = FindPositionOfMouse();
        result.y = rbd.position.y;
        Vector3 relativePosition = result - transform.position;
        Quaternion quaternionRotation = Quaternion.LookRotation(relativePosition, Vector3.up);
        rbd.MoveRotation(quaternionRotation);
    }
}
