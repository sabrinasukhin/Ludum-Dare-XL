using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Camera cam;
    public GameObject bulletPrefab;
    public int shootSpeed;
    GameObject tempProjectile;

    void Update()
    {
        Aim();
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        tempProjectile = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
        tempProjectile.GetComponent<Rigidbody>().AddForce(tempProjectile.transform.forward * shootSpeed);
    }

    void Aim()
    {
        float screenX = Screen.width / 2;
        float screenY = Screen.height / 2;
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(new Vector3(screenX, screenY));
        if (Physics.Raycast(ray, out hit))
        {
            transform.LookAt(hit.point);
        }
    }

}
