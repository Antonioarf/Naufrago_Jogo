using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Spawn : MonoBehaviour
{
    private Tilemap tilemap;
    public Tilemap Fim;
    public Tilemap Grade;
    public int holeSize;
    private int wallStart;
    private int wallEnd;
    private int onde;
    private int qual;


void Start() {
    tilemap = GetComponent<Tilemap>();
    BoundsInt bounds = tilemap.cellBounds;

    int randomWall = Random.Range(0, 4);
    if (randomWall == 0) {
        wallStart = bounds.min.y; // assuming the wall starts at index 0
        wallEnd = bounds.max.y; // assuming the wall ends at index 10
        qual = bounds.min.x;
        onde =  Random.Range(wallStart, wallEnd);
        if (onde+holeSize >wallEnd){
            onde = onde - holeSize;
        }
    }
    else if (randomWall == 1) {
        wallStart = bounds.min.x; // assuming the wall starts at index 0
        wallEnd = bounds.max.x; // assuming the wall ends at index 10
        qual = bounds.max.y;
        onde =  Random.Range(wallStart, wallEnd);
        if (onde+holeSize >wallEnd){
            onde = onde - holeSize;
        }
    }
    else if (randomWall == 2) {
        wallStart = bounds.min.y; // assuming the wall starts at index 0
        wallEnd = bounds.max.y; // assuming the wall ends at index 10
        qual = bounds.max.x;
        onde =  Random.Range(wallStart, wallEnd);
        if (onde+holeSize >wallEnd){
            onde = onde - holeSize;
        }
    }
    

    else if (randomWall == 3) {
        wallStart = bounds.min.x; // assuming the wall starts at index 0
        wallEnd = bounds.max.x; // assuming the wall ends at index 10
        qual = bounds.min.y;
        onde =  Random.Range(wallStart, wallEnd);
        if (onde+holeSize >wallEnd){
            onde = onde - holeSize;
        }
    }
    DeleteWallSection2(Grade, randomWall);
    DeleteWallSection(tilemap, onde,qual,randomWall);
}   

 void DeleteWallSection(Tilemap tilemap, int startIndex,  int x, int randomWall)
    {
    if (randomWall == 0){
        for (int i = startIndex; i <= startIndex+holeSize; i++){tilemap.SetTile(new Vector3Int(x, i, 0), null);}
        Fim.gameObject.transform.position =  new Vector3((x+42-15)*((float) 0.3), (startIndex+24+15)*((float) 0.3), 0);
        }
    else if (randomWall == 1){
        for (int i = startIndex; i <= startIndex+holeSize; i++){tilemap.SetTile(new Vector3Int(i, x-1, 0), null);}
        Fim.gameObject.transform.position =  new Vector3((startIndex+42)*((float) 0.3), (x+24+15)*((float) 0.3), 0);
        }
    else if (randomWall == 2){
        for (int i = startIndex; i <= startIndex+holeSize; i++){tilemap.SetTile(new Vector3Int(x-1, i, 0), null);}
        Fim.gameObject.transform.position =  new Vector3((x+42)*((float) 0.3), (startIndex+24+15)*((float) 0.3), 0);
        }
    else if (randomWall == 3){
        for (int i = startIndex; i <= startIndex+holeSize; i++) {tilemap.SetTile(new Vector3Int(i, x, 0), null);}
        Fim.gameObject.transform.position =  new Vector3((startIndex+42)*((float) 0.3), (x+24)*((float) 0.3), 0);
        }
    }


    void DeleteWallSection2(Tilemap spn,  int randomWall)
    {
    int x =spn.cellBounds.min.x;
    int y=spn.cellBounds.min.x;
    if (randomWall == 0){
        for (int i = y; i <= 0; i++){spn.SetTile(new Vector3Int(x+15, i, 0), null);}        
        }
    else if (randomWall == 1){
        for (int i = x; i <= 0; i++){spn.SetTile(new Vector3Int(i, y+2, 0), null);}
        }
    else if (randomWall == 2){
        for (int i = y; i <= 0; i++){spn.SetTile(new Vector3Int(x+1, i, 0), null);}        
        }
    else if (randomWall == 3){
        for (int i = x; i <= 0; i++) {spn.SetTile(new Vector3Int(i, y+17, 0), null);}
        }
    }
    // Update is called once per frame
    void Update()
    {
            ///Destroy(gameObject);    

    }

    

}


