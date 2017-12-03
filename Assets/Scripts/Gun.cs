using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float force = 100f;
    public Camera cam;
    public GameObject projectile;
    GameObject tempProjectile;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Aim();
		if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
	}

    void Shoot()
    {
        tempProjectile = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
        tempProjectile.GetComponent<Rigidbody>().AddForce(tempProjectile.transform.forward * force);
    }

    void Aim()
    {
        float screenX = Screen.width / 2;
        float screenY = Screen.height / 2;
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(new Vector3(screenX, screenY));
        if (Physics.Raycast(ray, out hit))
        {
            //Debug.Log(hit.transform.name);
            transform.LookAt(hit.point);
        }
    }
}
