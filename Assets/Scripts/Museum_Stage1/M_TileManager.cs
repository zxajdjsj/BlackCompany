using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_TileManager : MonoBehaviour
{
    GameObject[,] Tile = new GameObject[15, 20];

    public GameObject Tile_Prefab;

    int tile_pos_x = -10;
    float tile_pos_y = 5.5f;

    public static M_TileManager instance;
    private void Awake()
    {
        instance = this;
        for (int y = 0; y < 15; y++)
        {
            for (int x = 0; x < 20; x++)
            {
                Tile[y, x] = Instantiate(Tile_Prefab, new Vector3(tile_pos_x, tile_pos_y, 0), Quaternion.identity, GameObject.Find("Tile").transform);
                Tile[y, x].name = "Tile[" + y + "," + x + "]";
                tile_pos_x++;
            }
            tile_pos_y--;
            tile_pos_x = -10;
        }

    }

    public bool CheckTileEdge(int playerMoveNum, GameObject hit_tile) //플레이어의 앞에 타일 가장자리 블럭이 있는지 확인하는 함수
    {
        if(playerMoveNum == 0) //상
        {
            for (int i = 0; i < 20; i++)
            {
                if (hit_tile.name == "Tile[0," + i + "]")
                    return false;
            }
        }
        else if(playerMoveNum == 1) //하
        {
            for (int i = 0; i < 20; i++)
            {
                if (hit_tile.name == "Tile[14," + i + "]")
                    return false;
            }
        }
        else if (playerMoveNum == 2) //좌
        {
            for (int i = 0; i < 15; i++)
            {
                if (hit_tile.name == "Tile[" + i + ",0]")
                    return false;
            }
        }
        else if (playerMoveNum == 3) //우
        {
            for (int i = 0; i < 15; i++)
            {
                if (hit_tile.name == "Tile[" + i + ",19]")
                    return false;
            }
        }
        return true;
    }

}//end class
