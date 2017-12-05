using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerealSpawner : MonoBehaviour
{
    public float minInterval = 20.0f;
    public float maxInterval = 60.0f;
    
    public int maxCereals = 3;
    
    public GameObject cerealPrefab;
    
    public bool noCerealPresent = true;
    
    private float timeToNextSpawn;
    private float intervalRange;
    public GameObject currentBox;
    
    public int numMoths = 0;

    void Start ()
    {
        Destroy(GetComponent<MeshRenderer>());  //spawner should be invisible
        
        intervalRange = maxInterval - minInterval;  //set up timing
        timeToNextSpawn = intervalRange * UnityEngine.Random.value;
        
        noCerealPresent = true;
        numMoths = 0;
    }
	
	void Update ()  //handles spawn timing
    {
        if(!noCerealPresent)
            return;
        
        timeToNextSpawn -= Time.deltaTime;
        
        if(timeToNextSpawn <= 0)
        {
            SpawnBox();
            timeToNextSpawn = minInterval + (intervalRange * UnityEngine.Random.value);
        }
	}
    
    void SpawnBox()
    {
        int numBoxes = GameObject.FindGameObjectsWithTag("CerealBox").Length;
        
        if(numBoxes < maxCereals)
        {
            try {   //destroy currentBox if it exists; it may refer to a pile of ashes
                Destroy(currentBox);
            } catch(Exception e){}
            
            currentBox = Instantiate(cerealPrefab, transform.position, transform.rotation);
            currentBox.GetComponent<CerealBox>().spawner = this;
            currentBox.transform.eulerAngles = new Vector3(0, UnityEngine.Random.value*360, 0);
            
            noCerealPresent = false;
        }
    }
}
