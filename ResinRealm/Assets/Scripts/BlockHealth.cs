using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHealth : MonoBehaviour {

    public float health;
    BlockHealthManage manage;



    // Update is called once per frame
    public void Start()
    {

        

    }


    public void Update() {



        


            
     
       

	}

    public void death()
    {
        
    }

    public void shot(float damage) {

        manage = GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<BlockHealthManage>();
        health -= damage;
        if (health <= 0)
        {

            manage.destroyBlock(this.gameObject);
            
        }
    }

}
