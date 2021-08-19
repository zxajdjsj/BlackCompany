using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desert_Object : MonoBehaviour
{
    //OnTrigger는 Update 다음으로 처리하기 때문에 
    //Update순서가 더 빨라서 충돌을 처리하기전에 update에서 플레이어의 움직임을 먼저 관리함.
    //따라서 오류가 생김 ex)맵 가장자리에서 밖으로 안나가야하는데 나감. 맨 처음에만
    //따라서 초기화를 전부 true로 하지말고 각각의 경우에 맞춰서 초기화 해주기!

    //public bool object_move;

    //private void OnTriggerExit2D(Collider2D coll)
    //{
    //        if(Tile_desert.instance.target_copy != null)
    //        {
    //            object_move = true;

    //            if (coll.tag == "Desert_Object_Border_U") //상
    //            {
    //                for (int i = 1; i <= 14; i++)
    //                {
    //                    if (coll.name.Contains("*" + i.ToString())) //부딪힌애는 n_up or n_down or n_left or n_right
    //                    {
    //                        Border_to_Desert_Object(i, "U", object_move);
    //                    }
    //                    else if (coll.name.Contains(i.ToString()))
    //                    {
    //                        Border_to_Desert_Object(i, "U", object_move);
    //                    }
    //                }
    //            }
    //            else if (coll.tag == "Desert_Object_Border_D") //하
    //            {
    //                for (int i = 1; i <= 14; i++)
    //                {
    //                    if (coll.name.Contains("*" + i.ToString())) //부딪힌애는 n_up or n_down or n_left or n_right
    //                    {
    //                        Border_to_Desert_Object(i, "D", object_move);
    //                    }
    //                    else if (coll.name.Contains(i.ToString()))
    //                    {
    //                        Border_to_Desert_Object(i, "D", object_move);
    //                    }
    //                }
    //            }
    //            else if (coll.tag == "Desert_Object_Border_L") //좌
    //            {
    //                for (int i = 1; i <= 14; i++)
    //                {
    //                    if (coll.name.Contains("*" + i.ToString())) //부딪힌애는 n_up or n_down or n_left or n_right
    //                    {
    //                        Border_to_Desert_Object(i, "L", object_move);
    //                    }
    //                    else if (coll.name.Contains(i.ToString()))
    //                    {
    //                        Border_to_Desert_Object(i, "L", object_move);
    //                    }
    //                }
    //            }
    //            else if (coll.tag == "Desert_Object_Border_R") //우
    //            {
    //                for (int i = 1; i <= 14; i++)
    //                {
    //                    if (coll.name.Contains("*" + i.ToString())) //부딪힌애는 n_up or n_down or n_left or n_right
    //                    {
    //                        Border_to_Desert_Object(i, "R", object_move);
    //                    }
    //                    else if (coll.name.Contains(i.ToString()))
    //                    {
    //                        Border_to_Desert_Object(i, "R", object_move);
    //                    }
    //                }
    //            }


    //            //waterway4_V  : 0열   00 90        00  10
    //            if (coll.name == "tile00") //상
    //            {
    //                if (Tile_desert.instance.target_copy.name == "waterway4_V" && this.gameObject.name == "waterway4_V")
    //                    Tile_desert.instance.move_ud[0, 0] = true;
    //            }
    //            else if (coll.name == "tile90") //하
    //            {
    //                if (Tile_desert.instance.target_copy.name == "waterway4_V" && this.gameObject.name == "waterway4_V")
    //                    Tile_desert.instance.move_ud[1, 0] = true;
    //            }

    //            //waterway5_V  : 6열   06 96        01  11
    //            if (coll.name == "tile06") //상
    //            {
    //                if (Tile_desert.instance.target_copy.name == "waterway5_V" && this.gameObject.name == "waterway5_V")
    //                    Tile_desert.instance.move_ud[0, 1] = true;
    //            }
    //            else if (coll.name == "tile96") //하
    //            {
    //                if (Tile_desert.instance.target_copy.name == "waterway5_V" && this.gameObject.name == "waterway5_V")
    //                    Tile_desert.instance.move_ud[1, 1] = true;
    //            }


    //            //waterway6_V  : 4열   04 94        02  12
    //            if (coll.name == "tile04") //상
    //            {
    //                if (Tile_desert.instance.target_copy.name == "waterway6_V" && this.gameObject.name == "waterway6_V")
    //                    Tile_desert.instance.move_ud[0, 2] = true;
    //            }
    //            else if (coll.name == "tile94") //하
    //            {
    //                if (Tile_desert.instance.target_copy.name == "waterway6_V" && this.gameObject.name == "waterway6_V")
    //                    Tile_desert.instance.move_ud[1, 2] = true;
    //            }


    //            //obstacle11_V : 2,3열 02 92 03 93     03  13  
    //            if (coll.name == "tile02" || coll.name == "tile03") //상
    //            {
    //                if (Tile_desert.instance.target_copy.name == "obstacle11_V" && this.gameObject.name == "obstacle11_V")
    //                    Tile_desert.instance.move_ud[0, 3] = true;
    //            }
    //            else if (coll.name == "tile92" || coll.name == "tile93") //하
    //            {
    //                if (Tile_desert.instance.target_copy.name == "obstacle11_V" && this.gameObject.name == "obstacle11_V")
    //                    Tile_desert.instance.move_ud[1, 3] = true;

    //            }


    //            //obstacle12_V : 5열   05 95        04  14
    //            if (coll.name == "tile05") //상
    //            {
    //                if (Tile_desert.instance.target_copy.name == "obstacle12_V" && this.gameObject.name == "obstacle12_V")
    //                    Tile_desert.instance.move_ud[0, 4] = true;
    //            }
    //            else if (coll.name == "tile95") //하
    //            {
    //                if (Tile_desert.instance.target_copy.name == "obstacle12_V" && this.gameObject.name == "obstacle12_V")
    //                    Tile_desert.instance.move_ud[1, 4] = true;
    //            }


    //            //obstacle13_V : 9열   09 99        05  15
    //            if (coll.name == "tile09") //상
    //            {
    //                if (Tile_desert.instance.target_copy.name == "obstacle13_V" && this.gameObject.name == "obstacle13_V")
    //                    Tile_desert.instance.move_ud[0, 5] = true;
    //            }
    //            else if (coll.name == "tile99") //하
    //            {
    //                if (Tile_desert.instance.target_copy.name == "obstacle13_V" && this.gameObject.name == "obstacle13_V")
    //                    Tile_desert.instance.move_ud[1, 5] = true;
    //            }


    //            //obstacle14_V : 3열   03 93           06  16
    //            if (coll.name == "tile03") //상
    //            {
    //                if (Tile_desert.instance.target_copy.name == "obstacle14_V" && this.gameObject.name == "obstacle14_V")
    //                    Tile_desert.instance.move_ud[0, 6] = true;
    //            }
    //            else if (coll.name == "tile93") //하
    //            {
    //                if (Tile_desert.instance.target_copy.name == "obstacle14_V" && this.gameObject.name == "obstacle14_V")
    //                    Tile_desert.instance.move_ud[1, 6] = true;
    //            }





    //            //좌우
    //            //                          좌우움직임 배열인덱스
    //            //                  좌 우   좌  우     
    //            //waterway1_H : 4행 40 49   00  10
    //            if (coll.name == "tile40") //좌
    //            {
    //                if (Tile_desert.instance.target_copy.name == "waterway1_H" && this.gameObject.name == "waterway1_H")
    //                    Tile_desert.instance.move_lr[0, 0] = true;
    //            }
    //            else if (coll.name == "tile49") //우
    //            {
    //                if (Tile_desert.instance.target_copy.name == "waterway1_H" && this.gameObject.name == "waterway1_H")
    //                    Tile_desert.instance.move_lr[1, 0] = true;
    //            }


    //            //waterway2_H : 7행 70 79   01  11
    //            if (coll.name == "tile70") //좌
    //            {
    //                if (Tile_desert.instance.target_copy.name == "waterway2_H" && this.gameObject.name == "waterway2_H")
    //                    Tile_desert.instance.move_lr[0, 1] = true;
    //            }
    //            else if (coll.name == "tile79") //우
    //            {
    //                if (Tile_desert.instance.target_copy.name == "waterway2_H" && this.gameObject.name == "waterway2_H")
    //                    Tile_desert.instance.move_lr[1, 1] = true;
    //            }

    //            //waterway3_H : 2행 20 29   02  12
    //            if (coll.name == "tile20") //좌
    //            {
    //                if (Tile_desert.instance.target_copy.name == "waterway3_H" && this.gameObject.name == "waterway3_H")
    //                    Tile_desert.instance.move_lr[0, 2] = true;
    //            }
    //            else if (coll.name == "tile29") //우
    //            {
    //                if (Tile_desert.instance.target_copy.name == "waterway3_H" && this.gameObject.name == "waterway3_H")
    //                    Tile_desert.instance.move_lr[1, 2] = true;
    //            }

    //            //obstacle7_H : 3행 30 39   03  13
    //            if (coll.name == "tile30") //좌
    //            {
    //                if (Tile_desert.instance.target_copy.name == "obstacle7_H" && this.gameObject.name == "obstacle7_H")
    //                    Tile_desert.instance.move_lr[0, 3] = true;
    //            }
    //            else if (coll.name == "tile39") //우
    //            {
    //                if (Tile_desert.instance.target_copy.name == "obstacle7_H" && this.gameObject.name == "obstacle7_H")
    //                    Tile_desert.instance.move_lr[1, 3] = true;
    //            }

    //            //obstacle8_H : 5행 50 59   04  14
    //            if (coll.name == "tile50") //좌
    //            {
    //                if (Tile_desert.instance.target_copy.name == "obstacle8_H" && this.gameObject.name == "obstacle8_H")
    //                    Tile_desert.instance.move_lr[0, 4] = true;
    //            }
    //            else if (coll.name == "tile59") //우
    //            {
    //                if (Tile_desert.instance.target_copy.name == "obstacle8_H" && this.gameObject.name == "obstacle8_H")
    //                    Tile_desert.instance.move_lr[1, 4] = true;
    //            }

    //            //obstacle9_H : 1행 10 19   05  15
    //            if (coll.name == "tile10") //좌
    //            {
    //                if (Tile_desert.instance.target_copy.name == "obstacle9_H" && this.gameObject.name == "obstacle9_H")
    //                    Tile_desert.instance.move_lr[0, 5] = true;
    //            }
    //            else if (coll.name == "tile19") //우
    //            {
    //                if (Tile_desert.instance.target_copy.name == "obstacle9_H" && this.gameObject.name == "obstacle9_H")
    //                    Tile_desert.instance.move_lr[1, 5] = true;
    //            }


    //            //obstacle10_H :9행 90 99   06  16
    //            if (coll.name == "tile90") //좌
    //            {
    //                if (Tile_desert.instance.target_copy.name == "obstacle10_H" && this.gameObject.name == "obstacle10_H")
    //                    Tile_desert.instance.move_lr[0, 6] = true;
    //            }
    //            else if (coll.name == "tile99") //우
    //            {
    //                if (Tile_desert.instance.target_copy.name == "obstacle10_H" && this.gameObject.name == "obstacle10_H")
    //                    Tile_desert.instance.move_lr[1, 6] = true;
    //            }
    //        }

    //}

    //private void OnTriggerStay2D(Collider2D coll)
    //{
    //        if(Tile_desert.instance.target_copy != null)
    //        {
    //            object_move = false;

    //            if (coll.tag == "Desert_Object_Border_U") //상
    //            {
    //                for (int i = 1; i <= 14; i++)
    //                {
    //                    if (coll.name.Contains("*" + i.ToString())) //부딪힌애는 n_up or n_down or n_left or n_right
    //                    {
    //                        Border_to_Desert_Object(i, "U", object_move);
    //                    }
    //                    else if (coll.name.Contains(i.ToString()))
    //                    {
    //                        Border_to_Desert_Object(i, "U", object_move);
    //                    }
    //                }
    //            }
    //            else if (coll.tag == "Desert_Object_Border_D") //하
    //            {
    //                for (int i = 1; i <= 14; i++)
    //                {
    //                    if (coll.name.Contains("*" + i.ToString())) //부딪힌애는 n_up or n_down or n_left or n_right
    //                    {
    //                        Border_to_Desert_Object(i, "D", object_move);
    //                    }
    //                    else if (coll.name.Contains(i.ToString()))
    //                    {
    //                        Border_to_Desert_Object(i, "D", object_move);
    //                    }
    //                }
    //            }
    //            else if (coll.tag == "Desert_Object_Border_L") //좌
    //            {
    //                for (int i = 1; i <= 14; i++)
    //                {
    //                    if (coll.name.Contains("*" + i.ToString())) //부딪힌애는 n_up or n_down or n_left or n_right
    //                    {
    //                        Border_to_Desert_Object(i, "L", object_move);
    //                    }
    //                    else if (coll.name.Contains(i.ToString()))
    //                    {
    //                        Border_to_Desert_Object(i, "L", object_move);
    //                    }
    //                }
    //            }
    //            else if (coll.tag == "Desert_Object_Border_R") //우
    //            {
    //                for (int i = 1; i <= 14; i++)
    //                {
    //                    if (coll.name.Contains("*" + i.ToString())) //부딪힌애는 n_up or n_down or n_left or n_right
    //                    {
    //                        Border_to_Desert_Object(i, "R", object_move);
    //                    }
    //                    else if (coll.name.Contains(i.ToString()))
    //                    {
    //                        Border_to_Desert_Object(i, "R", object_move);
    //                    }
    //                }
    //            }




    //            //오브젝트 이름순
    //            //                          좌우움직임 배열인덱스
    //            //                  좌 우   좌  우     
    //            //waterway1_H : 4행 40 49   00  10
    //            //waterway2_H : 7행 70 79   01  11
    //            //waterway3_H : 2행 20 29   02  12
    //            //obstacle7_H : 3행 30 39   03  13
    //            //obstacle8_H : 5행 50 59   04  14
    //            //obstacle9_H : 1행 10 19   05  15
    //            //obstacle10_H :9행 90 99   06  16

    //            //좌우 - 행 순
    //            //                          좌우움직임 배열인덱스
    //            //                  좌 우   좌  우     
    //            //obstacle9_H : 1행 10 19   05  15
    //            //waterway3_H : 2행 20 29   02  12
    //            //obstacle7_H : 3행 30 39   03  13
    //            //waterway1_H : 4행 40 49   00  10
    //            //obstacle8_H : 5행 50 59   04  14
    //            //waterway2_H : 7행 70 79   01  11
    //            //obstacle10_H :9행 90 99   06  16


    //            //오브젝트 이름순
    //            //                                  상하 움직임 배열인덱스
    //            //                     상 하 상 하  상  하
    //            //waterway4_V  : 0열   00 90        00  10
    //            //waterway5_V  : 6열   06 96        01  11
    //            //waterway6_V  : 4열   04 94        02  12
    //            //obstacle11_V : 2,3열 02 92 03 93  03  13
    //            //obstacle12_V : 5열   05 95        04  14
    //            //obstacle13_V : 9열   09 99        05  15
    //            //obstacle14_V : 3열   03 93        06  16

    //            //상하 - 열 순
    //            //순서대로
    //            //                                  상하 움직임 배열인덱스
    //            //                     상 하 상 하  상  하
    //            //waterway4_V  : 0열   00 90        00  10
    //            //obstacle11_V : 2,3열 02 92 03 93  03  13  
    //            //obstacle14_V : 3열   03 93        06  16
    //            //waterway6_V  : 4열   04 94        02  12
    //            //obstacle12_V : 5열   05 95        04  14
    //            //waterway5_V  : 6열   06 96        01  11
    //            //obstacle13_V : 9열   09 99        05  15






    //            //상하
    //            //                                  상하 움직임 배열 인덱스
    //            //                     상 하 상 하  상  하
    //            //waterway4_V  : 0열   00 90        00  10
    //            if (coll.name == "tile00") //상
    //            {
    //                if (Tile_desert.instance.target_copy.name == "waterway4_V" && this.gameObject.name == "waterway4_V")
    //                    Tile_desert.instance.move_ud[0, 0] = false;
    //            }
    //            else if (coll.name == "tile90") //하
    //            {
    //                if (Tile_desert.instance.target_copy.name == "waterway4_V" && this.gameObject.name == "waterway4_V")
    //                    Tile_desert.instance.move_ud[1, 0] = false;
    //            }

    //            //waterway5_V  : 6열   06 96        01  11
    //            if (coll.name == "tile06") //상
    //            {
    //                if (Tile_desert.instance.target_copy.name == "waterway5_V" && this.gameObject.name == "waterway5_V")
    //                    Tile_desert.instance.move_ud[0, 1] = false;
    //            }
    //            else if (coll.name == "tile96") //하
    //            {
    //                if (Tile_desert.instance.target_copy.name == "waterway5_V" && this.gameObject.name == "waterway5_V")
    //                    Tile_desert.instance.move_ud[1, 1] = false;
    //            }


    //            //waterway6_V  : 4열   04 94        02  12
    //            if (coll.name == "tile04") //상
    //            {
    //                if (Tile_desert.instance.target_copy.name == "waterway6_V" && this.gameObject.name == "waterway6_V")
    //                    Tile_desert.instance.move_ud[0, 2] = false;
    //            }
    //            else if (coll.name == "tile94") //하
    //            {
    //                if (Tile_desert.instance.target_copy.name == "waterway6_V" && this.gameObject.name == "waterway6_V")
    //                    Tile_desert.instance.move_ud[1, 2] = false;
    //            }


    //            //obstacle11_V : 2,3열 02 92 03 93     03  13  
    //            if (coll.name == "tile02" || coll.name == "tile03") //상
    //            {
    //                if (Tile_desert.instance.target_copy.name == "obstacle11_V" && this.gameObject.name == "obstacle11_V")
    //                    Tile_desert.instance.move_ud[0, 3] = false;
    //            }
    //            else if (coll.name == "tile92" || coll.name == "tile93") //하
    //            {
    //                if (Tile_desert.instance.target_copy.name == "obstacle11_V" && this.gameObject.name == "obstacle11_V")
    //                    Tile_desert.instance.move_ud[1, 3] = false;

    //            }


    //            //obstacle12_V : 5열   05 95        04  14
    //            if (coll.name == "tile05") //상
    //            {
    //                if (Tile_desert.instance.target_copy.name == "obstacle12_V" && this.gameObject.name == "obstacle12_V")
    //                    Tile_desert.instance.move_ud[0, 4] = false;
    //            }
    //            else if (coll.name == "tile95") //하
    //            {
    //                if (Tile_desert.instance.target_copy.name == "obstacle12_V" && this.gameObject.name == "obstacle12_V")
    //                    Tile_desert.instance.move_ud[1, 4] = false;
    //            }


    //            //obstacle13_V : 9열   09 99        05  15
    //            if (coll.name == "tile09") //상
    //            {
    //                if (Tile_desert.instance.target_copy.name == "obstacle13_V" && this.gameObject.name == "obstacle13_V")
    //                    Tile_desert.instance.move_ud[0, 5] = false;
    //            }
    //            else if (coll.name == "tile99") //하
    //            {
    //                if (Tile_desert.instance.target_copy.name == "obstacle13_V" && this.gameObject.name == "obstacle13_V")
    //                    Tile_desert.instance.move_ud[1, 5] = false;
    //            }


    //            //obstacle14_V : 3열   03 93           06  16
    //            if (coll.name == "tile03") //상
    //            {
    //                if (Tile_desert.instance.target_copy.name == "obstacle14_V" && this.gameObject.name == "obstacle14_V")
    //                    Tile_desert.instance.move_ud[0, 6] = false;
    //            }
    //            else if (coll.name == "tile93") //하
    //            {
    //                if (Tile_desert.instance.target_copy.name == "obstacle14_V" && this.gameObject.name == "obstacle14_V")
    //                    Tile_desert.instance.move_ud[1, 6] = false;
    //            }




    //            //좌우
    //            //                          좌우움직임 배열인덱스
    //            //                  좌 우   좌  우     
    //            //waterway1_H : 4행 40 49   00  10
    //            if (coll.name == "tile40") //좌
    //            {
    //                if (Tile_desert.instance.target_copy.name == "waterway1_H" && this.gameObject.name == "waterway1_H")
    //                    Tile_desert.instance.move_lr[0, 0] = false;
    //            }
    //            else if (coll.name == "tile49") //우
    //            {
    //                if (Tile_desert.instance.target_copy.name == "waterway1_H" && this.gameObject.name == "waterway1_H")
    //                    Tile_desert.instance.move_lr[1, 0] = false;
    //            }


    //            //waterway2_H : 7행 70 79   01  11
    //            if (coll.name == "tile70") //좌
    //            {
    //                if (Tile_desert.instance.target_copy.name == "waterway2_H" && this.gameObject.name == "waterway2_H")
    //                    Tile_desert.instance.move_lr[0, 1] = false;
    //            }
    //            else if (coll.name == "tile79") //우
    //            {
    //                if (Tile_desert.instance.target_copy.name == "waterway2_H" && this.gameObject.name == "waterway2_H")
    //                    Tile_desert.instance.move_lr[1, 1] = false;
    //            }

    //            //waterway3_H : 2행 20 29   02  12
    //            if (coll.name == "tile20") //좌
    //            {
    //                if (Tile_desert.instance.target_copy.name == "waterway3_H" && this.gameObject.name == "waterway3_H")
    //                    Tile_desert.instance.move_lr[0, 2] = false;
    //            }
    //            else if (coll.name == "tile29") //우
    //            {
    //                if (Tile_desert.instance.target_copy.name == "waterway3_H" && this.gameObject.name == "waterway3_H")
    //                    Tile_desert.instance.move_lr[1, 2] = false;
    //            }

    //            //obstacle7_H : 3행 30 39   03  13
    //            if (coll.name == "tile30") //좌
    //            {
    //                if (Tile_desert.instance.target_copy.name == "obstacle7_H" && this.gameObject.name == "obstacle7_H")
    //                    Tile_desert.instance.move_lr[0, 3] = false;
    //            }
    //            else if (coll.name == "tile39") //우
    //            {
    //                if (Tile_desert.instance.target_copy.name == "obstacle7_H" && this.gameObject.name == "obstacle7_H")
    //                    Tile_desert.instance.move_lr[1, 3] = false;
    //            }

    //            //obstacle8_H : 5행 50 59   04  14
    //            if (coll.name == "tile50") //좌
    //            {
    //                if (Tile_desert.instance.target_copy.name == "obstacle8_H" && this.gameObject.name == "obstacle8_H")
    //                    Tile_desert.instance.move_lr[0, 4] = false;
    //            }
    //            else if (coll.name == "tile59") //우
    //            {
    //                if (Tile_desert.instance.target_copy.name == "obstacle8_H" && this.gameObject.name == "obstacle8_H")
    //                    Tile_desert.instance.move_lr[1, 4] = false;
    //            }

    //            //obstacle9_H : 1행 10 19   05  15
    //            if (coll.name == "tile10") //좌
    //            {
    //                if (Tile_desert.instance.target_copy.name == "obstacle9_H" && this.gameObject.name == "obstacle9_H")
    //                    Tile_desert.instance.move_lr[0, 5] = false;
    //            }
    //            else if (coll.name == "tile19") //우
    //            {
    //                if (Tile_desert.instance.target_copy.name == "obstacle9_H" && this.gameObject.name == "obstacle9_H")
    //                    Tile_desert.instance.move_lr[1, 5] = false;
    //            }


    //            //obstacle10_H :9행 90 99   06  16
    //            if (coll.name == "tile90") //좌
    //            {
    //                if (Tile_desert.instance.target_copy.name == "obstacle10_H" && this.gameObject.name == "obstacle10_H")
    //                    Tile_desert.instance.move_lr[0, 6] = false;
    //            }
    //            else if (coll.name == "tile99") //우
    //            {
    //                if (Tile_desert.instance.target_copy.name == "obstacle10_H" && this.gameObject.name == "obstacle10_H")
    //                    Tile_desert.instance.move_lr[1, 6] = false;
    //            }
    //        }


    //    //닿았을때 값 변경 

    //    //값이 해당 오브젝트일경우 해당 오브젝트 움직임 제한
    //}


    //void Border_to_Desert_Object(int num, string dir, bool object_move) //수로 혹은 장애물이 오브젝트의 경계랑 부딪혔을때 사용함.
    //{
    //    int tmp;
    //    if (dir == "U" || dir == "L")
    //        tmp = 0;
    //    else
    //        tmp = 1;

    //    if (dir == "U" || dir == "D")
    //    {
    //        switch (num)
    //        {
    //            //수로
    //            case 4:
    //                Tile_desert.instance.move_ud[tmp, 0] = object_move;
    //                break;
    //            case 5:
    //                Tile_desert.instance.move_ud[tmp, 1] = object_move;
    //                break;
    //            case 6:
    //                Tile_desert.instance.move_ud[tmp, 2] = object_move;
    //                break;

    //            //장애물
    //            case 11:
    //                Tile_desert.instance.move_ud[tmp, 3] = object_move;
    //                break;
    //            case 12:
    //                Tile_desert.instance.move_ud[tmp, 4] = object_move;
    //                break;
    //            case 13:
    //                Tile_desert.instance.move_ud[tmp, 5] = object_move;
    //                break;
    //            case 14:
    //                Tile_desert.instance.move_ud[tmp, 6] = object_move;
    //                break;
    //        }
    //    }
    //    else if (dir == "L" || dir == "R")
    //    {
    //        switch (num)
    //        {
    //            //수로
    //            case 1:
    //                Tile_desert.instance.move_lr[tmp, 0] = object_move;
    //                break;
    //            case 2:
    //                Tile_desert.instance.move_lr[tmp, 1] = object_move;
    //                break;
    //            case 3:
    //                Tile_desert.instance.move_lr[tmp, 2] = object_move;
    //                break;

    //            //장애물
    //            case 7:
    //                Tile_desert.instance.move_lr[tmp, 3] = object_move;
    //                break;
    //            case 8:
    //                Tile_desert.instance.move_lr[tmp, 4] = object_move;
    //                break;
    //            case 9:
    //                Tile_desert.instance.move_lr[tmp, 5] = object_move;
    //                break;
    //            case 10:
    //                Tile_desert.instance.move_lr[tmp, 6] = object_move;
    //                break;
    //        }

    //    }


    //    //dir이 상 또는 좌 일 경우 변수 값 =0
    //    //dir이 하 또는 우 일 경우 변수 값 =1



    //}
}//end class
















//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }


//    private void OnTriggerExit2D(Collider2D coll)
//    {
//        if (coll.tag == "Border_in")
//        {
//            switch (coll.name)
//            {
//                case "border_L":
//                    Debug.Log("왼쪽 경계와 떨어졌습니다.");
//                    Tile_desert.instance.move_uplr[2] = true;
//                    break;
//                case "border_R":
//                    Debug.Log("오른쪽 경계와 떨어졌습니다.");
//                    Tile_desert.instance.move_uplr[3] = true;
//                    break;
//                case "border_U":
//                    Debug.Log("위쪽 경계와 떨어졌습니다.");
//                    Tile_desert.instance.move_uplr[0] = true;
//                    break;
//                case "border_D":
//                    Debug.Log("아래쪽 경계와 떨어졌습니다.");
//                    Tile_desert.instance.move_uplr[1] = true;
//                    break;
//                default:
//                    break;
//            }
//        }


//    }

//    private void OnTriggerStay2D(Collider2D coll)
//    {

//        //if (coll.tag == "Desert_Object")
//        //{
//        //    if (Tile_desert.instance.target_copy.name == "waterway1_H")//target이 1번 오브젝트 일 때
//        //    {
//        //        coll.name == n_left : 1번 오브젝트가 다른 오브젝트의 왼쪽부분에 부딪혔다는 뜻.
//        //        contain이용해서 left를 문자열에 가지고 있을시
//        //        왼쪽에 부딪혔으니 왼쪽으로 못가게 함.
//        //        if (coll.name.Contains("left"))
//        //        {

//        //        }
//        //    }
//        //    Debug.Log("오브젝트와 부딪힘");
//        //    for (int i = 0; i < 4; i++)
//        //    {
//        //        Tile_desert.instance.move_uplr[i] = false;

//        //    }
//        //    Debug.Log("move_uplr[3]: " + Tile_desert.instance.move_uplr[3]);
//        //}

//        if (coll.tag == "Border_in") //경계랑 오브젝트랑 붙어있을때
//        {
//            if(Tile_desert.instance.target_copy != null)
//            {
//                switch (coll.name)
//                {
//                    case "border_L":
//                        if (Tile_desert.instance.target_copy.name == "waterway1_H")
//                        {
//                            Tile_desert.instance.move_uplr[2] = false;
//                        }
//                        if (Tile_desert.instance.target_copy.name == "waterway2_H")
//                        {
//                            Tile_desert.instance.move_uplr[2] = false;
//                        }
//                        break;
//                    case "border_R":
//                        if (Tile_desert.instance.target_copy.name == "waterway1_H")
//                        {
//                            Tile_desert.instance.move_uplr[3] = false;
//                        }
//                        break;
//                    default:

//                        break;
//                }
//            }
//        }
//    }



//}//end class

////    if (coll.tag == "Tile") // 오브젝트가 타일과 부딪혔을 때
////    {
////        //Debug.Log(coll.name);
////        for (int a = 0; a < 10; a++)
////        {
////            for (int b = 0; b < 10; b++)
////            {
////                if (coll.name == "tile" + a.ToString() + b.ToString())
////                {
////                    for (int i = 1; i <= 9; i++) //오브젝트 개수 및 번호
////                    {
////                        if (this.gameObject.name.Contains(i.ToString())) //현재 스크립트를 가지고있는 오브젝트의 이름이 특정 문자열을 가지고 있을 경우 ->i를 가지고있을경우
////                        {
////                            for (int x = 10; x <= 14; x++) 
////                            {
////                                if (!this.gameObject.name.Contains(x.ToString())) //10~14까지의 오브젝트가 아닌경우
////                                {
////                                    Tile_desert.instance.tile[a, b] = i * 10 + 1;
////                                    // Debug.Log("tile[" + a + "," + b + "] = " + Tile_desert.instance.tile[a, b]);
////                                }
////                            }
////                        }
////                    }

////                    for (int i = 10; i <= 14; i++) //오브젝트 개수 및 번호
////                    {
////                        if (this.gameObject.name.Contains(i.ToString())) //현재 스크립트를 가지고있는 오브젝트의 이름이 특정 문자열을 가지고 있을 경우 ->i를 가지고있을경우
////                        {

////                            Tile_desert.instance.tile[a, b] = i * 10 + 1;
////                            // Debug.Log("tile[" + a + "," + b + "] = " + Tile_desert.instance.tile[a, b]);

////                        }
////                    }

////                }
////            }

////        }
////        Debug.Log("tile[4,0] = " + Tile_desert.instance.tile[4, 0]);
////        Debug.Log("tile[4,1] = " + Tile_desert.instance.tile[4, 1]);
////        Debug.Log("tile[4,2] = " + Tile_desert.instance.tile[4, 2]);
////        Debug.Log("tile[4,3] = " + Tile_desert.instance.tile[4, 3]);
////        Debug.Log("tile[4,4] = " + Tile_desert.instance.tile[4, 4]);
////        Debug.Log("tile[4,5] = " + Tile_desert.instance.tile[4, 5]);
////        Debug.Log("              ");
////    }