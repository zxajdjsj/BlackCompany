using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Tile_Manage : MonoBehaviour
{
    //프리팹 
    public GameObject TileCollider;


    //각 타일들의 게임오브젝트
    public GameObject[,] tile = new GameObject[10, 18];

    //타일들의 게임오브젝트 행(y) 초기화를 위한 변수
    int tile_y = 4;

    static public Tile_Manage instance;
    private void Awake()
    {
        instance = this;

        for(int y=0; y<10; y++)
        {
            for(int x=0; x<18; x++)
            {
                tile[y,x] = Instantiate(TileCollider,
                                        new Vector3(x-9,tile_y,0),
                                        Quaternion.identity);
                tile[y, x].name = "TileCollider[" + y +","+ x+"]";
                //Debug.Log("tile[" + y + "," + x + "] : "+ tile[y,x] );
            }
            --tile_y;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(TileCollider,new Vector3(-9,-5,0),Quaternion.identity);
        //Instantiate(TileCollider,new Vector3(-9,4,0),Quaternion.identity);

        //Instantiate(TileCollider,new Vector3(8,-5,0),Quaternion.identity);
        //Instantiate(TileCollider,new Vector3(8,4,0),Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //TileMap Collider2d를 통해 구현해 보려했지만 실패했다. 더는 안될듯 
    //그래서 Collider에 쓸 오브젝트 하나 Prefab 시키고 그 하나를 바탕으로 각 타일들의 위치에 생성하려고 계획중

    //--------------------------------------------------------------------------------------------------------------------
    //private void OnMouseOver()
    //{
    //    //try : 오류가 발생하는 구문을 포함시킨다.
    //    //catch : 오류가 발생했을 떄 실행시킬 구문이다. 

    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    //Debug.DrawRay(ray.origin, ray.direction * 10, Color.blue, 3.5f);

    //    RaycastHit2D hit = Physics2D.Raycast(ray.origin, Vector3.zero);

    //    if (this.tilemap == hit.transform.GetComponent<Tilemap>())
    //    {
    //        this.tilemap.RefreshAllTiles();
    //        int x, y;
    //        //이게 핵심인듯. 이게 각각의 타일들의 위치값을 받아온다.
    //        //그래서 어떤 위치값에서 상하좌우키를 비활성화할지를 설정한다.
    //        x = this.tilemap.WorldToCell(ray.origin).x;
    //        y = this.tilemap.WorldToCell(ray.origin).y;
    //        Vector3Int v3lnt = new Vector3Int(x, y, 0);

    //        this.tilemap.SetTileFlags(v3lnt, TileFlags.None);

    //        this.tilemap.SetColor(v3lnt, Color.red);
            
    //        Debug.Log("x : " + x);
    //        Debug.Log("y : " + y);
    //    }
    //}

    //각각의 타일들에 대한 위치값과 정보들을 관리하기 위해서는 Grid를 통해 접근해야한다.
    //origin+cell Size를 통해 타일이 어디에 위치해있느냐에따라서 코드를 짤 수 있을듯.

    //private void OnMouseExit()
    //{
    //    this.tilemap.RefreshAllTiles();
    //}

    //---------------------------------------------------------------------------------------------------------------------



    ////이렇게 아니면 그냥 플레이어의 위치가 어떨때 상하좌우 비활성화 이렇게 해야할듯
    //void SetAllTile()
    //{
    //    //foreach 문은 배열의 값들을 보여주는 용도 (읽기전용)
    //    //배열의 값 수정 불가
    //    foreach (var position in tilemap.cellBounds.allPositionsWithin)
    //    {
    //        if (!tilemap.HasTile(position))
    //        {
    //            continue;
    //        }
    //        //x 18  y 10
    //        Debug.Log(position);
    //    }
    //}

    //void SetAllTile_2()
    //{
    //    tileMap = transform.GetComponentInParent<Tilemap>();
    //    availablePlaces = new List<Vector3>();

    //    for (int n = tileMap.cellBounds.xMin; n < tileMap.cellBounds.xMax; n++)
    //    {
    //        for (int p = tileMap.cellBounds.yMin; p < tileMap.cellBounds.yMax; p++)
    //        {
    //            Debug.Log(tileMap.cellBounds.xMin);
    //            Debug.Log(tileMap.cellBounds.xMax);
    //            Debug.Log(tileMap.cellBounds.yMin);
    //            Debug.Log(tileMap.cellBounds.yMax);
    //            Vector3Int localPlace = (new Vector3Int(n, p, (int)tileMap.transform.position.y));
    //            Vector3 place = tileMap.CellToWorld(localPlace);
    //            if (tileMap.HasTile(localPlace))
    //            {
    //                //Tile at "place"
    //                availablePlaces.Add(place);
    //                //Debug.Log(place);
    //               // tile_2[n+10,p+5] = place;
    //                //Debug.Log("tile_2["+(n+10)+","+(p+5)+"] : " + tile_2[n+10,p+5]);
    //            }
    //            else
    //            {
    //                //No tile at "place"
    //            }
    //        }
    //    }
    //}
}//end class
