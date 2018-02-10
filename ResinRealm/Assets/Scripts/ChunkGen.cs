using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ChunkGen : NetworkBehaviour {

    


    public GameObject chunk;
    int chunkWidth;
    public int numCunks;

    [SerializeField]
    SeedGen _seedGen;
   
    public void Update()
    {
        _seedGen = GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<SeedGen>();
        if (Input.GetKeyDown(KeyCode.L)) {


            GenerateTerrain();


        }

    }


  
    

   
    private void GenerateTerrain()
    {
        int lastX = -chunkWidth;
        for (int i = 0; i < numCunks; i++)
        {

            var newChunk = Instantiate(chunk, new Vector3(lastX + chunkWidth, 0f), Quaternion.identity);
            NetworkServer.Spawn(newChunk);
            newChunk.GetComponent<ChunkManager>().seed = _seedGen.seed; //gets seed from the chunk manager and converts it to this seed
            lastX += chunkWidth;


        }

    }


    // Use this for initialization
    void Start () {

        chunkWidth = chunk.GetComponent<ChunkManager>().Width;
        
        
	}

   

   
}
