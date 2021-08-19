using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockColliderManageMent_1 : MonoBehaviour
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

        //블럭과 닿으면 WaterFlow를 해당 위치에 생성한다.
        // 배열 인덱스 0번 (0,0)
        if (coll.name == "Tile[0,0]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[0] = moveBlock;
        }
          
        // 배열 인덱스 1번 (1,0)
        if (coll.name == "Tile[1,0]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[1] = moveBlock;
        }

        // 배열 인덱스 2번 (1,1)
        if (coll.name == "Tile[1,1]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[2] = moveBlock;

        }

        // 배열 인덱스 3번 (1,2)
        if (coll.name == "Tile[1,2]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[3] = moveBlock;

        }

        // 배열 인덱스 4번 (2,2)
        if (coll.name == "Tile[2,2]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[4] = moveBlock;

        }

        // 배열 인덱스 5번 (3,2)
        if (coll.name == "Tile[3,2]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[5] = moveBlock;

        }

        // 배열 인덱스 6번 (4,2)
        if (coll.name == "Tile[4,2]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[6] = moveBlock;

        }

        // 배열 인덱스 7번 (4,3)
        if (coll.name == "Tile[4,3]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[7] = moveBlock;

        }

        // 배열 인덱스 8번 (4,4)
        if (coll.name == "Tile[4,4]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[8] = moveBlock;

        }

        // 배열 인덱스 9번 (4,5)
        if (coll.name == "Tile[4,5]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[9] = moveBlock;

        }

        // 배열 인덱스 10번 (4,6)
        if (coll.name == "Tile[4,6]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[10] = moveBlock;

        }

        // 배열 인덱스 11번 (5,2)
        if (coll.name == "Tile[5,2]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[11] = moveBlock;

        }

        // 배열 인덱스 12번 (5,6)
        if (coll.name == "Tile[5,6]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[12] = moveBlock;

        }

        // 배열 인덱스 13번 (6,2)
        if (coll.name == "Tile[6,2]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[13] = moveBlock;

        }

        // 배열 인덱스 14번 (6,6)
        if (coll.name == "Tile[6,6]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[14] = moveBlock;

        }

        // 배열 인덱스 15번 (7,2)
        if (coll.name == "Tile[7,2]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[15] = moveBlock;

        }

        // 배열 인덱스 16번 (7,3)
        if (coll.name == "Tile[7,3]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[16] = moveBlock;

        }

        // 배열 인덱스 17번 (7,4)
        if (coll.name == "Tile[7,4]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[17] = moveBlock;

        }

        // 배열 인덱스 18번 (7,5)
        if (coll.name == "Tile[7,5]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[18] = moveBlock;

        }

        // 배열 인덱스 19번 (7,6)
        if (coll.name == "Tile[7,6]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[19] = moveBlock;

        }

        // 배열 인덱스 20번 (8,6)
        if (coll.name == "Tile[8,6]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[20] = moveBlock;

        }

        // 배열 인덱스 21번 (8,7)
        if (coll.name == "Tile[8,7]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[21] = moveBlock;

        }

        // 배열 인덱스 22번 (8,8)
        if (coll.name == "Tile[8,8]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[22] = moveBlock;

        }

        // 배열 인덱스 23번 (9,8)
        if (coll.name == "Tile[9,8]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[23] = moveBlock;

        }

        // 배열 인덱스 24번 (9,9)
        if (coll.name == "Tile[9,9]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[24] = moveBlock;

        }

        //상하 
        //Block_1 0열  
        if (this.gameObject.name == "Block_1" && coll.name == "Tile[0,0]")
        {
            Block_1.instance.blockmove_udlr_control[0, 0] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[0, 0] = moveBlock;
        }
        if (this.gameObject.name == "Block_1" && coll.name == "Tile[9,0]")
        {
            Block_1.instance.blockmove_udlr_control[0, 1] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[0, 1] = moveBlock;
        }

        //Block_2 1열
        if (this.gameObject.name == "Block_2" && coll.name == "Tile[0,1]")
        {
            Block_1.instance.blockmove_udlr_control[1, 0] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[1, 0] = moveBlock;
        }
        if (this.gameObject.name == "Block_2" && coll.name == "Tile[9,1]")
        {
            Block_1.instance.blockmove_udlr_control[1, 1] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[1, 1] = moveBlock;
        }

        //Block_3 3열
        if (this.gameObject.name == "Block_3" && coll.name == "Tile[0,3]")
        {
            Block_1.instance.blockmove_udlr_control[2, 0] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[2, 0] = moveBlock;
        }
        if (this.gameObject.name == "Block_3" && coll.name == "Tile[9,3]")
        {
            Block_1.instance.blockmove_udlr_control[2, 1] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[2, 1] = moveBlock;
        }

        //Block_4 7열
        if (this.gameObject.name == "Block_4" && coll.name == "Tile[0,7]")
        {
            Debug.Log("tile[0,7]닿음");
            Block_1.instance.blockmove_udlr_control[3, 0] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[3, 0] = moveBlock;
        }
        if (this.gameObject.name == "Block_4" && coll.name == "Tile[9,7]")
        {
            Debug.Log("tile[9,7]닿음");

            Block_1.instance.blockmove_udlr_control[3, 1] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[3, 1] = moveBlock;
        }

        //Block_5 5열
        if (this.gameObject.name == "Block_5" && coll.name == "Tile[0,5]")
        {
            Block_1.instance.blockmove_udlr_control[4, 0] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[4, 0] = moveBlock;
        }
        if (this.gameObject.name == "Block_5" && coll.name == "Tile[9,5]")
        {
            Block_1.instance.blockmove_udlr_control[4, 1] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[4, 1] = moveBlock;
        }

        //좌우
        //Block_6 6행
        if (this.gameObject.name == "Block_6" && coll.name == "Tile[6,0]")
        {
            Block_1.instance.blockmove_udlr_control[5, 2] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[5, 2] = moveBlock;
        }
        if (this.gameObject.name == "Block_6" && coll.name == "Tile[6,9]")
        {
            Block_1.instance.blockmove_udlr_control[5, 3] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[5, 3] = moveBlock;
        }

        //Block_7 8행
        if (this.gameObject.name == "Block_7" && coll.name == "Tile[8,0]")
        {
            Block_1.instance.blockmove_udlr_control[6, 2] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[6, 2] = moveBlock;
        }
        if (this.gameObject.name == "Block_7" && coll.name == "Tile[8,9]")
        {
            Block_1.instance.blockmove_udlr_control[6, 3] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[6, 3] = moveBlock;
        }

        //Block_8 9행
        if (this.gameObject.name == "Block_8" && coll.name == "Tile[9,0]")
        {
            Block_1.instance.blockmove_udlr_control[7, 2] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[7, 2] = moveBlock;
        }
        if (this.gameObject.name == "Block_8" && coll.name == "Tile[9,9]")
        {
            Block_1.instance.blockmove_udlr_control[7, 3] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[7, 3] = moveBlock;
        }

        //Block_9 5,6행
        if (this.gameObject.name == "Block_9" && (coll.name == "Tile[5,0]" || coll.name == "Tile[6,0]"))
        {
            Block_1.instance.blockmove_udlr_control[8, 2] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[8, 2] = moveBlock;
        }
        if (this.gameObject.name == "Block_9" && (coll.name == "Tile[5,9]" || coll.name == "Tile[6,9]"))
        {
            Block_1.instance.blockmove_udlr_control[8, 3] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[8, 3] = moveBlock;
        }

        //Block_10 7행
        if (this.gameObject.name == "Block_10" && coll.name == "Tile[7,0]")
        {
            Block_1.instance.blockmove_udlr_control[9, 2] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[9, 2] = moveBlock;
        }
        if (this.gameObject.name == "Block_10" && coll.name == "Tile[7,9]")
        {
            Block_1.instance.blockmove_udlr_control[9, 3] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[9, 3] = moveBlock;
        }

        //Block_11 1행
        if (this.gameObject.name == "Block_11" && coll.name == "Tile[1,0]")
        {
            Block_1.instance.blockmove_udlr_control[10, 2] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[10, 2] = moveBlock;

        }
        if (this.gameObject.name == "Block_11" && coll.name == "Tile[1,9]")
        {
            Block_1.instance.blockmove_udlr_control[10, 3] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[10, 3] = moveBlock;
        }

        //Block_12 2행
        if (this.gameObject.name == "Block_12" && coll.name == "Tile[2,0]")
        {
            Block_1.instance.blockmove_udlr_control[11, 2] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[11, 2] = moveBlock;
        }
        if (this.gameObject.name == "Block_12" && coll.name == "Tile[2,9]")
        {
            Block_1.instance.blockmove_udlr_control[11, 3] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[11, 3] = moveBlock;
        }


        //Block_13 3행
        if (this.gameObject.name == "Block_13" && coll.name == "Tile[3,0]")
        {
            Block_1.instance.blockmove_udlr_control[12, 2] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[12, 2] = moveBlock;
        }
        if (this.gameObject.name == "Block_13" && coll.name == "Tile[3,9]")
        {
            Block_1.instance.blockmove_udlr_control[12, 3] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[12, 3] = moveBlock;
        }

    }


    private void OnTriggerExit2D(Collider2D coll)
    {
        moveBlock = true;


        //블럭과 닿으면 WaterFlow를 해당 위치에 생성한다.
        // 배열 인덱스 0번 (0,0)
        if (coll.name == "Tile[0,0]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[0] = moveBlock;
        }

        // 배열 인덱스 1번 (1,0)
        if (coll.name == "Tile[1,0]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[1] = moveBlock;
        }

        // 배열 인덱스 2번 (1,1)
        if (coll.name == "Tile[1,1]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[2] = moveBlock;

        }

        // 배열 인덱스 3번 (1,2)
        if (coll.name == "Tile[1,2]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[3] = moveBlock;

        }

        // 배열 인덱스 4번 (2,2)
        if (coll.name == "Tile[2,2]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[4] = moveBlock;

        }

        // 배열 인덱스 5번 (3,2)
        if (coll.name == "Tile[3,2]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[5] = moveBlock;

        }

        // 배열 인덱스 6번 (4,2)
        if (coll.name == "Tile[4,2]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[6] = moveBlock;

        }

        // 배열 인덱스 7번 (4,3)
        if (coll.name == "Tile[4,3]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[7] = moveBlock;

        }

        // 배열 인덱스 8번 (4,4)
        if (coll.name == "Tile[4,4]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[8] = moveBlock;

        }

        // 배열 인덱스 9번 (4,5)
        if (coll.name == "Tile[4,5]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[9] = moveBlock;

        }

        // 배열 인덱스 10번 (4,6)
        if (coll.name == "Tile[4,6]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[10] = moveBlock;

        }

        // 배열 인덱스 11번 (5,2)
        if (coll.name == "Tile[5,2]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[11] = moveBlock;

        }

        // 배열 인덱스 12번 (5,6)
        if (coll.name == "Tile[5,6]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[12] = moveBlock;

        }

        // 배열 인덱스 13번 (6,2)
        if (coll.name == "Tile[6,2]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[13] = moveBlock;

        }

        // 배열 인덱스 14번 (6,6)
        if (coll.name == "Tile[6,6]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[14] = moveBlock;

        }

        // 배열 인덱스 15번 (7,2)
        if (coll.name == "Tile[7,2]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[15] = moveBlock;

        }

        // 배열 인덱스 16번 (7,3)
        if (coll.name == "Tile[7,3]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[16] = moveBlock;

        }

        // 배열 인덱스 17번 (7,4)
        if (coll.name == "Tile[7,4]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[17] = moveBlock;

        }

        // 배열 인덱스 18번 (7,5)
        if (coll.name == "Tile[7,5]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[18] = moveBlock;

        }

        // 배열 인덱스 19번 (7,6)
        if (coll.name == "Tile[7,6]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[19] = moveBlock;

        }

        // 배열 인덱스 20번 (8,6)
        if (coll.name == "Tile[8,6]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[20] = moveBlock;

        }

        // 배열 인덱스 21번 (8,7)
        if (coll.name == "Tile[8,7]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[21] = moveBlock;

        }

        // 배열 인덱스 22번 (8,8)
        if (coll.name == "Tile[8,8]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[22] = moveBlock;

        }

        // 배열 인덱스 23번 (9,8)
        if (coll.name == "Tile[9,8]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[23] = moveBlock;

        }

        // 배열 인덱스 24번 (9,9)
        if (coll.name == "Tile[9,9]")
        {
            Tile_ManageMent_1.instance.setactive_WaterFlow[24] = moveBlock;

        }


        //상하 
        //Block_1 0열  
        if (this.gameObject.name == "Block_1" && coll.name == "Tile[0,0]")
        {
            Block_1.instance.blockmove_udlr_control[0, 0] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[0, 0] = moveBlock;
        }
        if (this.gameObject.name == "Block_1" && coll.name == "Tile[9,0]")
        {
            Block_1.instance.blockmove_udlr_control[0, 1] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[0, 1] = moveBlock;
        }

        //Block_2 1열
        if (this.gameObject.name == "Block_2" && coll.name == "Tile[0,1]")
        {
            Block_1.instance.blockmove_udlr_control[1, 0] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[1, 0] = moveBlock;
        }
        if (this.gameObject.name == "Block_2" && coll.name == "Tile[9,1]")
        {
            Block_1.instance.blockmove_udlr_control[1, 1] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[1, 1] = moveBlock;
        }

        //Block_3 3열
        if (this.gameObject.name == "Block_3" && coll.name == "Tile[0,3]")
        {
            Block_1.instance.blockmove_udlr_control[2, 0] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[2, 0] = moveBlock;
        }
        if (this.gameObject.name == "Block_3" && coll.name == "Tile[9,3]")
        {
            Block_1.instance.blockmove_udlr_control[2, 1] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[2, 1] = moveBlock;
        }

        //Block_4 7열
        if (this.gameObject.name == "Block_4" && coll.name == "Tile[0,7]")
        {
            Block_1.instance.blockmove_udlr_control[3, 0] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[3, 0] = moveBlock;
        }
        if (this.gameObject.name == "Block_4" && coll.name == "Tile[9,7]")
        {
            Block_1.instance.blockmove_udlr_control[3, 1] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[3, 1] = moveBlock;
        }

        //Block_5 5열
        if (this.gameObject.name == "Block_5" && coll.name == "Tile[0,5]")
        {
            Block_1.instance.blockmove_udlr_control[4, 0] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[4, 0] = moveBlock;
        }
        if (this.gameObject.name == "Block_5" && coll.name == "Tile[9,5]")
        {
            Block_1.instance.blockmove_udlr_control[4, 1] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[4, 1] = moveBlock;
        }

        //좌우
        //Block_6 6행
        if (this.gameObject.name == "Block_6" && coll.name == "Tile[6,0]")
        {
            Block_1.instance.blockmove_udlr_control[5, 2] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[5, 2] = moveBlock;
        }
        if (this.gameObject.name == "Block_6" && coll.name == "Tile[6,9]")
        {
            Block_1.instance.blockmove_udlr_control[5, 3] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[5, 3] = moveBlock;
        }

        //Block_7 8행
        if (this.gameObject.name == "Block_7" && coll.name == "Tile[8,0]")
        {
            Block_1.instance.blockmove_udlr_control[6, 2] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[6, 2] = moveBlock;
        }
        if (this.gameObject.name == "Block_7" && coll.name == "Tile[8,9]")
        {
            Block_1.instance.blockmove_udlr_control[6, 3] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[6, 3] = moveBlock;
        }

        //Block_8 9행
        if (this.gameObject.name == "Block_8" && coll.name == "Tile[9,0]")
        {
            Block_1.instance.blockmove_udlr_control[7, 2] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[7, 2] = moveBlock;
        }
        if (this.gameObject.name == "Block_8" && coll.name == "Tile[9,9]")
        {
            Block_1.instance.blockmove_udlr_control[7, 3] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[7, 3] = moveBlock;
        }

        //Block_9 5,6행
        if (this.gameObject.name == "Block_9" && (coll.name == "Tile[5,0]" || coll.name == "Tile[6,0]"))
        {
            Block_1.instance.blockmove_udlr_control[8, 2] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[8, 2] = moveBlock;
        }
        if (this.gameObject.name == "Block_9" && (coll.name == "Tile[5,9]" || coll.name == "Tile[6,9]"))
        {
            Block_1.instance.blockmove_udlr_control[8, 3] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[8, 3] = moveBlock;
        }

        //Block_10 7행
        if (this.gameObject.name == "Block_10" && coll.name == "Tile[7,0]")
        {
            Block_1.instance.blockmove_udlr_control[9, 2] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[9, 2] = moveBlock;
        }
        if (this.gameObject.name == "Block_10" && coll.name == "Tile[7,9]")
        {
            Block_1.instance.blockmove_udlr_control[9, 3] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[9, 3] = moveBlock;
        }

        //Block_11 1행
        if (this.gameObject.name == "Block_11" && coll.name == "Tile[1,0]")
        {
            Block_1.instance.blockmove_udlr_control[10, 2] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[10, 2] = moveBlock;

        }
        if (this.gameObject.name == "Block_11" && coll.name == "Tile[1,9]")
        {
            Block_1.instance.blockmove_udlr_control[10, 3] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[10, 3] = moveBlock;
        }

        //Block_12 2행
        if (this.gameObject.name == "Block_12" && coll.name == "Tile[2,0]")
        {
            Block_1.instance.blockmove_udlr_control[11, 2] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[11, 2] = moveBlock;
        }
        if (this.gameObject.name == "Block_12" && coll.name == "Tile[2,9]")
        {
            Block_1.instance.blockmove_udlr_control[11, 3] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[11, 3] = moveBlock;
        }


        //Block_13 3행
        if (this.gameObject.name == "Block_13" && coll.name == "Tile[3,0]")
        {
            Block_1.instance.blockmove_udlr_control[12, 2] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[12, 2] = moveBlock;
        }
        if (this.gameObject.name == "Block_13" && coll.name == "Tile[3,9]")
        {
            Block_1.instance.blockmove_udlr_control[12, 3] = moveBlock;
            Block_1.instance.manage_blockMovement_contactedEdge[12, 3] = moveBlock;
        }
    }

}//end class



