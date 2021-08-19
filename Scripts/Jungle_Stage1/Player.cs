using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum Player_State
    {
        Idle,
        Up,
        Down,
        Left,
        Right,
        Idle_U,
        Idle_D,
        Idle_L,
        Idle_R
    };
    Player_State player_state = Player_State.Idle;

    public enum Player_Before_State
    {
        Idle,
        Up,
        Down,
        Left,
        Right,
        Idle_U,
        Idle_D,
        Idle_L,
        Idle_R
    };
    Player_Before_State player_before_state = Player_Before_State.Idle;

    Animator ani;

    [HideInInspector]
    public bool[] playerMove = new bool[4]; //0:상  1:하  2:좌  3:우

    [HideInInspector]
    public bool enable_moveplayer = true;

    //일정간격으로 이동하기 관련 변수
    Vector3 origPos, targetPos;
    float timeToMove = 0.2f;
    bool isMoving;

    //플레이어 이동 간격설정
    Vector3 move_interval_U = new Vector3(0, 0.7f, 0);
    Vector3 move_interval_D = new Vector3(0, -0.7f, 0);
    Vector3 move_interval_L = new Vector3(-0.7f, 0, 0);
    Vector3 move_interval_R = new Vector3(0.7f, 0, 0);

    static public Player instance;
    private void Awake()
    {
        instance = this;

        for (int i = 0; i < playerMove.Length; i++)
        {
            playerMove[i] = true;
        }

        ani = GetComponent<Animator>();
        for (int i = 0; i < playerMove.Length; i++)
        {
            playerMove[i] = true;
        }

        ani = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {

        if(enable_moveplayer)
        {
            PlayerMove();
        }

        //Click_Hint(); //힌트 클릭 시 UI 열리게 하기
    }

    void PlayerMove()
    {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            player_state = Player_State.Up;

            ani.SetBool("Up", true);
            ani.SetBool("Down", false);
            ani.SetBool("Left", false);
            ani.SetBool("Right", false);

            ani.SetBool("Idle_U", false);
            ani.SetBool("Idle_D", false);
            ani.SetBool("Idle_L", false);
            ani.SetBool("Idle_R", false);

            if (playerMove[0] && !isMoving)
            {
                StartCoroutine(GridMovePlayer_Routine(move_interval_U));
            }

        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            player_state = Player_State.Down;
            ani.SetBool("Up", false);
            ani.SetBool("Down", true);
            ani.SetBool("Left", false);
            ani.SetBool("Right", false);

            ani.SetBool("Idle_U", false);
            ani.SetBool("Idle_D", false);
            ani.SetBool("Idle_L", false);
            ani.SetBool("Idle_R", false);

            if (playerMove[1] && !isMoving)
            {
                StartCoroutine(GridMovePlayer_Routine(move_interval_D));
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            player_state = Player_State.Left;
            ani.SetBool("Up", false);
            ani.SetBool("Down", false);
            ani.SetBool("Left", true);
            ani.SetBool("Right", false);

            ani.SetBool("Idle_U", false);
            ani.SetBool("Idle_D", false);
            ani.SetBool("Idle_L", false);
            ani.SetBool("Idle_R", false);

            if (playerMove[2] && !isMoving)
            {
                StartCoroutine(GridMovePlayer_Routine(move_interval_L));
            }

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            player_state = Player_State.Right;
            ani.SetBool("Up", false);
            ani.SetBool("Down", false);
            ani.SetBool("Left", false);
            ani.SetBool("Right", true);

            ani.SetBool("Idle_U", false);
            ani.SetBool("Idle_D", false);
            ani.SetBool("Idle_L", false);
            ani.SetBool("Idle_R", false);

            if (playerMove[3] && !isMoving)
            {
                StartCoroutine(GridMovePlayer_Routine(move_interval_R));
            }
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) ||
            Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)) //키보드에서 손을 떼었을 경우
        {
            ChagePlayerBeforeState();
            ActivateIdleState();
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        bool set_move = false;

        //경계부분 충돌시 이동키 제한
        if (coll.name == "U")
            playerMove[0] = set_move;
        if (coll.name == "D_l" || coll.name == "D_r")
            playerMove[1] = set_move;
        if (coll.name == "L")
            playerMove[2] = set_move;
        if (coll.name == "R")
            playerMove[3] = set_move;

        //문쪽 하좌우
        if (coll.name == "Door_part_D")
            playerMove[1] = set_move;
        if (coll.name == "Door_part_L")
            playerMove[2] = set_move;
        if (coll.name == "Door_part_R")
            playerMove[3] = set_move;

        //나무쪽
        if (coll.name == "Tree_Part_U") //나무의 위쪽이므로 이동키 아래를 막는것임
            playerMove[1] = set_move;
        if (coll.name == "Tree_Part_R") //나무의 오른쪽이므로 이동키 왼쪽을 막는것임
            playerMove[2] = set_move;


        if (!Scaffolding.instance.jungle_stage_1)
        {

            if (coll.name == "Scaffolding_1")
            {
                //GameObject tread_scaffolding = Instantiate(Scaffolding.instance.Tread_Scaffolding);
                //tread_scaffolding.transform.position = Scaffolding.instance.Scaffolding_1.gameObject.transform.position;

                Scaffolding.instance.Tread_Scaffolding.SetActive(true);
                Scaffolding.instance.Tread_Scaffolding.transform.position = Scaffolding.instance.Scaffolding_1.gameObject.transform.position; //발판을 밟았을 때의 effect를 해당 발판으로 가져옴.


                //2번째 내 맘대로
                Scaffolding.instance.scaffolding[0] = true;
                Scaffolding.instance.scaffolding[4] = true;
                Scaffolding.instance.scaffolding[5] = false;
                Scaffolding.instance.scaffolding[8] = false;

                Scaffolding.instance.On_Scaffolding(0);
                Scaffolding.instance.On_Scaffolding(4);
                Scaffolding.instance.Off_Scaffolding(5);
                Scaffolding.instance.Off_Scaffolding(8);

                Debug.Log("1번 발판");
            }
            if (coll.name == "Scaffolding_2")
            {

                Scaffolding.instance.Tread_Scaffolding.SetActive(true);
                Scaffolding.instance.Tread_Scaffolding.transform.position = Scaffolding.instance.Scaffolding_2.gameObject.transform.position;


                //2번째 내 맘대로
                Scaffolding.instance.scaffolding[0] = true;
                Scaffolding.instance.scaffolding[1] = true;
                Scaffolding.instance.scaffolding[2] = true;
                Scaffolding.instance.scaffolding[6] = false;
                Scaffolding.instance.scaffolding[8] = false;

                Scaffolding.instance.On_Scaffolding(0);
                Scaffolding.instance.On_Scaffolding(1);
                Scaffolding.instance.On_Scaffolding(2);
                Scaffolding.instance.Off_Scaffolding(6);
                Scaffolding.instance.Off_Scaffolding(8);

                Debug.Log("2번 발판");

            }
            if (coll.name == "Scaffolding_3")
            {

                Scaffolding.instance.Tread_Scaffolding.SetActive(true);
                Scaffolding.instance.Tread_Scaffolding.transform.position = Scaffolding.instance.Scaffolding_3.gameObject.transform.position;


                //2번째 내 맘대로
                Scaffolding.instance.scaffolding[2] = true;
                Scaffolding.instance.scaffolding[4] = true;
                Scaffolding.instance.scaffolding[3] = false;
                Scaffolding.instance.scaffolding[7] = false;

                Scaffolding.instance.On_Scaffolding(2);
                Scaffolding.instance.On_Scaffolding(4);
                Scaffolding.instance.Off_Scaffolding(3);
                Scaffolding.instance.Off_Scaffolding(7);

                Debug.Log("3번 발판");
            }
            if (coll.name == "Scaffolding_4")
            {
                Scaffolding.instance.Tread_Scaffolding.SetActive(true);
                Scaffolding.instance.Tread_Scaffolding.transform.position = Scaffolding.instance.Scaffolding_4.gameObject.transform.position;


                //2번째 내 맘대로
                Scaffolding.instance.scaffolding[0] = true;
                Scaffolding.instance.scaffolding[3] = true;
                Scaffolding.instance.scaffolding[6] = true;
                Scaffolding.instance.scaffolding[2] = false;
                Scaffolding.instance.scaffolding[8] = false;

                Scaffolding.instance.On_Scaffolding(0);
                Scaffolding.instance.On_Scaffolding(3);
                Scaffolding.instance.On_Scaffolding(6);
                Scaffolding.instance.Off_Scaffolding(2);
                Scaffolding.instance.Off_Scaffolding(8);


                Debug.Log("4번 발판");
            }
            if (coll.name == "Scaffolding_5")
            {
                Scaffolding.instance.Tread_Scaffolding.SetActive(true);
                Scaffolding.instance.Tread_Scaffolding.transform.position = Scaffolding.instance.Scaffolding_5.gameObject.transform.position;


                //2번째 내 맘대로
                Scaffolding.instance.scaffolding[0] = false;
                Scaffolding.instance.scaffolding[2] = false;
                Scaffolding.instance.scaffolding[6] = false;
                Scaffolding.instance.scaffolding[8] = false;

                Scaffolding.instance.Off_Scaffolding(0);
                Scaffolding.instance.Off_Scaffolding(2);
                Scaffolding.instance.Off_Scaffolding(6);
                Scaffolding.instance.Off_Scaffolding(8);

                Debug.Log("5번 발판");
            }
            if (coll.name == "Scaffolding_6")
            {
                Scaffolding.instance.Tread_Scaffolding.SetActive(true);
                Scaffolding.instance.Tread_Scaffolding.transform.position = Scaffolding.instance.Scaffolding_6.gameObject.transform.position;

                //2번째 내 맘대로
                Scaffolding.instance.scaffolding[2] = true;
                Scaffolding.instance.scaffolding[5] = true;
                Scaffolding.instance.scaffolding[8] = true;
                Scaffolding.instance.scaffolding[0] = false;
                Scaffolding.instance.scaffolding[6] = false;

                Scaffolding.instance.On_Scaffolding(2);
                Scaffolding.instance.On_Scaffolding(5);
                Scaffolding.instance.On_Scaffolding(8);
                Scaffolding.instance.Off_Scaffolding(0);
                Scaffolding.instance.Off_Scaffolding(6);

                Debug.Log("6번 발판");
            }
            if (coll.name == "Scaffolding_7")
            {
                Scaffolding.instance.Tread_Scaffolding.SetActive(true);
                Scaffolding.instance.Tread_Scaffolding.transform.position = Scaffolding.instance.Scaffolding_7.gameObject.transform.position;


                //2번째 내 맘대로
                Scaffolding.instance.scaffolding[6] = true;
                Scaffolding.instance.scaffolding[4] = true;
                Scaffolding.instance.scaffolding[1] = false;
                Scaffolding.instance.scaffolding[5] = false;

                Scaffolding.instance.On_Scaffolding(6);
                Scaffolding.instance.On_Scaffolding(4);
                Scaffolding.instance.Off_Scaffolding(1);
                Scaffolding.instance.Off_Scaffolding(5);

                Debug.Log("7번 발판");
            }
            if (coll.name == "Scaffolding_8")
            {
                Scaffolding.instance.Tread_Scaffolding.SetActive(true);
                Scaffolding.instance.Tread_Scaffolding.transform.position = Scaffolding.instance.Scaffolding_8.gameObject.transform.position;


                //2번째 내 맘대로
                Scaffolding.instance.scaffolding[6] = true;
                Scaffolding.instance.scaffolding[7] = true;
                Scaffolding.instance.scaffolding[8] = true;
                Scaffolding.instance.scaffolding[0] = false;
                Scaffolding.instance.scaffolding[2] = false;

                Scaffolding.instance.On_Scaffolding(6);
                Scaffolding.instance.On_Scaffolding(7);
                Scaffolding.instance.On_Scaffolding(8);
                Scaffolding.instance.Off_Scaffolding(0);
                Scaffolding.instance.Off_Scaffolding(2);

                Debug.Log("8번 발판");
            }
            if (coll.name == "Scaffolding_9")
            {
                Scaffolding.instance.Tread_Scaffolding.SetActive(true);
                Scaffolding.instance.Tread_Scaffolding.transform.position = Scaffolding.instance.Scaffolding_9.gameObject.transform.position;
;

                //2번째 내 맘대로
                Scaffolding.instance.scaffolding[4] = true;
                Scaffolding.instance.scaffolding[8] = true;
                Scaffolding.instance.scaffolding[1] = false;
                Scaffolding.instance.scaffolding[3] = false;

                Scaffolding.instance.On_Scaffolding(4);
                Scaffolding.instance.On_Scaffolding(8);
                Scaffolding.instance.Off_Scaffolding(1);
                Scaffolding.instance.Off_Scaffolding(3);

                Debug.Log("9번 발판");
            }
            if (coll.name == "Reset_Scaffolding")
            {
                Scaffolding.instance.Tread_Scaffolding.SetActive(false);
                Scaffolding.instance.Reset_Scaffolding_State();
            }          
        }
    }


    private void OnTriggerExit2D(Collider2D coll) 
    {

        bool set_move = true;

        //경계부분 충돌시 이동키 제한
        //맵 상하좌우
        if (coll.name == "U")
            playerMove[0] = set_move;
        if (coll.name == "D_l" || coll.name == "D_r")
            playerMove[1] = set_move;
        if (coll.name == "L")
            playerMove[2] = set_move;
        if (coll.name == "R")
            playerMove[3] = set_move;


        //문쪽 하좌우
        if(coll.name == "Door_part_D")
            playerMove[1] = set_move;
        if (coll.name == "Door_part_L")
            playerMove[2] = set_move;
        if (coll.name == "Door_part_R")
            playerMove[3] = set_move;

        //나무쪽
        if (coll.name == "Tree_Part_U") //나무의 위쪽이므로 이동키 아래를 막는것임
            playerMove[1] = set_move;
        if (coll.name == "Tree_Part_R") //나무의 오른쪽이므로 이동키 왼쪽을 막는것임
            playerMove[2] = set_move;


        if (coll.tag == "Scaffolding_1")
            Scaffolding.instance.TreadEffect_Delete_Postpone();
        if (coll.tag == "Scaffolding_2")
            Scaffolding.instance.TreadEffect_Delete_Postpone();
        if (coll.tag == "Scaffolding_3")
            Scaffolding.instance.TreadEffect_Delete_Postpone();
        if (coll.tag == "Scaffolding_4")
            Scaffolding.instance.TreadEffect_Delete_Postpone();
        if (coll.tag == "Scaffolding_5")
            Scaffolding.instance.TreadEffect_Delete_Postpone();
        if (coll.tag == "Scaffolding_6")
            Scaffolding.instance.TreadEffect_Delete_Postpone();
        if (coll.tag == "Scaffolding_7")
            Scaffolding.instance.TreadEffect_Delete_Postpone();
        if (coll.tag == "Scaffolding_8")
            Scaffolding.instance.TreadEffect_Delete_Postpone();
        if (coll.tag == "Scaffolding_9")
            Scaffolding.instance.TreadEffect_Delete_Postpone();

    }

    private void OnTriggerStay2D(Collider2D coll)
    {

        if (!Scaffolding.instance.jungle_stage_1)
        {
            if (coll.tag == "Hint_Interaction")
            {
                //Debug.Log("Hint_Interaction과 부딪힘");

                if (Input.GetKeyDown(KeyCode.R)) //이거 플레이어 부딪히는게 발에 있어서 벽에 닿기가 힘듬. 따라서 마우스 클릭만 해도 UI창 띄우는게 나을듯.
                {
                    //Debug.Log("R키 눌림");
                    enable_moveplayer = false;
                    Rule_Scaffolding.instance.Hint_Canvas.gameObject.SetActive(true);
                    Rule_Scaffolding.instance.Invoke_Repeating_Rotate_Rule_Scaffolding();
                }
            }
        }

    }

    void ChagePlayerBeforeState()
    {
        switch (player_state)
        {
            case Player_State.Idle:
                player_before_state = Player_Before_State.Idle;
                break;
            case Player_State.Up:
                player_before_state = Player_Before_State.Up;
                break;
            case Player_State.Down:
                player_before_state = Player_Before_State.Down;
                break;
            case Player_State.Left:
                player_before_state = Player_Before_State.Left;
                break;
            case Player_State.Right:
                player_before_state = Player_Before_State.Right;
                break;
            case Player_State.Idle_U:
                player_before_state = Player_Before_State.Idle_U;
                break;
            case Player_State.Idle_D:
                player_before_state = Player_Before_State.Idle_D;
                break;
            case Player_State.Idle_L:
                player_before_state = Player_Before_State.Idle_L;
                break;
            case Player_State.Idle_R:
                player_before_state = Player_Before_State.Idle_R;
                break;
        }
    }

    void ActivateIdleState()
    {
        if (player_before_state == Player_Before_State.Up || player_before_state == Player_Before_State.Idle_U)
        {
            player_state = Player_State.Idle;
            ani.SetBool("Idle_U", true);
            ani.SetBool("Idle_D", false);
            ani.SetBool("Idle_L", false);
            ani.SetBool("Idle_R", false);

            ani.SetBool("Up", false);
            ani.SetBool("Down", false);
            ani.SetBool("Left", false);
            ani.SetBool("Right", false);
        }
        else if (player_before_state == Player_Before_State.Down || player_before_state == Player_Before_State.Idle_D)
        {
            player_state = Player_State.Idle;
            ani.SetBool("Idle_U", false);
            ani.SetBool("Idle_D", true);
            ani.SetBool("Idle_L", false);
            ani.SetBool("Idle_R", false);

            ani.SetBool("Up", false);
            ani.SetBool("Down", false);
            ani.SetBool("Left", false);
            ani.SetBool("Right", false);
        }
        else if (player_before_state == Player_Before_State.Left || player_before_state == Player_Before_State.Idle_L)
        {
            player_state = Player_State.Idle;
            ani.SetBool("Idle_U", false);
            ani.SetBool("Idle_D", false);
            ani.SetBool("Idle_L", true);
            ani.SetBool("Idle_R", false);

            ani.SetBool("Up", false);
            ani.SetBool("Down", false);
            ani.SetBool("Left", false);
            ani.SetBool("Right", false);
        }
        else if (player_before_state == Player_Before_State.Right || player_before_state == Player_Before_State.Idle_R)
        {
            player_state = Player_State.Idle;
            ani.SetBool("Idle_U", false);
            ani.SetBool("Idle_D", false);
            ani.SetBool("Idle_L", false);
            ani.SetBool("Idle_R", true);

            ani.SetBool("Up", false);
            ani.SetBool("Down", false);
            ani.SetBool("Left", false);
            ani.SetBool("Right", false);
        }
    }

    IEnumerator GridMovePlayer_Routine(Vector3 direction)
    {
        isMoving = true;

        float elapsedTime = 0;

        origPos = transform.position;
        targetPos = origPos + direction;

        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(origPos,
                                              targetPos,
                                              (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;
    }

    void Click_Hint() //힌트 클릭했을시 UI열림
    {
        if (Input.GetMouseButtonUp(0)) //마우스 클릭아니면 벽에 닿는거를 힌트 Collider를 늘려야할듯
        {
            GameObject target;
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

            if (hit.collider != null)
            {
                target = hit.collider.gameObject;
                if (target.tag == "Hint_Interaction")
                {
                    enable_moveplayer = false;
                    Rule_Scaffolding.instance.Hint_Canvas.gameObject.SetActive(true);
                    Rule_Scaffolding.instance.Invoke_Repeating_Rotate_Rule_Scaffolding();
                }
            }
        }
    }
}//end class
