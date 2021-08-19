using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockColliderManageMent : MonoBehaviour
{
    bool moveBlock = false; //움직임 값을 바꾸기 변하기 하게 위한 변수


    //오브젝트 이름순
    //            //                                  상하 움직임 배열인덱스
    //            //                     상 하 상 하  상  하
    //            //waterway4_V  : 0열   00 90        00  10
    //            //waterway5_V  : 6열   06 96        01  11
    //            //waterway6_V  : 4열   04 94        02  12
    //            //obstacle11_V : 2,3열 02 92 03 93  03  13
    //            //obstacle12_V : 5열   05 95        04  14
    //            //obstacle13_V : 9열   09 99        05  15
    //            //obstacle14_V : 3열   03 93        06  16

    //오브젝트 이름순
    //            //                          좌우움직임 배열인덱스
    //            //                  좌 우   좌  우     
    //            //waterway1_H : 4행 40 49   00  10
    //            //waterway2_H : 7행 70 79   01  11
    //            //waterway3_H : 2행 20 29   02  12
    //            //obstacle7_H : 3행 30 39   03  13
    //            //obstacle8_H : 5행 50 59   04  14
    //            //obstacle9_H : 1행 10 19   05  15
    //            //obstacle10_H :9행 90 99   06  16

    private void OnTriggerEnter2D(Collider2D coll)
    {
        moveBlock = false;

        //좌우 
        //Block_1 4행  
        if (this.gameObject.name == "Block_1" && coll.name == "Tile[4,0]")
        {
            Block.instance.blockmove_udlr_control[0, 2] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[0, 2] = moveBlock;
        }
        if (this.gameObject.name == "Block_1" && coll.name == "Tile[4,9]")
        {
            Block.instance.blockmove_udlr_control[0, 3] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[0, 3] = moveBlock;
        }

        //Block_2 7행  
        if (this.gameObject.name == "Block_2" && coll.name == "Tile[7,0]")
        {
            Block.instance.blockmove_udlr_control[1, 2] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[1, 2] = moveBlock;
        }
        if (this.gameObject.name == "Block_2" && coll.name == "Tile[7,9]")
        {
            Block.instance.blockmove_udlr_control[1, 3] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[1, 3] = moveBlock;
        }

        //Block_3 2행  
        if (this.gameObject.name == "Block_3" && coll.name == "Tile[2,0]")
        {
            Block.instance.blockmove_udlr_control[2, 2] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[2, 2] = moveBlock;
        }
        if (this.gameObject.name == "Block_3" && coll.name == "Tile[2,9]")
        {
            Block.instance.blockmove_udlr_control[2, 3] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[2, 3] = moveBlock;
        }

        //Block_7 3행  
        if (this.gameObject.name == "Block_7" && coll.name == "Tile[3,0]")
        {
            Block.instance.blockmove_udlr_control[6, 2] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[6, 2] = moveBlock;
        }
        if (this.gameObject.name == "Block_7" && coll.name == "Tile[3,9]")
        {
            Block.instance.blockmove_udlr_control[6, 3] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[6, 3] = moveBlock;
        }

        //Block_8 5행  
        if (this.gameObject.name == "Block_8" && coll.name == "Tile[5,0]")
        {
            Block.instance.blockmove_udlr_control[7, 2] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[7, 2] = moveBlock;
        }
        if (this.gameObject.name == "Block_8" && coll.name == "Tile[5,9]")
        {
            Block.instance.blockmove_udlr_control[7, 3] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[7, 3] = moveBlock;
        }

        //Block_9 1행  
        if (this.gameObject.name == "Block_9" && coll.name == "Tile[1,0]")
        {
            Block.instance.blockmove_udlr_control[8, 2] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[8, 2] = moveBlock;
        }
        if (this.gameObject.name == "Block_9" && coll.name == "Tile[1,9]")
        {
            Block.instance.blockmove_udlr_control[8, 3] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[8, 3] = moveBlock;
        }

        //Block_10 9행  
        if (this.gameObject.name == "Block_10" && coll.name == "Tile[9,0]")
        {
            Block.instance.blockmove_udlr_control[9, 2] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[9, 2] = moveBlock;
        }
        if (this.gameObject.name == "Block_10" && coll.name == "Tile[9,9]")
        {
            Block.instance.blockmove_udlr_control[9, 3] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[9, 3] = moveBlock;
        }


        //상하
        //Block_4 0열 
        if (this.gameObject.name =="Block_4" && coll.name == "Tile[0,0]") 
        {
            Block.instance.blockmove_udlr_control[3, 0] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[3, 0] = moveBlock;
        }
        if (this.gameObject.name == "Block_4" && coll.name == "Tile[9,0]")
        {
            Block.instance.blockmove_udlr_control[3, 1] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[3, 1] = moveBlock;
        }

        //Block_5 6열
        if (this.gameObject.name == "Block_5" && coll.name == "Tile[0,6]")
        {
            Block.instance.blockmove_udlr_control[4, 0] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[4, 0] = moveBlock;
        }
        if (this.gameObject.name == "Block_5" && coll.name == "Tile[9,6]")
        {
            Block.instance.blockmove_udlr_control[4, 1] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[4, 1] = moveBlock;
        }

        //Block_6 4열
        if (this.gameObject.name == "Block_6" && coll.name == "Tile[0,4]")
        {
            Block.instance.blockmove_udlr_control[5, 0] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[5, 0] = moveBlock;
        }
        if (this.gameObject.name == "Block_6" && coll.name == "Tile[9,4]")
        {
            Block.instance.blockmove_udlr_control[5, 1] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[5, 1] = moveBlock;
        }

        //Block_11 2,3열
        if (this.gameObject.name == "Block_11" && (coll.name == "Tile[0,2]"|| coll.name == "Tile[0,3]"))
        {
            Debug.Log(coll.name);
            Debug.Log("특수블럭 위쪽에 닿음");
            Block.instance.blockmove_udlr_control[10, 0] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[10, 0] = moveBlock;
        }
        if (this.gameObject.name == "Block_11" && (coll.name == "Tile[9,2]" || coll.name == "Tile[9,3]"))
        {
            Debug.Log("특수블럭 아래쪽에 닿음");
            Block.instance.blockmove_udlr_control[10, 1] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[10, 1] = moveBlock;
        }

        //Block_12 5열
        if (this.gameObject.name == "Block_12" && coll.name == "Tile[0,5]")
        {
            Block.instance.blockmove_udlr_control[11, 0] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[11, 0] = moveBlock;
        }
        if (this.gameObject.name == "Block_12" && coll.name == "Tile[9,5]")
        {
            Block.instance.blockmove_udlr_control[11, 1] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[11, 1] = moveBlock;
        }

        //Block_13 9열
        if (this.gameObject.name == "Block_13" && coll.name == "Tile[0,9]")
        {
            Block.instance.blockmove_udlr_control[12, 0] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[12, 0] = moveBlock;
        }
        if (this.gameObject.name == "Block_13" && coll.name == "Tile[9,9]")
        {
            Debug.Log("tile(9,9)와 맞닿음");
            Block.instance.blockmove_udlr_control[12, 1] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[12, 1] = moveBlock;
        }

        //Block_14 3열
        if (this.gameObject.name == "Block_14" && coll.name == "Tile[0,3]")
        {
            Block.instance.blockmove_udlr_control[13, 0] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[13, 0] = moveBlock;
        }
        if (this.gameObject.name == "Block_14" && coll.name == "Tile[9,3]")
        {
            Block.instance.blockmove_udlr_control[13, 1] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[13, 1] = moveBlock;
        }
    }


    private void OnTriggerExit2D(Collider2D coll)
    {
        moveBlock = true;

        //좌우 
        //Block_1 4행  
        if (this.gameObject.name == "Block_1" && coll.name == "Tile[4,0]")
        {
            Block.instance.blockmove_udlr_control[0, 2] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[0, 2] = moveBlock;
        }
        if (this.gameObject.name == "Block_1" && coll.name == "Tile[4,9]")
        {
            Block.instance.blockmove_udlr_control[0, 3] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[0, 3] = moveBlock;
        }

        //Block_2 7행  
        if (this.gameObject.name == "Block_2" && coll.name == "Tile[7,0]")
        {
            Block.instance.blockmove_udlr_control[1, 2] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[1, 2] = moveBlock;
        }
        if (this.gameObject.name == "Block_2" && coll.name == "Tile[7,9]")
        {
            Block.instance.blockmove_udlr_control[1, 3] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[1, 3] = moveBlock;
        }

        //Block_3 2행  
        if (this.gameObject.name == "Block_3" && coll.name == "Tile[2,0]")
        {
            Block.instance.blockmove_udlr_control[2, 2] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[2, 2] = moveBlock;
        }
        if (this.gameObject.name == "Block_3" && coll.name == "Tile[2,9]")
        {
            Block.instance.blockmove_udlr_control[2, 3] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[2, 3] = moveBlock;
        }

        //Block_7 3행  
        if (this.gameObject.name == "Block_7" && coll.name == "Tile[3,0]")
        {
            Block.instance.blockmove_udlr_control[6, 2] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[6, 2] = moveBlock;
        }
        if (this.gameObject.name == "Block_7" && coll.name == "Tile[3,9]")
        {
            Block.instance.blockmove_udlr_control[6, 3] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[6, 3] = moveBlock;
        }

        //Block_8 5행  
        if (this.gameObject.name == "Block_8" && coll.name == "Tile[5,0]")
        {
            Block.instance.blockmove_udlr_control[7, 2] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[7, 2] = moveBlock;
        }
        if (this.gameObject.name == "Block_8" && coll.name == "Tile[5,9]")
        {
            Block.instance.blockmove_udlr_control[7, 3] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[7, 3] = moveBlock;
        }

        //Block_9 1행  
        if (this.gameObject.name == "Block_9" && coll.name == "Tile[1,0]")
        {
            Block.instance.blockmove_udlr_control[8, 2] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[8, 2] = moveBlock;
        }
        if (this.gameObject.name == "Block_9" && coll.name == "Tile[1,9]")
        {
            Block.instance.blockmove_udlr_control[8, 3] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[8, 3] = moveBlock;
        }

        //Block_10 9행  
        if (this.gameObject.name == "Block_10" && coll.name == "Tile[9,0]")
        {
            Block.instance.blockmove_udlr_control[9, 2] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[9, 2] = moveBlock;
        }
        if (this.gameObject.name == "Block_10" && coll.name == "Tile[9,9]")
        {
            Block.instance.blockmove_udlr_control[9, 3] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[9, 3] = moveBlock;
        }


        //상하
        //Block_4 0열 
        if (this.gameObject.name == "Block_4" && coll.name == "Tile[0,0]")
        {
            Block.instance.blockmove_udlr_control[3, 0] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[3, 0] = moveBlock;
        }
        if (this.gameObject.name == "Block_4" && coll.name == "Tile[9,0]")
        {
            Block.instance.blockmove_udlr_control[3, 1] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[3, 1] = moveBlock;
        }

        //Block_5 6열
        if (this.gameObject.name == "Block_5" && coll.name == "Tile[0,6]")
        {
            Block.instance.blockmove_udlr_control[4, 0] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[4, 0] = moveBlock;
        }
        if (this.gameObject.name == "Block_5" && coll.name == "Tile[9,6]")
        {
            Block.instance.blockmove_udlr_control[4, 1] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[4, 1] = moveBlock;
        }

        //Block_6 4열
        if (this.gameObject.name == "Block_6" && coll.name == "Tile[0,4]")
        {
            Block.instance.blockmove_udlr_control[5, 0] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[5, 0] = moveBlock;
        }
        if (this.gameObject.name == "Block_6" && coll.name == "Tile[9,4]")
        {
            Block.instance.blockmove_udlr_control[5, 1] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[5, 1] = moveBlock;
        }

        //Block_11 2,3열
        if (this.gameObject.name == "Block_11" && (coll.name == "Tile[0,2]" || coll.name == "Tile[0,3]"))
        {
            Debug.Log("특수블럭 위쪽에 떨어짐");
            Block.instance.blockmove_udlr_control[10, 0] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[10, 0] = moveBlock;
        }
        if (this.gameObject.name == "Block_11" && (coll.name == "Tile[9,2]" || coll.name == "Tile[9,3]"))
        {
            Debug.Log("특수블럭 아래쪽에 떨어짐");

            Block.instance.blockmove_udlr_control[10, 1] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[10, 1] = moveBlock;
        }

        //Block_12 5열
        if (this.gameObject.name == "Block_12" && coll.name == "Tile[0,5]")
        {
            Block.instance.blockmove_udlr_control[11, 0] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[11, 0] = moveBlock;
        }
        if (this.gameObject.name == "Block_12" && coll.name == "Tile[9,5]")
        {
            Block.instance.blockmove_udlr_control[11, 1] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[11, 1] = moveBlock;
        }

        //Block_13 9열
        if (this.gameObject.name == "Block_13" && coll.name == "Tile[0,9]")
        {
            Block.instance.blockmove_udlr_control[12, 0] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[12, 0] = moveBlock;
        }
        if (this.gameObject.name == "Block_13" && coll.name == "Tile[9,9]")
        {
            Debug.Log("tile(9,9)와 맞닿음");
            Block.instance.blockmove_udlr_control[12, 1] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[12, 1] = moveBlock;
        }

        //Block_14 3열
        if (this.gameObject.name == "Block_14" && coll.name == "Tile[0,3]")
        {
            Block.instance.blockmove_udlr_control[13, 0] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[13, 0] = moveBlock;
        }
        if (this.gameObject.name == "Block_14" && coll.name == "Tile[9,3]")
        {
            Block.instance.blockmove_udlr_control[13, 1] = moveBlock;
            Block.instance.manage_blockMovement_contactedEdge[13, 1] = moveBlock;
        }
    }

}//end class



//private void OnTriggerEnter2D(Collider2D coll)
//{
//    if(coll.tag == "Tile") //타일의 가장자리와 부딪혔을시 이동 제한
//    {
//        //TIle_ManageMent 스크립트에서 배열의 값
//        int blocknum =Block.instance.ReturnBlockNum(this.gameObject.name);  //이스크립트를 달고있는 전체 블록을 관리

//        //(0,0) ~ (0,9) 상
//        //(9,0) ~ (9,9) 하
//        //(0,0) ~ (9,0) 좌
//        //(0,9) ~ (9,9) 우
//        for(int i=0; i<10; i++) //중복 : 가장자리 꼭짓점 부분 두번 출력됨 -> 해결방안 : for문 상하, 좌우 따로따로 돌리기

//        {

//            if (coll.name == "Tile[0," + i + "]") //상
//            {
//                Tile_ManageMent.instance.tile_value[0 , i] = blocknum; //블럭과 타일의 가장자리가 부딪혔을시 해당 블럭번호를 가장자리 타일값에 넣어둠.
//                //Debug.Log("Tile[0," + i + "] =" + Tile_ManageMent.instance.tile_value[0 , i]);
//            }
//            if (coll.name == "Tile[9," + i + "]") //하
//            {
//                Tile_ManageMent.instance.tile_value[9 , i] = blocknum; //블럭과 타일의 가장자리가 부딪혔을시 해당 블럭번호를 가장자리 타일값에 넣어둠.
//                //Debug.Log("Tile[9," + i + "] = " + Tile_ManageMent.instance.tile_value[9 , i]);

//            }
//            if (coll.name == "Tile[" + i + ",0]") //좌
//            {
//                Tile_ManageMent.instance.tile_value[i , 0] = blocknum; //블럭과 타일의 가장자리가 부딪혔을시 해당 블럭번호를 가장자리 타일값에 넣어둠.
//               // Debug.Log("Tile[" + i + ",0] = " + Tile_ManageMent.instance.tile_value[i , 0]);

//            }
//            if (coll.name == "Tile[" + i + ",9]") //우
//            {
//                Debug.Log("우측에 붙음");
//                Tile_ManageMent.instance.tile_value[i , 9] = blocknum; //블럭과 타일의 가장자리가 부딪혔을시 해당 블럭번호를 가장자리 타일값에 넣어둠.
//                Debug.Log("Tile[" + i + ",9] = " + Tile_ManageMent.instance.tile_value[i , 9]);

//            }
//        }
//    }

//}

//private void OnTriggerExit2D(Collider2D coll) 
//{
//    if (coll.tag == "Tile") //타일의 가장자리와 떨어졌을시 타일값은 접촉한번호의 음수값을 가진다.
//    {
//        //TIle_ManageMent 스크립트에서 배열의 값
//        int blocknum = Block.instance.ReturnBlockNum(this.gameObject.name);  

//        //(0,0) ~ (0,9) 상
//        //(9,0) ~ (9,9) 하
//        //(0,0) ~ (9,0) 좌
//        //(0,9) ~ (9,9) 우
//        for (int i = 0; i < 10; i++) //중복 : 가장자리 꼭짓점 부분 두번 출력됨 -> 해결방안 : for문 상하, 좌우 따로따로 돌리기
//        {

//            if (coll.name == "Tile[0," + i + "]") //상
//            {
//                Tile_ManageMent.instance.tile_value[0, i] = -blocknum; //블럭과 타일의 가장자리가 부딪혔을시 해당 블럭번호를 가장자리 타일값에 넣어둠.
//                //Debug.Log("Tile[0," + i + "] =" + Tile_ManageMent.instance.tile_value[0, i]);
//            }
//            if (coll.name == "Tile[9," + i + "]") //하
//            {
//                Tile_ManageMent.instance.tile_value[9, i] = -blocknum; //블럭과 타일의 가장자리가 부딪혔을시 해당 블럭번호를 가장자리 타일값에 넣어둠.
//                //Debug.Log("Tile[9," + i + "] = " + Tile_ManageMent.instance.tile_value[9, i]);

//            }
//            if (coll.name == "Tile[" + i + ",0]") //좌
//            {
//                Tile_ManageMent.instance.tile_value[i, 0] = -blocknum; //블럭과 타일의 가장자리가 부딪혔을시 해당 블럭번호를 가장자리 타일값에 넣어둠.
//                //Debug.Log("Tile[" + i + ",0] = " + Tile_ManageMent.instance.tile_value[i, 0]);

//            }
//            if (coll.name == "Tile[" + i + ",9]") //우
//            {
//                Debug.Log("우측에서 떨어짐");
//                Tile_ManageMent.instance.tile_value[i, 9] = -blocknum; //블럭과 타일의 가장자리가 부딪혔을시 해당 블럭번호를 가장자리 타일값에 넣어둠.
//                Debug.Log("Tile[" + i + ",9] = " + Tile_ManageMent.instance.tile_value[i, 9]);

//            }
//        }
//    }
//}

