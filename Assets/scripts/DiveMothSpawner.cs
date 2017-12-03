using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiveMothSpawner : MonoBehaviour
{
    public float minInterval = 20.0f;
    public float maxInterval = 60.0f;
    
    public Transform player;
    public GameObject mothPrefab;
    
    private float timeToNextSpawn;
    private float intervalRange;

	// Use this for initialization
	void Start ()
    {
		intervalRange = maxInterval - minInterval;
        timeToNextSpawn = intervalRange * Random.value;
	}
	
	// Update is called once per frame
	void Update ()
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
        GameObject newMoth = Instantiate(mothPrefab, transform.position, transform.rotation);
        newMoth.GetComponent<MothDiver>().player = player;
    }
}
