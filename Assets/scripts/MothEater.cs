using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothEater : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 3.0f;
    
    public EaterMothSpawner spawner;
    public CerealSpawner target;
    
    public GameObject diveMothPrefab;
    
    private Animator anim;
    private bool chasing = false;
    private Transform targetTransform;
    
	void Start ()
    {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(!(chasing || target.noCerealPresent))
            BeginChase();
        
        if(chasing && target.noCerealPresent)
            BecomeDiver();
        
        if(!chasing)
            return;
        
        //move towards cereal
        
        transform.Rotate(Vector3.up * -90);

        Rigidbody rb = GetComponent<Rigidbody>();

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            Quaternion.LookRotation((targetTransform.position - transform.position + Vector3.up * 0.5f)),
            Time.deltaTime * rotationSpeed
        );

        rb.velocity = transform.rotation * Vector3.forward * moveSpeed;

        transform.Rotate(Vector3.up * 90);
	}
    
    void BeginChase()
    {
        chasing = true;
        targetTransform = target.gameObject.transform;
    }
    
    void BecomeDiver()
    {
        GameObject player = GameObject.FindGameObjectsWithTag("MainCamera")[0];
        
        GameObject newMoth = Instantiate(diveMothPrefab, transform.position, transform.rotation);
        
        MothDiver diveScript = newMoth.GetComponent<MothDiver>();
        
        diveScript.player = player.transform;
        diveScript.chasing = true;
        
        Destroy(gameObject);
    }
    
    void OnDestroy()
    {
        spawner.noMoth = true;
    }
}
