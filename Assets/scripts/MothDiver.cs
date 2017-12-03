﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothDiver : MonoBehaviour 
{
    public float startDistance = 4.0f;
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 3.0f;
    
    public Transform player;
    
    private Animator anim;
    private bool chasing;

	// Use this for initialization
	void Start ()
    {
		chasing = false;
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(!chasing)
        {
            if(Vector3.Distance(player.position, transform.position) <= startDistance)
                BeginChase();
            else
                return;
        }
        
        transform.Rotate(Vector3.up * -90);
        
        Rigidbody rb = GetComponent<Rigidbody>();
        
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            Quaternion.LookRotation((player.position - transform.position)),
            Time.deltaTime * rotationSpeed
        );
        
        rb.velocity = transform.rotation * Vector3.forward * moveSpeed;
		
        transform.Rotate(Vector3.up * 90);
	}
    
    void BeginChase()
    {
        chasing = true;
        anim.SetBool("IsFlying", true);
    }
}