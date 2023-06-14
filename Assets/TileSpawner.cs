using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEngine.RuleTile.TilingRuleOutput;

//spawns and deletes tiles as the player moves
public class TileManager : MonoBehaviour
{

    private DrillMover drillMover;
    public Grid grid;
    public Tilemap tilemap;

    public int spawnBelowY = 10;
    public int deleteAboveY = 10;


    public int[] mileStones = new int[5];
    public Tile[] tiles = new Tile[6];
    public float[] curveSpeed = new float[6];
    private Tile currentTile;


    // Start is called before the first frame update
    void Start()
    {
        drillMover = gameObject.GetComponent<DrillMover>();
        currentTile = tiles[0];
        drillMover.curveSpeed = curveSpeed[0];
    }


    // Update is called once per frame
    void Update()
    {
        if (DrillMover.gameStarted)
        {
            //update to other rock layer after passing a milestone
            for (int i = 0; i < mileStones.Length; i++)
            {
                if (-(transform.position.y - spawnBelowY) > mileStones[i])
                {
                    currentTile = tiles[i + 1];
                }

                if (-transform.position.y > mileStones[i])
                {
                    drillMover.curveSpeed = curveSpeed[i + 1];
                }

            }
           
          
            SpawnRowBelow();
            DeleteRowAbove();

            Vector3Int position = grid.WorldToCell(transform.position);
            tilemap.SetTile(position, null);

        }



    }

    //delete a row of tiles above the specified row
    private void DeleteRowAbove()
    {
        int upperY = grid.WorldToCell(transform.position).y + deleteAboveY;

        BoundsInt bounds = tilemap.cellBounds;
        Vector3Int minPos = bounds.min;
        Vector3Int maxPos = bounds.max;

         for (int x = minPos.x; x < maxPos.x; x++)
        {
            Vector3Int position = new Vector3Int(x, upperY, 0); 
            tilemap.SetTile(position, null); 
        }
    }

    // spawns a row of tiles below the specified row
    private void SpawnRowBelow()
    {

        int lowerY = grid.WorldToCell(transform.position).y - spawnBelowY;

        BoundsInt bounds = tilemap.cellBounds;
        Vector3Int minPos = bounds.min;
        Vector3Int maxPos = bounds.max;

        for (int x = minPos.x; x < maxPos.x; x++)
        {
            Vector3Int position = new Vector3Int(x, lowerY, 0); // Set the position of each tile in the row
            if (tilemap.GetTile(position) != null)
            {
                continue;
            }
           
            tilemap.SetTile(position, currentTile); // Set the tile at the specified position
        }
    }

}