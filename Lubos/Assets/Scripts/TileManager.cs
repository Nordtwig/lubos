using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StartTile { red = 15, blue = 1, green = 29, yellow = 43 };

public class TileManager : MonoBehaviour {

    public GameObject[] tiles;


	// Use this for initialization
	void Start () {
        for (int i = 0; i < tiles.Length; i++)
        {
            tiles[i].transform.name = i.ToString();
            tiles[i].GetComponent<Tile>().arrayId = i;
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
