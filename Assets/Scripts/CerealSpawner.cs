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

    void Start ()
    {
        Destroy(GetComponent<MeshRenderer>());  //spawner should be invisible
        
        intervalRange = maxInterval - minInterval;  //set up timing
        timeToNextSpawn = intervalRange * Random.value;
        
        noCerealPresent = true;
    }
	
	void Update ()  //handles spawn timing
    {
        if(!noCerealPresent)
            return;
        
        timeToNextSpawn -= Time.deltaTime;
        
        if(timeToNextSpawn <= 0)
        {
            SpawnBox();
            timeToNextSpawn = minInterval + (intervalRange * Random.value);
        }
	}
    
    void SpawnBox()
    {
        int numBoxes = GameObject.FindGameObjectsWithTag("CerealBox").Length;
        
        if(numBoxes < maxCereals)
        {
            GameObject newBox = Instantiate(cerealPrefab, transform.position, transform.rotation);
            newBox.GetComponent<CerealBox>().spawner = this;
            newBox.transform.eulerAngles = new Vector3(0, Random.value*360, 0);
            
            noCerealPresent = false;
        }
    }
}
