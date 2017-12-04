using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerealBox : MonoBehaviour
{
    public float health = 20.0f;
    
    public CerealSpawner spawner;

    void OnDestroy()
    {
        spawner.noCerealPresent = true;
    }
}
