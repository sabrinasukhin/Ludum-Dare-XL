using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    void Start()
    {
        if (gameObject.name == "Projectile(Clone)")
        {
            Destroy(gameObject, 2.50f);
        }
    }
}