using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Team currentPlayer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            currentPlayer = (Team)(((int)currentPlayer + 1) % 4);
        }

        //Ray ray = new Ray(Camera.main.ScreenToWorldPoint(Input.mousePosition), Camera.main.transform.forward);

        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.name);
                if(hit.transform.tag == "Player")
                {
                    //hit.transform.position = new Vector3(hit.transform.position.x + 1, hit.transform.position.y, hit.transform.position.z);

                    Piece piece = hit.transform.GetComponent<Piece>();

                    if(piece.team == currentPlayer)
                    {
                        if (piece.inBase)
                        {
                            TileManager tileManager = FindObjectOfType<TileManager>();
                            //Tile currentTile = piece.currentTile.GetComponent<Tile>();
                            GameObject nextTile = null;
                            switch (piece.team)
                            {
                                case Team.red:
                                    nextTile = tileManager.tiles[(int)StartTile.red];
                                    break;
                                case Team.blue:
                                    nextTile = tileManager.tiles[(int)StartTile.blue];
                                    break;
                                case Team.green:
                                    nextTile = tileManager.tiles[(int)StartTile.green];
                                    break;
                                case Team.yellow:
                                    nextTile = tileManager.tiles[(int)StartTile.yellow];
                                    break;
                            }

                            piece.MoveToPosition(nextTile.transform.position, nextTile);
                            piece.inBase = false;
                        }
                        else
                        {
                            TileManager tileManager = FindObjectOfType<TileManager>();
                            Tile currentTile = piece.currentTile.GetComponent<Tile>();
                            GameObject nextTile = tileManager.tiles[currentTile.arrayId + 1];

                            piece.MoveToPosition(nextTile.transform.position, nextTile);
                        }
                    }
                }
            }
        }
	}
}
