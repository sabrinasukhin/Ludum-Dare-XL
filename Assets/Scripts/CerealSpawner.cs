using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerealSpawner : MonoBehaviour
{

    public List<GameObject> spawnList = new List<GameObject>();

    void Start ()
    {
        int num1 = Random.Range(0, 3);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
