using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bullet;
    public float shootSpeed = 3;
    
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Camera cam = (Camera)(this.gameObject.GetComponent(typeof(Camera)));
            
            GameObject bullInst = Instantiate(bullet, cam.transform.position, cam.transform.rotation);
            
            Rigidbody brb = (Rigidbody)(bullInst.GetComponent(typeof(Rigidbody)));
            
            brb.velocity = cam.transform.rotation * (new Vector3(0, 0, shootSpeed));
        }
    }
}
