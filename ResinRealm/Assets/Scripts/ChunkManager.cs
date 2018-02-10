using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class ChunkManager : NetworkBehaviour {

    public GameObject DirtTile;
    public GameObject GrassTile;
    public GameObject StoneTile;

    public int Width;
    public float HeightMultiplier;
    public int HeightAddition;
    public float smooth;



    public GameObject tileCoal;
    public GameObject tileIron;
    public GameObject tileRuby;
    public GameObject tileGold;

    public float percCoal;
    public float percRuby;
    public float percGold;
    public float percIron;
    //SeedGen __seedGen;



    public float seed;





    // Use this for initialization
    void Start () {

       // __seedGen = GameObject.FindGameObjectWithTag("Player").GetComponent<SeedGen>();
        Generate();
        
        
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

                var newTile = Instantiate(selectedTile, Vector3.zero, Quaternion.identity) as GameObject;
                NetworkServer.Spawn(newTile);
                newTile.transform.parent = this.gameObject.transform;
                newTile.transform.localPosition = new Vector3(i, j);
                



            }


        }

        PopulateOres();

    }

    private void PopulateOres()
    {
        foreach (GameObject t in GameObject.FindGameObjectsWithTag("TileStone")) {

            if (t.transform.parent == this.gameObject.transform) {

                float r = UnityEngine.Random.Range(0f, 100f);
                GameObject selectedTile = null;


                if (r < percRuby)
                {
                    selectedTile = tileRuby;
                }
                else if (r < percGold) {

                    selectedTile = tileGold;

                }
                else if (r < percIron) {

                    selectedTile = tileIron;
                }
                else if (r < percCoal) {

                    selectedTile = tileCoal;

                }



                if (selectedTile != null) {


                    Debug.Log("test");
                    var newResourceTile = Instantiate(selectedTile, t.transform.position, Quaternion.identity) as GameObject;
                    NetworkServer.Spawn(newResourceTile);
                    newResourceTile.transform.parent = this.gameObject.transform;
                    Destroy(t);

                }





            }



        }
    }
}
