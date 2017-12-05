using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerealBox : MonoBehaviour
{
    public float health = 20.0f;
    public AudioSource audioMothEat;
    
    public CerealSpawner spawner;
    
    public GameObject ashPrefab;
    
    float healthPrev = 20.0f;
    
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
            return health;
        }
        return 0;
    }

    void OnDestroy()
    {
        spawner.noCerealPresent = true;
    }
}
