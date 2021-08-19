using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_ManageMent : MonoBehaviour
{
    //타일 배열
    [HideInInspector]
    public GameObject[,] Tile = new GameObject[10, 10];
    public int[,] tile_value = new int[10, 10]; //타일의 가장자리와 부딪혔는지 알기위해 부딪혔을시 값을 넣어줄거임. 가장자리의 부분만 사용, 편의를 위해 10,10사용

    //타일 프리팹
    public GameObject Tile_Prefab;

    //타일 배열 초기화 관련 변수
    float tile_x = -4.5f;
    float tile_y = 4.5f;


    static public Tile_ManageMent instance;
    private void Awake()
    {
        instance = this;

        for(int y=0; y<10; y++)
        {
            tile_x = -4.5f;
            for (int x=0; x<10; x++)
            {
                //나중에 Tile오브젝트의 하위객체로 넣으면 좋을듯 복사본들을
                Tile[y, x] = Instantiate(Tile_Prefab, new Vector3(tile_x, tile_y, 0), Quaternion.identity);
                Tile[y, x].name = "Tile[" + y + "," + x + "]";
                ++tile_x;
            }
            --tile_y;
        }

        for(int y=1; y<=8; y++)
        {
            for(int x=1; x<=8; x++)
            {
                Tile[y, x].GetComponent<Collider2D>().enabled = false; //맵의 끝에서만 콜라이더를 이용하기 때문에 필요없는 부분들 콜라이더 끄기
            }
        }

        for(int y=0; y<10; y++)
        {
            for(int x=0; x<10; x++)
            {
                tile_value[y, x] = 0; 
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}//end class
