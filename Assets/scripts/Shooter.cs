using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public float shootSpeed = 3.00f;
    public GameObject bulletPrefab;
    
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Camera cam = (Camera)(this.gameObject.GetComponent(typeof(Camera)));
            
            GameObject bullInst = Instantiate(bulletPrefab, cam.transform.position, cam.transform.rotation) as GameObject;
            
            Rigidbody brb = (Rigidbody)(bullInst.GetComponent(typeof(Rigidbody)));
            
            brb.velocity = cam.transform.rotation * (new Vector3(0, 0, shootSpeed));
        }
    }
}
