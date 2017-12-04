using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiveMothSpawner : MonoBehaviour
{
    public float minInterval = 20.0f;
    public float maxInterval = 60.0f;
    
    public GameObject mothPrefab;
    
    private float timeToNextSpawn;
    private float intervalRange;
    private Vector3 bottomOrigin;
    
    private Transform player;

	void Start ()
    {
        player = GameObject.FindGameObjectsWithTag("MainCamera")[0].transform;
        
        Destroy(GetComponent<MeshRenderer>());  //spawner should be invisible
        
		intervalRange = maxInterval - minInterval;  //set up timing
        timeToNextSpawn = intervalRange * Random.value;
        
        bottomOrigin = (transform.rotation * (new Vector3(0.0f, -transform.localScale.y/2.0f, 0.0f))) + transform.position; //origin of bottom of spawner
	}
	
	void Update ()  //handles spawn timing
    {
		timeToNextSpawn -= Time.deltaTime;
        
        if(timeToNextSpawn <= 0)
        {
            SpawnMoth();
            timeToNextSpawn = minInterval + (intervalRange * Random.value);
        }
	}
    
    void SpawnMoth()
    {
        GameObject newMoth = Instantiate(mothPrefab);
        
        newMoth.transform.position = (transform.rotation * (new Vector3((Random.value-0.5f)*transform.localScale.x, newMoth.transform.position.y, (Random.value-0.5f)*transform.localScale.z))) + bottomOrigin;
        newMoth.transform.rotation = transform.rotation;
        
        newMoth.GetComponent<MothDiver>().player = player;
    }
}
