using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_ManageMent_1 : MonoBehaviour
{

    //start end 표시 블럭
    public GameObject Start_Tile;
    public GameObject End_Tile;

    //블럭이 안닿았을 시 물이 흐르도록 보이게 하기위한 이미지 프리팹
    public GameObject Waterway_H_flow; //프리팹: 원래 타일맵에서 스프라이트를 바꿔야하는데 방법을 모르겠어서 수로 위에 이미지 덮어씌우는 방식으로 대체함
    public GameObject Waterway_V_flow;
    public GameObject Waterway_left_up_flow;
    public GameObject Waterway_left_down_flow;
    public GameObject Waterway_right_up_flow;
    public GameObject Waterway_right_down_flow;



    //수로 오브젝트 배열
    [HideInInspector]
    public GameObject[] WaterFlow_Object = new GameObject[25];

    //수로 오브젝트가 활성화 여부 배열
    [HideInInspector]
    public bool[] setactive_WaterFlow = new bool[25]; 

    //타일 배열
    [HideInInspector]
    public GameObject[,] Tile = new GameObject[10, 10];
    

    //타일 프리팹
    public GameObject Tile_Prefab;

    //타일 배열 초기화 관련 변수
    float tile_x = -4.5f;
    float tile_y = 4.5f;


    static public Tile_ManageMent_1 instance;
    private void Awake()
    {
        instance = this;

        for (int y = 0; y < 10; y++)
        {
            tile_x = -4.5f;
            for (int x = 0; x < 10; x++)
            {
                //나중에 Tile오브젝트의 하위객체로 넣으면 좋을듯 복사본들을
                Tile[y, x] = Instantiate(Tile_Prefab, new Vector3(tile_x, tile_y, 0), Quaternion.identity);
                Tile[y, x].name = "Tile[" + y + "," + x + "]";
                ++tile_x;
            }
            --tile_y;
        }

        //for (int y = 1; y <= 8; y++)
        //{
        //    for (int x = 1; x <= 8; x++)
        //    {
        //        Tile[y, x].GetComponent<Collider2D>().enabled = false; //맵의 끝에서만 콜라이더를 이용하기 때문에 필요없는 부분들 콜라이더 끄기
        //    }
        //}

        //물이 흐르는 이미지 오브젝트 생성 : 좌->우 순으로 번호 매김
        WaterFlow_Object[0] = Instantiate(Waterway_V_flow, Tile[0, 0].transform.position, Quaternion.identity);
        WaterFlow_Object[1] = Instantiate(Waterway_left_down_flow, Tile[1, 0].transform.position, Quaternion.identity);
        WaterFlow_Object[2] = Instantiate(Waterway_H_flow, Tile[1, 1].transform.position, Quaternion.identity);
        WaterFlow_Object[3] = Instantiate(Waterway_right_up_flow, Tile[1, 2].transform.position, Quaternion.identity);
        WaterFlow_Object[4] = Instantiate(Waterway_V_flow, Tile[2, 2].transform.position, Quaternion.identity);
        WaterFlow_Object[5] = Instantiate(Waterway_V_flow, Tile[3, 2].transform.position, Quaternion.identity);
        WaterFlow_Object[6] = Instantiate(Waterway_left_up_flow, Tile[4, 2].transform.position, Quaternion.identity);
        WaterFlow_Object[7] = Instantiate(Waterway_H_flow, Tile[4, 3].transform.position, Quaternion.identity);
        WaterFlow_Object[8] = Instantiate(Waterway_H_flow, Tile[4, 4].transform.position, Quaternion.identity);
        WaterFlow_Object[9] = Instantiate(Waterway_H_flow, Tile[4, 5].transform.position, Quaternion.identity);
        WaterFlow_Object[10] = Instantiate(Waterway_right_up_flow, Tile[4, 6].transform.position, Quaternion.identity);
        WaterFlow_Object[11] = Instantiate(Waterway_V_flow, Tile[5, 2].transform.position, Quaternion.identity);
        WaterFlow_Object[12] = Instantiate(Waterway_V_flow, Tile[5, 6].transform.position, Quaternion.identity);
        WaterFlow_Object[13] = Instantiate(Waterway_V_flow, Tile[6, 2].transform.position, Quaternion.identity);
        WaterFlow_Object[14] = Instantiate(Waterway_V_flow, Tile[6, 6].transform.position, Quaternion.identity);
        WaterFlow_Object[15] = Instantiate(Waterway_left_down_flow, Tile[7, 2].transform.position, Quaternion.identity);
        WaterFlow_Object[16] = Instantiate(Waterway_H_flow, Tile[7, 3].transform.position, Quaternion.identity);
        WaterFlow_Object[17] = Instantiate(Waterway_H_flow, Tile[7, 4].transform.position, Quaternion.identity);
        WaterFlow_Object[18] = Instantiate(Waterway_H_flow, Tile[7, 5].transform.position, Quaternion.identity);
        WaterFlow_Object[19] = Instantiate(Waterway_right_down_flow, Tile[7, 6].transform.position, Quaternion.identity);
        WaterFlow_Object[20] = Instantiate(Waterway_left_down_flow, Tile[8, 6].transform.position, Quaternion.identity);
        WaterFlow_Object[21] = Instantiate(Waterway_H_flow, Tile[8, 7].transform.position, Quaternion.identity);
        WaterFlow_Object[22] = Instantiate(Waterway_right_up_flow, Tile[8, 8].transform.position, Quaternion.identity);
        WaterFlow_Object[23] = Instantiate(Waterway_left_down_flow, Tile[9, 8].transform.position, Quaternion.identity);
        WaterFlow_Object[24] = Instantiate(Waterway_H_flow, Tile[9, 9].transform.position, Quaternion.identity);

        //물이 흐르는 이미지 오브젝트 물체와 맞닿아 있는거 비활성화
        //WaterFlow_Object[0].SetActive(false);
        //WaterFlow_Object[1].SetActive(false);
        //WaterFlow_Object[2].SetActive(false);
        //WaterFlow_Object[3].SetActive(false);
        //WaterFlow_Object[5].SetActive(false);
        //WaterFlow_Object[12].SetActive(false);
        //WaterFlow_Object[14].SetActive(false);
        //WaterFlow_Object[15].SetActive(false);
        //WaterFlow_Object[16].SetActive(false);
        //WaterFlow_Object[18].SetActive(false);
        //WaterFlow_Object[21].SetActive(false);
        //WaterFlow_Object[22].SetActive(false);
        //WaterFlow_Object[23].SetActive(false);
        //WaterFlow_Object[24].SetActive(false);

        //물이 흐르는 이미지 오브젝트 전부 비활성화
        for(int i=0; i<25; i++)
        {
            WaterFlow_Object[i].SetActive(false);
            setactive_WaterFlow[i] = false;
        }

        setactive_WaterFlow[4] = true;
        setactive_WaterFlow[6] = true;
        setactive_WaterFlow[7] = true;
        setactive_WaterFlow[8] = true;
        setactive_WaterFlow[9] = true;
        setactive_WaterFlow[10] = true;
        setactive_WaterFlow[11] = true;
        setactive_WaterFlow[13] = true;
        setactive_WaterFlow[17] = true;
        setactive_WaterFlow[19] = true;
        setactive_WaterFlow[20] = true;

    }

    private void Update()
    {
        for(int i=0; i<25; i++)
        {
            if(i<=6)
            {
                if (Confirm_WaterFlowObject_0To6(i))
                {
                    WaterFlow_Object[i].SetActive(true);
                }
                else
                    WaterFlow_Object[i].SetActive(false);

            }
            else if ((i >= 7 && i <= 14) && (i != 11 && i != 13))
            {
                if (Confirm_WaterFlowObject_Branch_R(i))//7,8,9,10,12,14
                {
                    WaterFlow_Object[i].SetActive(true);
                }
                else
                    WaterFlow_Object[i].SetActive(false);

            }
            else if ((i >= 11 && i <= 18) && (i != 12 && i != 14))
            {
                if (Confirm_WaterFlowObject_Branch_D(i)) //11,13,15,16,17,18
                {
                    WaterFlow_Object[i].SetActive(true);
                }
                else
                    WaterFlow_Object[i].SetActive(false);

            }

            else if (i >= 19)
            {
                if (Confirm_WaterFlowObject_19To24(i)) //19~24
                {                  
                    WaterFlow_Object[i].SetActive(true);
                    if (i == 24) //사막 스테이지1 클리어
                    {
                        Start_Tile.GetComponent<SpriteRenderer>().color = new Color(0,40,255,255);
                        End_Tile.GetComponent<SpriteRenderer>().color = new Color(0,40,255,255);
                    }
                }
                else
                {
                    WaterFlow_Object[i].SetActive(false);
                }
            }

        }
        
    }

    //이전까지의 수로가 활성화되어있는지 확인하는 함수
    public bool Confirm_WaterFlowObject_0To6(int input) //0~6인덱스의 수로가 활성화되어있는지 검사
    {
        //자기자신까지의 수로의 배열모두가 장애물과 맞닿아있지도 않은 상태라면 true
        for (int i=0; i<=input; i++)
        {
            if (!setactive_WaterFlow[i]) 
                return false;

        }
        return true;
    }

    public bool Confirm_WaterFlowObject_Branch_R(int input)//7,8,9,10,12,14  수로가 활성화되어있는지 검사 + 0~6검사
    {
        if (Confirm_WaterFlowObject_0To6(6))
        {
            for (int i = 7; i <= input; i++)
            {
                if (i == 11)
                    continue;
                else if (i == 13)
                    continue;

                if (!setactive_WaterFlow[i])
                    return false;
               
            }
            return true;
        }
        else
            return false;      
    }

    public bool Confirm_WaterFlowObject_Branch_D(int input) //11,13,15,16,17,18 수로가 활성화되어있는지 검사 + 0~6검사
    {
        if (Confirm_WaterFlowObject_0To6(6))
        {
            for (int i = 11; i <= input; i++)
            {
                if (i == 12)
                    continue;
                else if (i == 14)
                    continue;

                if (!setactive_WaterFlow[i])
                    return false;           
            }
            return true;
        }
        else
            return false;    
    }

    public bool Confirm_WaterFlowObject_19To24(int input) //19~24 수로가 활성화되어있는지 검사 + 나머지 전체검사 
    {
        if (Confirm_WaterFlowObject_0To6(6) && (Confirm_WaterFlowObject_Branch_R(14) || Confirm_WaterFlowObject_Branch_D(18)))
        {
            for (int i = 19; i <= input; i++)
            {
                if (!setactive_WaterFlow[i])
                    return false;
            }
            return true;
        }
        else
            return false;
    }

}//end class
