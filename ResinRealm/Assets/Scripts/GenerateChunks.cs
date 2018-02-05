using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateChunks : MonoBehaviour {

    public GameObject DirtTile;
    public GameObject GrassTile;
    public GameObject StoneTile;

    public int Width;
    public float HeightMultiplier;
    public int HeightAddition;
    public float smooth;
    [SerializeField]
    float seed;
    // Use this for initialization
    void Start () {


        Generate();
        seed = UnityEngine.Random.Range(-10000f, 10000f);
    }

    private void Generate()
    {

        for (int i = 0; i < Width; i++)
        {


            int perlinNoise = Mathf.RoundToInt(Mathf.PerlinNoise(seed, i / smooth) * HeightMultiplier) + HeightAddition;
            for (int j = 0; j < perlinNoise; j++)
            {
                
                GameObject selectedTile;
                if (j < perlinNoise - 4)
                {

                    selectedTile = StoneTile;

                }
                else if (j < perlinNoise - 1)
                {
                    selectedTile = DirtTile;

                }
                else {

                    selectedTile = GrassTile;

                }
                Instantiate(selectedTile, new Vector3(i, j), Quaternion.identity);
                



            }


        }
           

    }
}
