using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollows : MonoBehaviour
{
    public Transform target;
    public float speed;
    private  PlayerHealths playerHealth;
    
    
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        


    }

    // Update is called once per frame
    private void FixedUpdate()
    

    {
        
       transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);


      
    }

   


}

