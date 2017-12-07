using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerealBox : MonoBehaviour
{
    public float health = 20.0f;
    public float mothEatenWeight = 0.65f;
    public AudioSource audioMothEat;
    
    public CerealSpawner spawner;
    
    public GameObject ashPrefab;
    
    private float healthStart;
    
    public void OnStart()
    {
        healthStart = health;
        
        if(mothEatenWeight > 1.0f)
            mothEatenWeight = 1.0f;
        else if(mothEatenWeight < 0.0f)
            mothEatenWeight = 0.0f;
    }
    
    public void Damage(float amt)
    {
        health -= amt;
        if(health <= 0)
        {
            GameObject ashes = Instantiate(ashPrefab, transform.position, transform.rotation);
            spawner.currentBox = ashes;
            audioMothEat.gameObject.transform.parent = null;
            audioMothEat.Play();
            Destroy(audioMothEat.gameObject, 5.0f);
            Destroy(gameObject);
        }
    }
    
    public bool CanHighlight()
    {
        try{
        return (spawner.numMoths <= 0);
        } catch(Exception e){}
        
        return true;
    }
    
    public float Eat()
    {
        if(spawner.numMoths <= 0)
        {
            Destroy(gameObject);
            return health*mothEatenWeight + healthStart*(1.0f-mothEatenWeight);
        }
        return 0;
    }

    void OnDestroy()
    {
        spawner.noCerealPresent = true;
    }
}
