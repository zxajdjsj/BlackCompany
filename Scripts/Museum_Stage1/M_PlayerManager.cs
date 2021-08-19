using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_PlayerManager : MonoBehaviour
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

    //일정간격으로 이동하기 관련 변수
    Vector3 origPos, targetPos;
    float timeToMove = 0.2f;
    bool isMoving;

    //ont에서 사용할 변수
    bool enableMove;

    //플레이어가 밟고 있는 발판 
    GameObject TreadTile;

    static public M_PlayerManager instance;
    private void Awake()
    {
        instance = this;
        for (int i = 0; i < playerMove.Length; i++)
        {
            playerMove[i] = true;
        }

        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(player_state);
        ConfirmRay();
        PlayerMove();
       
    }

    //다른칸으로 이동하면서 애니메이션 적용 후 이동시키기
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
                StartCoroutine(GridMovePlayer_Routine(Vector3.up));
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
                StartCoroutine(GridMovePlayer_Routine(Vector3.down));
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
                StartCoroutine(GridMovePlayer_Routine(Vector3.left));
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
                StartCoroutine(GridMovePlayer_Routine(Vector3.right));
            }
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) ||
            Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)) //키보드에서 손을 떼었을 경우
        {
            ChagePlayerBeforeState();
            ActivateIdleState();
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
            player_state = Player_State.Idle_U;
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
            player_state = Player_State.Idle_D;
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
            player_state = Player_State.Idle_L;
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
            player_state = Player_State.Idle_R;
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

    void ConfirmRay() //플레이어의 앞방향에 물체가 있는지 검사한다.
    {
        //플레이어가 바라보는 방향에 따라 레이저의 검사 방향을 바꿔줘야함.
        if(player_state == Player_State.Idle)
        {
            //Debug.DrawRay(TreadTile.transform.position, Vector3.down, Color.red);
        }
        else if (player_state == Player_State.Up || player_state == Player_State.Idle_U)
        {
            //ray 말고 나중에 trigger이용하는게 버그가 없을듯
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(TreadTile.transform.position.x, TreadTile.transform.position.y), Vector3.up, 1f, LayerMask.GetMask("Object"));

            RaycastHit2D hit_tile = Physics2D.Raycast(new Vector2(TreadTile.transform.position.x, TreadTile.transform.position.y), Vector3.up, 1f, LayerMask.GetMask("Tile"));
            Debug.DrawRay(TreadTile.transform.position, Vector3.up , Color.red);

            if (hit.collider != null) //플레이어의 앞에 물체가 있을 경우
            {
                playerMove[0] = false; //플레이어 오브젝트 앞에 있을때 오브젝트 통과못하게 이동키 막기
                //되긴하는데 너무 빨리 움직이는경우 통과할때가 잇다. 이거 오류 어떻게 잡아야할지 모르겠네
                //아니면 나중에 맵 제작하고 타일을 밟았을때 이동키를 제한하는 수밖에 없을듯.
                //Debug.Log("위쪽 물체감지");
                if (Input.GetKeyDown(KeyCode.R)) //R키를 눌렀을시 물체를 이동시킨다.
                {
                    hit.collider.gameObject.transform.Translate(Vector3.up);
                }
            }

            //플레이어의 앞에오브젝트가 없고, 가장자리 타일이 아닐경우 플레이어의 움직임을 true로 바꾼다.
            //이부분 8.6일 해결해보기
            if (hit.collider == null && M_TileManager.instance.CheckTileEdge(0, hit_tile.collider.gameObject) == true)
                playerMove[0] = true;
        }
        else if (player_state == Player_State.Down || player_state == Player_State.Idle_D)
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(TreadTile.transform.position.x, TreadTile.transform.position.y), Vector3.down, 1f, LayerMask.GetMask("Object"));
            RaycastHit2D hit_tile = Physics2D.Raycast(new Vector2(TreadTile.transform.position.x, TreadTile.transform.position.y), Vector3.up, 1f, LayerMask.GetMask("Tile"));
            Debug.DrawRay(TreadTile.transform.position, Vector3.down, Color.red);

            if (hit.collider != null) //플레이어의 앞에 물체가 있을 경우
            {
                playerMove[1] = false;
                //Debug.Log("아래쪽 물체감지");
                if (Input.GetKeyDown(KeyCode.R)) //R키를 눌렀을시 물체를 이동시킨다.
                {
                    hit.collider.gameObject.transform.Translate(Vector3.down);
                }
            }

            if (hit.collider == null && M_TileManager.instance.CheckTileEdge(1, hit_tile.collider.gameObject) == true)
                playerMove[1] = true;
        }
        else if (player_state == Player_State.Left || player_state == Player_State.Idle_L)
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(TreadTile.transform.position.x, TreadTile.transform.position.y), Vector3.left, 1f, LayerMask.GetMask("Object"));
            RaycastHit2D hit_tile = Physics2D.Raycast(new Vector2(TreadTile.transform.position.x, TreadTile.transform.position.y), Vector3.up, 1f, LayerMask.GetMask("Tile"));
            Debug.DrawRay(TreadTile.transform.position, Vector3.left, Color.red);

            if (hit.collider != null) //플레이어의 앞에 물체가 있을 경우
            {
                playerMove[2] = false;
                //Debug.Log("왼쪽 물체감지");
                if (Input.GetKeyDown(KeyCode.R)) //R키를 눌렀을시 물체를 이동시킨다.
                {
                    hit.collider.gameObject.transform.Translate(Vector3.left);
                }
            }

            if (hit.collider == null && M_TileManager.instance.CheckTileEdge(2, hit_tile.collider.gameObject) == true)
                playerMove[2] = true;

        }
        else if (player_state == Player_State.Right || player_state == Player_State.Idle_R)
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(TreadTile.transform.position.x, TreadTile.transform.position.y), Vector3.right, 1f, LayerMask.GetMask("Object"));
            RaycastHit2D hit_tile = Physics2D.Raycast(new Vector2(TreadTile.transform.position.x, TreadTile.transform.position.y), Vector3.up, 1f, LayerMask.GetMask("Tile"));
            Debug.DrawRay(TreadTile.transform.position, Vector3.right, Color.red);

            if (hit.collider != null) //플레이어의 앞에 물체가 있을 경우
            {
                playerMove[3] = false;
                //Debug.Log("오른쪽 물체감지");
                if (Input.GetKeyDown(KeyCode.R)) //R키를 눌렀을시 물체를 이동시킨다.
                {
                    hit.collider.gameObject.transform.Translate(Vector3.right);
                }
            }

            if (hit.collider == null && M_TileManager.instance.CheckTileEdge(3, hit_tile.collider.gameObject) == true)
                playerMove[3] = true;
        }

    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.name.Contains("Tile"))
        {
            TreadTile = coll.gameObject;
            //Debug.Log("플레이어가 밟고있는 타일" + TreadTile);

            //플레이어 맵 안에서만 이동 제한
            //근데 오브젝트 앞에서 움직임이랑 맵 안에서만 이동제한이랑 같은 변수를 다루기때문에 오류가 날수있다. 
            if(player_state == Player_State.Up || player_state == Player_State.Idle_U)
                playerMove[0] = M_TileManager.instance.CheckTileEdge(0, coll.gameObject);
            else if (player_state == Player_State.Down || player_state == Player_State.Idle_D)
                playerMove[1] = M_TileManager.instance.CheckTileEdge(1, coll.gameObject);
            else if (player_state == Player_State.Left || player_state == Player_State.Idle_L)
                playerMove[2] = M_TileManager.instance.CheckTileEdge(2, coll.gameObject);
            else if (player_state == Player_State.Right || player_state == Player_State.Idle_R)
                playerMove[3] = M_TileManager.instance.CheckTileEdge(3, coll.gameObject);
        }

        //enableMove = false;

       

        //if (coll.name.Contains("Tile")) //연산과정생략을 위한 조건문
        //{
        //    for (int y = 0; y < 15; y++)
        //    {

        //        if (coll.name == "Tile[" + y + ",0]")
        //            playerMove[2] = enableMove;
        //        if (coll.name == "Tile[" + y + ",19]")
        //            playerMove[3] = enableMove;


        //        for (int x = 0; x < 20; x++)
        //        {
        //            if (coll.name == "Tile[0," + x + "]")
        //                playerMove[0] = enableMove;
        //            if (coll.name == "Tile[14," + x + "]")
        //                playerMove[1] = enableMove;

        //            if (coll.name == "Tile[" + y + "," + x + "]")
        //                Debug.Log("Tile[" + y + "," + x + "]을 밟음");
        //        }
        //    }
        //}

    }

    

    //private void OnTriggerExit2D(Collider2D coll)
    //{
    //    enableMove = true;

    //    if (coll.name.Contains("Tile")) //연산과정생략을 위한 조건문
    //    {
    //        for (int y = 0; y < 15; y++)
    //        {
    //            if (coll.name == "Tile[" + y + ",0]")
    //                playerMove[2] = enableMove;
    //            if (coll.name == "Tile[" + y + ",19]")
    //                playerMove[3] = enableMove;


    //            for (int x = 0; x < 20; x++)
    //            {
    //                if (coll.name == "Tile[0," + x + "]")
    //                    playerMove[0] = enableMove;
    //                if (coll.name == "Tile[14," + x + "]")
    //                    playerMove[1] = enableMove;
    //            }
    //        }
    //    }
    //}








    //R키를 눌렀을 때 플레이어는 물체를 들거나 아이템 창에 넣을 수 있다. 하지만 아이템 창에 넣어 다른맵으로 이동 불가능
    //물체를 드는것을 일일이 방향별로 다 그리거나 작업해야함. 이것이 어렵다면 UI쪽에 띄워놓거나 다른방법 필요.
    //그래픽쪽에서 주는게 좋다고 생각이 들긴함. 근데 코드적으로 접근하는것도 좋은공부가 될듯.
    //공부해본 결과 한박자 늦게 오브젝트가 플레이어에게 배치되는 오류가 발생. 구현은 성공
    //그래픽쪽에서 주는게 나을듯

    //여기서는 bool값을 통해 정보 전달
    //여기서 오브젝트를 해당 위치에 배치시키고 플레이어가 움직이면 한박자 늦게 물체가 배치되고 잔상이 남게된다.


}//end class
