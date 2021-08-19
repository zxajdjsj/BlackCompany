using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //상하좌우 이동 제어 변수
    [HideInInspector]
    public bool[,] blockmove_udlr_control = new bool[14,4]; //블럭14개 방향 4개

    //SelectObject 함수 관련 변수
    GameObject target = null;
    Vector2 pos;
    RaycastHit2D hit;

    //블럭끼리의 충돌 관련 변수
    //상
    RaycastHit2D[] block_hit_up; //맞닿은 모든 물체 배열
    RaycastHit2D block_hit_up_element;  //요소
    //하
    RaycastHit2D[] block_hit_down; 
    RaycastHit2D block_hit_down_element;
    //좌
    RaycastHit2D[] block_hit_left; 
    RaycastHit2D block_hit_left_element;  
    //우
    RaycastHit2D[] block_hit_right;
    RaycastHit2D block_hit_right_element;

    //특수블럭 사용시
    RaycastHit2D block_hit_up_2_element;  //요소
    RaycastHit2D block_hit_down_2_element;  //요소

    //블럭 선택시 사용하는 LayerMask
    //int lm = 1 << LayerMask.NameToLayer("Desert_Object");

    //오브젝트를 선택하고 난뒤 블럭을 움직이기 위해 사용하는 변수
    bool moveblock = false;

    //빠른 초기화를 위한 변수
    int restrict_ud_block = 3;
    int restrict_lr_block = 0;

    //광선길이 조절
    public float raylength = 2f;

    //가장자리와 부딪혔을시 관련 변수 + 가장자리에서 움직임변수 바꾸는거랑 블럭끼리 충돌했을때 움직임변수 바꾸는거랑 겹침 -> 가장자리에서 움직임변수 값 바꾸는게 우선순위가 위라 그거 설정하려함.
    public bool[,] manage_blockMovement_contactedEdge = new bool[14, 4]; //14: 오브젝트 번호 4: 상하좌우

    static public Block instance;
    private void Awake()
    {
        instance = this;

        //맨 처음 위치에 따른 bool값 초기화를 다르게 해주기!
        //4,5,6,11,12,13,14 block이 상하(0,1) 3,4,5,10,11,12,13
        //1,2,3,7,8,9,10 block이 좌우(2,3) -> 0,1,2,6,7,8,9
        for (int y=0; y<14; y++)
        {
            for(int x=0; x<4; x++)
            {
                blockmove_udlr_control[y, x] = true;
                manage_blockMovement_contactedEdge[y, x] = true;
            }
        }

        for (int y = 0; y < 14; y++)
        {
            if(restrict_ud_block == y)
            {
                for (int x = 2; x <= 3; x++) //상하 블럭의 좌우 움직임 제한
                {
                    blockmove_udlr_control[y, x] = false;
                    manage_blockMovement_contactedEdge[y, x] = false;
                    //Debug.Log("[" + y + "," + x + "] = " + blockmove_udlr_control[y, x]);
                }
                if (restrict_ud_block == 5)
                {
                    restrict_ud_block = 10;
                    continue;
                }
                ++restrict_ud_block;
                continue;
            }
            if(restrict_lr_block == y)
            {
                for (int x = 0; x <= 1; x++) //좌우 블럭의 상하 움직임 제한
                {
                    blockmove_udlr_control[y, x] = false;
                    manage_blockMovement_contactedEdge[y, x] = false;
                   // Debug.Log("[" + y + "," + x + "] = " + blockmove_udlr_control[y, x]);
                }

                if (restrict_lr_block == 2)
                {
                    restrict_lr_block = 6;
                    continue;
                }
                  
                ++restrict_lr_block;
            }
            
        }

        //맵의 가장자리에서 해당방향으로 움직이는 블럭 움직임 제한
        // 오브젝트번호    [ , ]
        //      1           0,2
        //      2           1,2
        //      3           2,3
        //      4           3,1
        //      5           4,1
        //      6           5,0
        //      9           8,2
        //      12          11,1

        //1번 오브젝트 - 왼쪽 제한
        blockmove_udlr_control[0, 2] = false;
        manage_blockMovement_contactedEdge[0, 2] = false;
        //2번 오브젝트 - 왼쪽 제한
        blockmove_udlr_control[1, 2] = false;
        manage_blockMovement_contactedEdge[1, 2] = false;
        //3번 오브젝트 - 오른쪽 제한
        blockmove_udlr_control[2, 3] = false;
        manage_blockMovement_contactedEdge[2, 3] = false;
        //4번 오브젝트 - 아래쪽 제한
        blockmove_udlr_control[3, 1] = false;
        manage_blockMovement_contactedEdge[3, 1] = false;
        //5번 오브젝트 - 아래쪽 제한
        blockmove_udlr_control[4, 1] = false;
        manage_blockMovement_contactedEdge[4, 1] = false;
        //6번 오브젝트 - 위쪽 제한
        blockmove_udlr_control[5, 0] = false;
        manage_blockMovement_contactedEdge[5, 0] = false;
        //9번 오브젝트 - 왼쪽 제한
        blockmove_udlr_control[8, 2] = false;
        manage_blockMovement_contactedEdge[8, 2] = false;
        //12번 오브젝트 - 아래쪽 제한
        blockmove_udlr_control[11, 1] = false;
        manage_blockMovement_contactedEdge[11, 1] = false;
    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Manage_TileEdge(); //가장자리와 블럭이 닿았을시 제한걸어서 못움직이게함

        //맵 제한 걸기
        //if (target != null)
        //{
        //    target.transform.position = new Vector3(Mathf.Clamp(target.transform.position.x, -4.5f, 4.5f)  //x
        //                        , Mathf.Clamp(target.transform.position.y, -4.5f, 4.5f) //y
        //                        , 0);                                            //z
        //}

        SelectBlock();
        if (moveblock)
        {
            MoveBlock();
        }

        if(target !=null)
        {
            ContactBlock();
            //Debug.DrawRay(target.transform.position, target.transform.right * raylength, Color.blue);
            //Debug.DrawRay(target.transform.position, -target.transform.right * raylength, Color.blue);

        }
    }

    void MoveBlock()
    {
        if(Input.GetKeyUp(KeyCode.UpArrow))
        {
            Debug.Log("Up");
            //해당 키의 움직임이 true일경우만

            if(blockmove_udlr_control[ReturnBlockNum(target.name) - 1 , 0])
            {
                target.transform.position = new Vector3(target.transform.position.x, target.transform.position.y + 1, 0);
            }      
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            Debug.Log("Down");
            //해당 키의 움직임이 true일경우만
            if (blockmove_udlr_control[ReturnBlockNum(target.name) - 1, 1])
            {
                target.transform.position = new Vector3(target.transform.position.x, target.transform.position.y - 1, 0);
            }
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Debug.Log("Left");
            //해당 키의 움직임이 true일경우만
            if (blockmove_udlr_control[ReturnBlockNum(target.name) - 1, 2])
            {
                target.transform.position = new Vector3(target.transform.position.x - 1, target.transform.position.y , 0);
            }
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            Debug.Log("Right");
            //해당 키의 움직임이 true일경우만
            if (blockmove_udlr_control[ReturnBlockNum(target.name) - 1, 3])
            {
                target.transform.position = new Vector3(target.transform.position.x + 1, target.transform.position.y , 0);
            }
        }
    }

    void SelectBlock()
    {
        //4,5,6,11,12,14,15 block이 상하
        //1,2,3,7,8,9,10 block이 좌우

        if(Input.GetMouseButtonUp(0))
        {
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hit = Physics2D.Raycast(pos, Vector2.zero, 0f,LayerMask.GetMask("Block")); //Block Layer를 가진 애들만 충돌체크 ㅠㅠ 너무 찾던 내용

            if (hit.collider != null) //오류내용: 콜라이더가 겹치는 부분이 문제, 그래서 특정 객체만 클릭하려고 tag를 이용하려하는데 그 tag가 있는곳만 선택됨. ->layermask이용해서 해결완료
            {
                target = hit.transform.gameObject;
                Debug.Log("타겟이름 : " + target.name);
             
                moveblock = true;
            }
        }
    }

    void ContactBlock() //블럭끼리 맞닿아있을때 못움직이게하는 함수
    {
        bool enableMove = false; //블럭이 움직일수있느냐 없느냐

        ControlRayLength(); //블럭마다의 맞는 광선길이 조절
        //오류가 될만한 사항: 이 함수에서 맞닿은 물체가 없을시 움직임을 true로 바꿔줌. 근데 Tile의 꼭짓점부분이라 움직이면 안되는데 true로 바꿔줘서 움직이게 될 수 있음.
        //조건달아야함. 상하로만 움직이는 물체일때 
       
        if(target.tag == "Block_UD") //상하
        {
            if(target.name == "Block_11")
            {
                RaycastHit2D[] block_hit_up_2 = Physics2D.RaycastAll(new Vector3(target.transform.position.x + 0.5f,target.transform.position.y, 0)
                                                                     , target.transform.up, raylength, LayerMask.GetMask("Block")); //블럭 기준 위방향
                RaycastHit2D[] block_hit_down_2 = Physics2D.RaycastAll(new Vector3(target.transform.position.x + 0.5f, target.transform.position.y, 0)
                                                                    , -target.transform.up, raylength, LayerMask.GetMask("Block")); //블럭 기준 아래방향


                block_hit_up = Physics2D.RaycastAll(new Vector3(target.transform.position.x - 0.5f, target.transform.position.y, 0)
                                                                    , target.transform.up, raylength, LayerMask.GetMask("Block")); //블럭 기준 위방향
                block_hit_down = Physics2D.RaycastAll(new Vector3(target.transform.position.x - 0.5f, target.transform.position.y, 0)
                                                                    , -target.transform.up, raylength, LayerMask.GetMask("Block")); //블럭 기준 아래방향


                for (int i = 0; i < block_hit_up.Length; i++)
                {
                    block_hit_up_element = block_hit_up[i];
                    //Debug.Log(i+"번째 요소 : "+block_hit_up[i].collider.gameObject.name);
                }
                for (int i = 0; i < block_hit_up_2.Length; i++)
                {
                    block_hit_up_2_element = block_hit_up_2[i];
                    //Debug.Log(i+"번째 요소 : "+block_hit_up[i].collider.gameObject.name);
                }
                for (int i = 0; i < block_hit_down.Length; i++)
                {
                    block_hit_down_element = block_hit_down[i];
                }

                for (int i = 0; i < block_hit_down_2.Length; i++)
                { 
                    block_hit_down_2_element = block_hit_down_2[i];
                }

                if (block_hit_up.Length >= 2 || block_hit_up_2.Length >=2) //hit에는 자기자신도 포함되기 때문에 자기자신을 제외한 물체들이 있을 경우
                {
                    enableMove = false;
                    ControlBlockMovement_if_ContactBlock(0, enableMove);
                }
                else
                {
                    enableMove = true;
                    ControlBlockMovement_if_ContactBlock(0, enableMove);

                }
                if (block_hit_down.Length >= 2 || block_hit_down_2.Length >=2)
                {
                    enableMove = false;
                    ControlBlockMovement_if_ContactBlock(1, enableMove);

                }
                else
                {
                    enableMove = true;
                    ControlBlockMovement_if_ContactBlock(1, enableMove);
                }
                return;
            }
            block_hit_up = Physics2D.RaycastAll(target.transform.position, target.transform.up, raylength, LayerMask.GetMask("Block")); //블럭 기준 위방향
            block_hit_down = Physics2D.RaycastAll(target.transform.position, -target.transform.up, raylength, LayerMask.GetMask("Block")); //블럭 기준 위방향

            for (int i = 0; i < block_hit_up.Length; i++)
            {
                block_hit_up_element = block_hit_up[i];
                //Debug.Log(i+"번째 요소 : "+block_hit_up[i].collider.gameObject.name);
            }
            for (int i = 0; i < block_hit_down.Length; i++)
            {
                block_hit_down_element = block_hit_down[i];
            }

            if (block_hit_up.Length >= 2) //hit에는 자기자신도 포함되기 때문에 자기자신을 제외한 물체들이 있을 경우
            {
                enableMove = false;
                ControlBlockMovement_if_ContactBlock(0, enableMove);
            }
            else
            {
                enableMove = true;
                ControlBlockMovement_if_ContactBlock(0, enableMove);

            }
            if (block_hit_down.Length >= 2)
            {
                enableMove = false;
                ControlBlockMovement_if_ContactBlock(1, enableMove);

            }
            else
            {
                enableMove = true;
                ControlBlockMovement_if_ContactBlock(1, enableMove);
            }
        }
       else if (target.tag == "Block_LR") //좌우
        {
            
            block_hit_left = Physics2D.RaycastAll(target.transform.position, -target.transform.right, raylength, LayerMask.GetMask("Block")); //블럭 기준 왼쪽방향
            block_hit_right = Physics2D.RaycastAll(target.transform.position, target.transform.right, raylength, LayerMask.GetMask("Block")); //블럭 기준 오른쪽방향

            for (int i = 0; i < block_hit_left.Length; i++)
            {
                block_hit_left_element = block_hit_left[i];
                //Debug.Log(i+"번째 요소 : "+block_hit_up[i].collider.gameObject.name);
            }
            for (int i = 0; i < block_hit_right.Length; i++)
            {
                block_hit_right_element = block_hit_right[i];
            }

            if (block_hit_left.Length >= 2) //hit에는 자기자신도 포함되기 때문에 자기자신을 제외한 물체들이 있을 경우
            {
                enableMove = false;
                ControlBlockMovement_if_ContactBlock(2, enableMove);
            }
            else
            {
                enableMove = true;
                ControlBlockMovement_if_ContactBlock(2, enableMove);

            }
            if (block_hit_right.Length >= 2)
            {
                enableMove = false;
                ControlBlockMovement_if_ContactBlock(3, enableMove);

            }
            else
            {
                enableMove = true;
                ControlBlockMovement_if_ContactBlock(3, enableMove);
            }
        }


    }

    public int ReturnBlockNum(string target_name) //전역변수 target을 사용함에도 매개변수를 쓴이유 다른 스크립트에서 매개변수로 쓰기위함
    {
        if (hit.collider != null)
        {
            switch (target.name) //for문을 통해 더 좋은 코드를 만드는것도 해보자 나중에
            {
                case "Block_1":
                    return 1;

                case "Block_2":
                    return 2;

                case "Block_3":
                    return 3;

                case "Block_4":
                    return 4;

                case "Block_5":
                    return 5;

                case "Block_6":
                    return 6;

                case "Block_7":
                    return 7;

                case "Block_8":
                    return 8;

                case "Block_9":
                    return 9;

                case "Block_10":
                    return 10;

                case "Block_11":
                    return 11;

                case "Block_12":
                    return 12;

                case "Block_13":
                    return 13;

                case "Block_14":
                    return 14;

                default:
                    return -1;

            }

        }
        else
        {
            switch (target_name) //for문을 통해 더 좋은 코드를 만드는것도 해보자 나중에
            {
                case "Block_1":
                    return 1;

                case "Block_2":
                    return 2;

                case "Block_3":
                    return 3;

                case "Block_4":
                    return 4;

                case "Block_5":
                    return 5;

                case "Block_6":
                    return 6;

                case "Block_7":
                    return 7;

                case "Block_8":
                    return 8;

                case "Block_9":
                    return 9;

                case "Block_10":
                    return 10;

                case "Block_11":
                    return 11;

                case "Block_12":
                    return 12;

                case "Block_13":
                    return 13;

                case "Block_14":
                    return 14;

                default:
                    return -1;

            }
        }

    }

    void ControlRayLength()
    {
        switch(target.name)
        {
            case "Block_1":
                raylength = 1.5f;
                break;
            case "Block_2":
                raylength = 2f;
                break;
            case "Block_3":
                raylength = 2.5f;
                break;
            case "Block_4":
                raylength = 1.5f;
                break;
            case "Block_5":
            case "Block_6":
                raylength = 2f;
                break;
            case "Block_7":
            case "Block_8":
            case "Block_9":
            case "Block_10":
                raylength = 2f;
                break;
            case "Block_11": //2개의 ray 만들기
                raylength = 2f;
                break;
            case "Block_12":
                raylength = 3f;
                break;
            case "Block_13":
                raylength = 2.5f;
                break;
            case "Block_14":
                raylength = 1.5f;
                break;

        }    
    }

    void ControlBlockMovement_if_ContactBlock(int udlr, bool enableMove)
    {
        if (manage_blockMovement_contactedEdge[ReturnBlockNum(target.name)-1, udlr]) 
        {
            switch (target.name)
            {
                case "Block_1":
                    blockmove_udlr_control[0, udlr] = enableMove;
                    break;
                case "Block_2":
                    blockmove_udlr_control[1, udlr] = enableMove;
                    break;
                case "Block_3":
                    blockmove_udlr_control[2, udlr] = enableMove;
                    break;
                case "Block_4":
                    blockmove_udlr_control[3, udlr] = enableMove;
                    break;
                case "Block_5":
                    blockmove_udlr_control[4, udlr] = enableMove;
                    break;
                case "Block_6":
                    blockmove_udlr_control[5, udlr] = enableMove;
                    break;
                case "Block_7":
                    blockmove_udlr_control[6, udlr] = enableMove;
                    break;
                case "Block_8":
                    blockmove_udlr_control[7, udlr] = enableMove;
                    break;
                case "Block_9":
                    blockmove_udlr_control[8, udlr] = enableMove;
                    break;
                case "Block_10":
                    blockmove_udlr_control[9, udlr] = enableMove;
                    break;
                case "Block_11": 
                    blockmove_udlr_control[10, udlr] = enableMove;
                    break;
                case "Block_12":
                    blockmove_udlr_control[11, udlr] = enableMove;
                    break;
                case "Block_13":
                    blockmove_udlr_control[12, udlr] = enableMove;
                    break;
                case "Block_14":
                    blockmove_udlr_control[13, udlr] = enableMove;
                    break;
            }
        }      
    }


}//end class


//

//void Manage_TileEdge() //tile_value값에 해당 오브젝트 번호값이 있으면 그에 맞는 상하좌우 움직임을 제한한다.
//{
//    int blockmove_udlr = -1; //상하좌우 어떤것을 제한해야하는지 알려주는 상수값

//    //수정방향 : 자기가 닿아있는 부분이 하나라도 해당 오브젝트의 번호값을 가진다면 해당방향으로 못움직이게
//    //상하로 움직이는 블록이랑 좌우로 움직이는 블록이랑 나눠서 코드 짜면 될듯. 

//    for (int y = 0; y < 10; y++)
//    {
//        for (int x = 0; x < 10; x++)
//        {
//            if (y == 0) //0행 --> 상
//            {
//                blockmove_udlr = 0;
//                Manage_BlockMovement_TIleEdge(Tile_ManageMent.instance.tile_value[y, x], blockmove_udlr);
//            }
//            if (y == 9) //9행 --> 하
//            {
//                blockmove_udlr = 1;
//                Manage_BlockMovement_TIleEdge(Tile_ManageMent.instance.tile_value[y, x], blockmove_udlr);

//            }
//            if (x == 0) //0열 --> 좌
//            {
//                blockmove_udlr = 2;
//                Manage_BlockMovement_TIleEdge(Tile_ManageMent.instance.tile_value[y, x], blockmove_udlr);

//            }
//            if (x == 9) //9열 --> 우
//            {
//                blockmove_udlr = 3;
//                Manage_BlockMovement_TIleEdge(Tile_ManageMent.instance.tile_value[y, x], blockmove_udlr);

//            }

//        }
//    }
//}

//void Manage_BlockMovement_TIleEdge(int tile_value, int blockmove_udlr)
//{
//    if (tile_value < 0)
//    {
//        switch (tile_value)
//        {
//            case -1:
//                blockmove_udlr_control[0, blockmove_udlr] = true;
//                break;
//            case -2:
//                blockmove_udlr_control[1, blockmove_udlr] = true;
//                break;
//            case -3:
//                blockmove_udlr_control[2, blockmove_udlr] = true;
//                break;
//            case -4:
//                blockmove_udlr_control[3, blockmove_udlr] = true;
//                break;
//            case -5:
//                blockmove_udlr_control[4, blockmove_udlr] = true;
//                break;
//            case -6:
//                blockmove_udlr_control[5, blockmove_udlr] = true;
//                break;
//            case -7:
//                blockmove_udlr_control[6, blockmove_udlr] = true;
//                break;
//            case -8:
//                blockmove_udlr_control[7, blockmove_udlr] = true;
//                break;
//            case -9:
//                blockmove_udlr_control[8, blockmove_udlr] = true;
//                break;
//            case -10:
//                blockmove_udlr_control[9, blockmove_udlr] = true;
//                break;
//            case -11:
//                blockmove_udlr_control[10, blockmove_udlr] = true;
//                break;
//            case -12:
//                blockmove_udlr_control[11, blockmove_udlr] = true;
//                break;
//            case -13:
//                blockmove_udlr_control[12, blockmove_udlr] = true;
//                break;
//            case -14:
//                blockmove_udlr_control[13, blockmove_udlr] = true;
//                break;

//        }
//    }
//    else if (tile_value > 0)
//    {
//        switch (tile_value)
//        {

//            case 1:
//                blockmove_udlr_control[0, blockmove_udlr] = false;
//                break;
//            case 2:
//                blockmove_udlr_control[1, blockmove_udlr] = false;
//                break;
//            case 3:
//                blockmove_udlr_control[2, blockmove_udlr] = false;
//                break;
//            case 4:
//                blockmove_udlr_control[3, blockmove_udlr] = false;
//                break;
//            case 5:
//                blockmove_udlr_control[4, blockmove_udlr] = false;
//                break;
//            case 6:
//                blockmove_udlr_control[5, blockmove_udlr] = false;
//                break;
//            case 7:
//                blockmove_udlr_control[6, blockmove_udlr] = false;
//                break;
//            case 8:
//                blockmove_udlr_control[7, blockmove_udlr] = false;
//                break;
//            case 9:
//                blockmove_udlr_control[8, blockmove_udlr] = false;
//                break;
//            case 10:
//                blockmove_udlr_control[9, blockmove_udlr] = false;
//                break;
//            case 11:
//                blockmove_udlr_control[10, blockmove_udlr] = false;
//                break;
//            case 12:
//                blockmove_udlr_control[11, blockmove_udlr] = false;
//                break;
//            case 13:
//                blockmove_udlr_control[12, blockmove_udlr] = false;
//                break;
//            case 14:
//                blockmove_udlr_control[13, blockmove_udlr] = false;
//                break;

//        }
//    }

//}
