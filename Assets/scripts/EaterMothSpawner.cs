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
    
    private Vector3 bottomOrigin;
    
    private float timeToNextSpawn;
    private float intervalRange;

	void Start ()
    {
        bottomOrigin = (transform.rotation * (new Vector3(0.0f, -transform.localScale.y/2.0f, 0.0f))) + transform.position;
        
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
        GameObject newMoth = Instantiate(mothPrefab, bottomOrigin, transform.rotation);
        
        MothEater eatScript = newMoth.GetComponent<MothEater>();
        eatScript.spawner = this;
        eatScript.target = target;
        
        noMoth = false;
        
        target.numMoths++;
    }
}
