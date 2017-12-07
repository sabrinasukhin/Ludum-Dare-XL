using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothDiver : MonoBehaviour
{
    public float startDistance = 4.0f;
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 3.0f;
    public float damage = 14.0f;

    public Transform player;
    
    public AudioSource audioFly;

    private Animator anim;
    public bool chasing = false;

    private GameObject plr;
    
    public DiveMothSpawner spawner;
    
    private bool hasHurtPlayer = false;

    // Use this for initialization
    void Start()
    {
        plr = player.gameObject;
        
        anim = GetComponent<Animator>();
    }
    
    bool PlayerInRange()
    {
        if(Vector3.Distance(player.position, transform.position) > startDistance)
            return false;
        
        bool linecast = Physics.Linecast(transform.position, player.position, (1 << 9));
        
        return !linecast;
    }

    // Update is called once per frame
    void Update()
    {
        if (!chasing)
        {
            if (PlayerInRange())
                BeginChase();
            else
                return;
        }

        //the following math relies on the moth facing "forward", which the model does not.
        transform.Rotate(Vector3.up * -90);
        
        Rigidbody rb = GetComponent<Rigidbody>();
        
        //slowly rotate towards the correct direction
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            Quaternion.LookRotation((player.position - transform.position)),
            Time.deltaTime * rotationSpeed
        );
        
        rb.AddForce(transform.rotation * Vector3.forward * moveSpeed - rb.velocity, ForceMode.VelocityChange);

        //correctly reorient model
        transform.Rotate(Vector3.up * 90);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (!hasHurtPlayer && collider.tag == "Player")
        {
            plr.GetComponent<Health>().LoseHealth(damage);
            Destroy(gameObject);
            hasHurtPlayer = true;
        }
    }
    
    void OnDestroy()
    {
        spawner.numMoths--;
    }

    public void BeginChase()
    {
        chasing = true;
        anim.SetBool("IsFlying", true);
        
        audioFly.loop = true;
        audioFly.Play();
    }
}
