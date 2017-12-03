﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerealBox : MonoBehaviour
{
    public CerealSpawner spawner;

	void OnDestroy()
    {
        spawner.noCerealPresent = true;
    }
}