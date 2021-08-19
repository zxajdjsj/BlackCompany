using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_playermove : MonoBehaviour
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
  
    static public test_playermove instance;
    private void Awake()
    {
        instance = this;
        for(int i=0; i<playerMove.Length; i++)
        {
            playerMove[i] = true;
        }

        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //moveX = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
        //moveY = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;
        PlayerMove();
     
        //Debug.Log(player_state);      
        //Mathf.Clamp()함수를 통하여 맵의 일정범위를 나가게 되면 이동을 제한한다.
        //다 일일이 경우에 따라 상하좌우키를 끄는건 비효율적인듯.
        //정글이나 사막에서도 이 함수 쓰면 될듯 굳굳
        //transform.position = new Vector2(transform.position.x + moveX, transform.position.y + moveY);
        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3, 3), Mathf.Clamp(transform.position.y, -3, 3), 0);
        
    }

    //다른칸으로 이동하면서 애니메이션 적용 후 이동시키기
    void PlayerMove()
    {
        if(Input.GetKey(KeyCode.UpArrow))
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
                //transform.position = new Vector3(transform.position.x  ,transform.position.y +1 ,0);
                //transform.Translate(0, playerSpeed * Time.deltaTime, 0);
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
                //transform.position = new Vector3(transform.position.x, transform.position.y - 1, 0);
                //transform.Translate(0, -playerSpeed * Time.deltaTime, 0);
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
                //transform.position = new Vector3(transform.position.x - 1, transform.position.y , 0);
                //transform.Translate(-playerSpeed * Time.deltaTime, 0, 0);
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
                //transform.position = new Vector3(transform.position.x + 1, transform.position.y, 0);
                //transform.Translate(playerSpeed * Time.deltaTime, 0, 0);
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
    private void OnTriggerEnter2D(Collider2D coll)
    {
        for(int y=0; y<10; y++)
        {
            for (int x = 0; x < 18; x++) 
            {
                if(y==0) //상
                {
                    if (coll.name == "TileCollider[" + y + "," + x + "]")
                    {
                        playerMove[0] = false;
                    }
                }
                if (y == 9) //상
                {
                    if (coll.name == "TileCollider[" + y + "," + x + "]")
                    {
                        playerMove[1] = false;
                    }
                }
                if (x==0) //좌
                {
                    if (coll.name == "TileCollider[" + y + "," + x + "]")
                    {
                        playerMove[2] = false;
                    }
                }
               if(x==17) //우
                {
                    if (coll.name == "TileCollider[" + y + "," + x + "]")
                    {
                        playerMove[3] = false;
                    }
                }
            }
        }
            
    }


    private void OnTriggerExit2D(Collider2D coll)
    {
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 18; x++)
            {
                if (y == 0) //상
                {
                    if (coll.name == "TileCollider[" + y + "," + x + "]")
                    {
                        playerMove[0] = true;
                    }
                }
                if (y == 9) //상
                {
                    if (coll.name == "TileCollider[" + y + "," + x + "]")
                    {
                        playerMove[1] = true;
                    }
                }
                if (x == 0) //좌
                {
                    if (coll.name == "TileCollider[" + y + "," + x + "]")
                    {
                        playerMove[2] = true;
                    }
                }
                if (x == 17) //우
                {
                    if (coll.name == "TileCollider[" + y + "," + x + "]")
                    {
                        playerMove[3] = true;
                    }
                }
            }
        }

    }

  void ChagePlayerBeforeState()
    {
        switch(player_state)
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
}//end class
