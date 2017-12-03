using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothHit : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Moth")
        {
            Destroy(collider.gameObject);
            Destroy(gameObject);
            Debug.Log("die");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
