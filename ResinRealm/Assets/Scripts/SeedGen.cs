using System;
using UnityEngine;

public class SeedGen : MonoBehaviour
{
    
    public float seed;
    
    // Use this for initialization
    void Start()
    {
       
        
        seed = UnityEngine.Random.Range(-1000000f, 1000000f);

    }
  
    // Update is called once per frame
    void Update()
    {

    }
}
