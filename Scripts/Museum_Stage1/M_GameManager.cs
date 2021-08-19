using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_GameManager : MonoBehaviour
{
    public GameObject GameOverBg;

    //레이저끼리 충돌시 부딪힌 레이저들을 모두 담아놓는 저장공간
    public GameObject[] ArrayLaser_V = new GameObject[5];
    public GameObject[] ArrayLaser_H = new GameObject[5];

    public GameObject[] CollidingLaser = new GameObject[2]; //충돌한 두 레이저

    public static M_GameManager instance;
    private void Awake()
    {
        instance = this;
        GameOverBg.SetActive(false);

        //레이저 배열 초기화
        for (int i = 0; i < 5; i++)
        {
           ArrayLaser_H[i] = null;
           ArrayLaser_V[i] = null;
        }

        for (int i = 0; i < 2; i++)
        {
            CollidingLaser[i] = null;
        }
    }

    private void Update()
    {
        for (int i = 0; i < 5; i++)
        {
            Debug.Log("ArrayLaser_H_" + i + " : " + ArrayLaser_H[i]);

        }

        for (int i = 0; i < 5; i++)
        {
            Debug.Log("ArrayLaser_V_" + i + " : " + ArrayLaser_V[i]);
        }

        for (int i = 0; i < 5; i++)
        {

            //if (CollidingLaser[0] != null && CollidingLaser[1] != null) //부딪힌 레이저 2개가 전부 담겼을 때
            //{
            //    Destroy(CollidingLaser[0]);
            //    Destroy(CollidingLaser[1]);
            //    for (int a = 0; a < 5; a++) //충돌 레이저 담아놓는 변수 초기화
            //    {
            //        ArrayLaser_H[a] = null;
            //        ArrayLaser_V[a] = null;
            //    }

            //    break;
            //}

            if (ArrayLaser_V[i] != null && CollidingLaser[0] == null)
            {
                CollidingLaser[0] = ArrayLaser_V[i];
                Debug.Log("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            }

            if (ArrayLaser_H[i] != null && CollidingLaser[1] == null) // && CollidingLaser[1] == null
            {
                CollidingLaser[1] = ArrayLaser_H[i];
                Debug.Log("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            }

        }
    }

    public void ViewGameOverBg()
    {
        GameOverBg.SetActive(true);
        for(int i=0; i<4; i++)
        {
            M_PlayerManager.instance.playerMove[i] = false;
        }
      
    }
}//end class
