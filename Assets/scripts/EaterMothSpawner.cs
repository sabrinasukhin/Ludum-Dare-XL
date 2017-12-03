using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaterMothSpawner : MonoBehaviour
{
    public float minInterval = 20.0f;
    public float maxInterval = 60.0f;
    
    public GameObject mothPrefab;
    public CerealSpawner target;
    
    public bool noMoth = true;
    
    private float timeToNextSpawn;
    private float intervalRange;

	void Start ()
    {
        Destroy(GetComponent<MeshRenderer>());  //spawner should be invisible
        
        intervalRange = maxInterval - minInterval;  //set up timing
        timeToNextSpawn = intervalRange * Random.value;
        
		noMoth = true;
	}
	
	void Update ()
    {
        if(!noMoth)
            return;
        
		timeToNextSpawn -= Time.deltaTime;
        
        if(timeToNextSpawn <= 0)
        {
            SpawnMoth();
            timeToNextSpawn = minInterval + (intervalRange * Random.value);
        }
	}
    
    void SpawnMoth()
    {
        GameObject newMoth = Instantiate(mothPrefab, transform.position, transform.rotation);
        
        MothEater eatScript = newMoth.GetComponent<MothEater>();
        eatScript.spawner = this;
        eatScript.target = target;
        
        noMoth = false;
    }
}
