using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkGen : MonoBehaviour {




    public GameObject chunk;
    int chunkWidth;
    public int numCunks;
    [SerializeField]
    float seed;



    // Use this for initialization
    void Start () {

        chunkWidth = chunk.GetComponent<ChunkManager>().Width;
        seed = UnityEngine.Random.Range(-1000000f, 1000000f);
        Generate();
	}

    private void Generate()
    {

        int lastX = -chunkWidth;
        for (int i = 0; i < numCunks; i++)
        {

            GameObject newChunk = Instantiate(chunk, new Vector3(lastX + chunkWidth, 0f), Quaternion.identity);
            newChunk.GetComponent<ChunkManager>().seed = seed; //gets seed from the chunk manager and converts it to this seed
            lastX += chunkWidth;


        }

    }

   
}
