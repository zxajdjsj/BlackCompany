using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_desert : MonoBehaviour
{
    //enum PLAYSTATE
    //{
    //    NONE,
    //    BLOCK_CHECK,
    //    BLOCK_MOVE
    //};
    //PLAYSTATE playstate = PLAYSTATE.NONE;

    //움직임 변수
    float moveX, moveY;

    //수로
    public GameObject Waterway1_H; //가로
    public GameObject Waterway2_H;
    public GameObject Waterway3_H;
    public GameObject Waterway4_V; //세로
    public GameObject Waterway5_V; 
    public GameObject Waterway6_V;

    //장애물                    
    public GameObject Obstacle7_H; //가로
    public GameObject Obstacle8_H;
    public GameObject Obstacle9_H;
    public GameObject Obstacle10_H;
    public GameObject Obstacle11_V; //세로
    public GameObject Obstacle12_V;
    public GameObject Obstacle13_V;
    public GameObject Obstacle14_V;

    //플레이어 움직임 제어
    bool desert_stage1_player_move= false;

    //상, 하로 움직이는 오브젝트 움직임 변수 
    public bool[,] move_ud = new bool[2,7]; //0행: 상 1행: 하
    //상하 : waterway4,5,6,obstacle11,12,13,14 

    //좌, 우로 움직이는 오브젝트 움직임 변수
    public bool[,] move_lr = new bool[2,7]; //0행: 좌 1행: 우
    //좌우 : waterway1,2,3, obstacle7,8,9,10

    //마우스가 오브젝트 클릭을 할 수 있도록 이용하는 변수
    GameObject target =null;
    Vector2 pos ;
    RaycastHit2D hit;

    public GameObject target_copy = null;

   
    //변수명 너무 길게쓰면 배열범위 넘었다고 오류뜸.

    static public Tile_desert instance;
    private void Awake()
    {
        instance = this;

        //얘들은 처음부터 부딪힐것같아서 초기화를 빨리 해주기
        //waterway6_V up + down - block
        //obstacle9_H left
        //waterway3_H right
        //obstacle13_V up - block
        //obstacle8_H left -block right - block
        //obstacle12_V down
        //waterway2_H left + right - block
        //waterway4_V down + up - block
        //obstacle10_H left - block
        //obstacle14_V down - block
        // waterway5_V down

        //오브젝트의 상하좌우 경계 오브젝트 태그 설정
        for(int i=1; i<=9; i++)
        {
            if(GameObject.Find("*"+ i+"_left"))
            {
                GameObject.Find("*" + i +"_left").GetComponent<Transform>().tag = "Desert_Object_Border_L";
                //Debug.Log(i + "번째 오브젝트 태그:" + GameObject.Find(i + "_left").GetComponent<Transform>().tag);
            }
            if (GameObject.Find("*" + i + "_right")) //else if쓰면 안됨. i=1일때 두조건다 써야해서
            {
                GameObject.Find("*" + i + "_right").GetComponent<Transform>().tag = "Desert_Object_Border_R";
                //Debug.Log(i + "번째 오브젝트 태그:" + GameObject.Find(i + "_right").GetComponent<Transform>().tag);
            }
            if (GameObject.Find("*" + i + "_up"))
            {
                GameObject.Find("*" + i + "_up").GetComponent<Transform>().tag = "Desert_Object_Border_U";
               // Debug.Log(i + "번째 오브젝트 태그:" + GameObject.Find(i + "_up").GetComponent<Transform>().tag);
            }
            if (GameObject.Find("*" + i + "_down"))
            {
                GameObject.Find("*" + i + "_down").GetComponent<Transform>().tag = "Desert_Object_Border_D";
               // Debug.Log(i + "번째 오브젝트 태그:" + GameObject.Find(i + "_down").GetComponent<Transform>().tag);
            }
            
        }
        for(int i=10; i<=14; i++)
        {
            if (GameObject.Find( i + "_left"))
            {
                GameObject.Find(i + "_left").GetComponent<Transform>().tag = "Desert_Object_Border_L";
                //Debug.Log(i + "번째 오브젝트 태그:" + GameObject.Find(i + "_left").GetComponent<Transform>().tag);
            }
            if (GameObject.Find( i + "_right"))
            {
                GameObject.Find( i + "_right").GetComponent<Transform>().tag = "Desert_Object_Border_R";
                //Debug.Log(i + "번째 오브젝트 태그:" + GameObject.Find(i + "_right").GetComponent<Transform>().tag);
            }
            if (GameObject.Find( i + "_up"))
            {
                GameObject.Find( i + "_up").GetComponent<Transform>().tag = "Desert_Object_Border_U";
                // Debug.Log(i + "번째 오브젝트 태그:" + GameObject.Find(i + "_up").GetComponent<Transform>().tag);
            }
            if (GameObject.Find( i + "_down"))
            {
                GameObject.Find( i + "_down").GetComponent<Transform>().tag = "Desert_Object_Border_D";
                // Debug.Log(i + "번째 오브젝트 태그:" + GameObject.Find(i + "_down").GetComponent<Transform>().tag);
            }
        }

        for (int a=0; a<2; a++)
        {
            for(int b=0; b<7; b++)
            {
                move_ud[a, b] = true;
                move_lr[a, b] = true;
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
     
       // Debug.Log("마우스 좌클릭");
       Click_Obj();
        
      if(desert_stage1_player_move)
        {
            Desert_Stage1_Player_Move();
        }


    }

    void Click_Obj()
    {
        if (Input.GetMouseButtonDown(0))
        {

            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
            //Vector2.zero
            //레이캐스트 사용할때 모든 물체가 Collider를 가지고 있어야함.
            //Collider가 없는 물체를 클릭했을 경우
            //NullReferenceException: Object reference not set to an instance of an object 라고 오류가 난다.


            if (hit.collider != null)
            {
                if (hit.collider.tag == "Desert_Object")
                {
                    // Debug.Log(hit.collider.name);
                    target = hit.collider.gameObject;
                    Debug.Log("타겟이름 : " + target.name);
                    desert_stage1_player_move = true;
                    target_copy = target;
                }//else return
            }
        }
    }

    void Desert_Stage1_Player_Move() //각 오브젝트를 클릭할때마다의 관련 플레이어 움직임관리
    {
        if(hit.collider != null)
        {
            if (hit.collider.tag == "Desert_Object")
            {
                switch (target.name)
                {
                    //수로
                    //좌우
                    case "waterway1_H":
                        Object_Move_H(1);
                        break;
                    case "waterway2_H":
                        Object_Move_H(2);
                        break;
                    case "waterway3_H":
                        Object_Move_H(3);
                        break;

                    //상하
                    case "waterway4_V":
                        Object_Move_V(1);
                        break;
                    case "waterway5_V":
                        Object_Move_V(2);
                        break;
                    case "waterway6_V":
                        Object_Move_V(3);
                        break;

                    //장애물
                    //좌우
                    case "obstacle7_H":
                        Object_Move_H(4);
                        break;
                    case "obstacle8_H":
                        Object_Move_H(5);
                        break;
                    case "obstacle9_H":
                        Object_Move_H(6);
                        break;
                    case "obstacle10_H":
                        Object_Move_H(7);
                        break;

                    //상하
                    case "obstacle11_V":
                        Object_Move_V(4);
                        break;
                    case "obstacle12_V":
                        Object_Move_V(5);
                        break;
                    case "obstacle13_V":
                        Object_Move_V(6);
                        break;
                    case "obstacle14_V":
                        Object_Move_V(7);
                        break;
                    default:
                        break;
                }
            }
        }     
    }

    void Object_Move_H(int input) //좌우 움직임
    {
        //상하 : waterway4,5,6, obstacle11,12,13,14 
        //좌우 : waterway1,2,3, obstacle7,8,9,10
        if (Input.GetKeyUp(KeyCode.D))
        {
            Debug.Log("D");
            if(move_lr[1,input-1])
            {
                target.transform.position = new Vector2(target.transform.position.x + 0.8f, target.transform.position.y);
            }
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            Debug.Log("A");
            if (move_lr[0, input - 1])
            {
                target.transform.position = new Vector2(target.transform.position.x - 0.8f, target.transform.position.y);
            }
        }
    }

    void Object_Move_V(int input) //상하 움직임 
    {
        //상하 : waterway4,5,6, obstacle11,12,13,14 
        //좌우 : waterway1,2,3, obstacle7,8,9,10
        if (Input.GetKeyUp(KeyCode.W))
        {
            Debug.Log("W");
            if (move_ud[0, input - 1])
            {
                target.transform.position = new Vector2(target.transform.position.x , target.transform.position.y + 0.8f);
            }
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            Debug.Log("S");
            if (move_ud[1, input - 1])
            {
                target.transform.position = new Vector2(target.transform.position.x , target.transform.position.y - 0.8f);
            }
        }
    }


}// end class
