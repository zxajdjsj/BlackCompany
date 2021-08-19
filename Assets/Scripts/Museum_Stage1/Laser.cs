using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    int test = 0;
    LineRenderer lineRenderer; //배열로 만들고 그거에 따라 레이저를 배치한다.

    BoxCollider2D boxcollider2d;


    GameObject ContactedObj;

    //상하로 발사하는 레이저 위치
    Vector3[] startPos_V = new Vector3[5]; //레이저 시작위치
    Vector3[] endPos_V = new Vector3[5]; //레이저 도달위치

    //좌우로 발사하는 레이저 위치
    Vector3[] startPos_H = new Vector3[5]; //레이저 시작위치
    Vector3[] endPos_H = new Vector3[5]; //레이저 도달위치

   

  


   
    private void Awake()
    {
        

        //상하로 발사하는 레이저 초기화
        startPos_V[0] = new Vector3(-3, 6, 0); //레이저를 오브젝트에 안가리기 위해서 z값을 바꾸던지 해야함.
        startPos_V[1] = new Vector3(2, 6, 0);
        startPos_V[2] = new Vector3(-2,-9, 0);
        startPos_V[3] = new Vector3(3, -9, 0);
        startPos_V[4] = new Vector3(6, -9, 0);

        endPos_V[0] = new Vector3(-3, -9, 0);
        endPos_V[1] = new Vector3(2, -9, 0);
        endPos_V[2] = new Vector3(-2, 6, 0);
        endPos_V[3] = new Vector3(3, 6, 0);
        endPos_V[4] = new Vector3(6, 6, 0);

        //좌우로 발사하는 레이저 초기화
        startPos_H[0] = new Vector3(-10.5f, 3.5f, 0);
        startPos_H[1] = new Vector3(-10.5f, -3.5f, 0);
        startPos_H[2] = new Vector3(9.5f, 2.5f, 0);
        startPos_H[3] = new Vector3(9.5f, 0.5f, 0);
        startPos_H[4] = new Vector3(9.5f, -4.5f, 0);

        endPos_H[0] = new Vector3(9.5f, 3.5f, 0);
        endPos_H[1] = new Vector3(9.5f, -3.5f, 0);
        endPos_H[2] = new Vector3(-10.5f, 2.5f, 0);
        endPos_H[3] = new Vector3(-10.5f, 0.5f, 0);
        endPos_H[4] = new Vector3(-10.5f, -4.5f, 0);

        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = .05f;
        lineRenderer.endWidth = .05f;

        
    }

    // Start is called before the first frame update
    void Start()
    {
        boxcollider2d = GetComponent<BoxCollider2D>();
        //레이저에 충돌체크를 위해 해당 위치에 콜라이더 크기 맞추기
        for (int i = 0; i < 5; i++)
        {

            if (this.gameObject.name.Contains("Laser_V_" + (i + 1))) //박스콜라이더는 배열로 선언안하고 오브젝트의 이름순서에 따라서 박스콜라이더 위치 및 크기 변경
            {

                switch (i + 1)
                {
                    case 1:
                        boxcollider2d.transform.position = (startPos_V[i] + new Vector3(-3, 1.5f, 0)) / 2.0f;
                        boxcollider2d.size = new Vector2(0.3f, 4.5f);
                        lineRenderer.SetPosition(0, startPos_V[i]);
                        lineRenderer.SetPosition(1, new Vector3(-3, 1.5f, 0));
                        break;
                    case 2:
                        boxcollider2d.transform.position = (startPos_V[i] + new Vector3(2, 3.5f, 0)) / 2.0f;
                        boxcollider2d.size = new Vector2(0.3f, 2.5f);
                        lineRenderer.SetPosition(0, startPos_V[i]);
                        lineRenderer.SetPosition(1, new Vector3(2, 3.5f, 0));
                        break;
                    case 3:
                        boxcollider2d.transform.position = (startPos_V[i] + new Vector3(-2, -2.5f, 0)) / 2.0f;
                        boxcollider2d.size = new Vector2(0.3f, 6.5f);
                        lineRenderer.SetPosition(0, startPos_V[i]);
                        lineRenderer.SetPosition(1, new Vector3(-2, -2.5f, 0));
                        break;
                    case 4:
                        boxcollider2d.transform.position = (startPos_V[i] + new Vector3(3, -5.5f, 0)) / 2.0f;
                        boxcollider2d.size = new Vector2(0.3f, 3.5f);
                        lineRenderer.SetPosition(0, startPos_V[i]);
                        lineRenderer.SetPosition(1, new Vector3(3, -5.5f, 0));
                        break;
                    case 5:
                        boxcollider2d.transform.position = (startPos_V[i] + new Vector3(6, -5.5f, 0)) / 2.0f;
                        boxcollider2d.size = new Vector2(0.3f, 3.5f);
                        lineRenderer.SetPosition(0, startPos_V[i]);
                        lineRenderer.SetPosition(1, new Vector3(6, -5.5f, 0));
                        break;
                }

            }


            if (this.gameObject.name.Contains("Laser_H_" + (i + 1))) //박스콜라이더는 배열로 선언안하고 오브젝트의 이름순서에 따라서 박스콜라이더 위치 및 크기 변경
            {

                switch (i + 1)
                {
                    case 1:
                        boxcollider2d.transform.position = (startPos_H[i] + new Vector3(-6, 3.5f, 0)) / 2.0f;
                        boxcollider2d.size = new Vector2(4.5f, 0.3f);
                        lineRenderer.SetPosition(0, startPos_H[i]);
                        lineRenderer.SetPosition(1, new Vector3(-6, 3.5f, 0));
                        break;
                    case 2:
                        boxcollider2d.transform.position = (startPos_H[i] + new Vector3(-3, -3.5f, 0)) / 2.0f;
                        boxcollider2d.size = new Vector2(7.5f, 0.3f);
                        lineRenderer.SetPosition(0, startPos_H[i]);
                        lineRenderer.SetPosition(1, new Vector3(-3, -3.5f, 0));
                        break;
                    case 3:
                        boxcollider2d.transform.position = (startPos_H[i] + new Vector3(6, 2.5f, 0)) / 2.0f;
                        boxcollider2d.size = new Vector2(3.5f, 0.3f);
                        lineRenderer.SetPosition(0, startPos_H[i]);
                        lineRenderer.SetPosition(1, new Vector3(6, 2.5f, 0));
                        break;
                    case 4:
                        boxcollider2d.transform.position = (startPos_H[i] + new Vector3(1, 0.5f, 0)) / 2.0f;
                        boxcollider2d.size = new Vector2(8.5f, 0.3f);
                        lineRenderer.SetPosition(0, startPos_H[i]);
                        lineRenderer.SetPosition(1, new Vector3(1, 0.5f, 0));
                        break;
                    case 5:
                        boxcollider2d.transform.position = (startPos_H[i] + new Vector3(6, -4.5f, 0)) / 2.0f;
                        boxcollider2d.size = new Vector2(3.5f, 0.3f);
                        lineRenderer.SetPosition(0, startPos_H[i]);
                        lineRenderer.SetPosition(1, new Vector3(6, -4.5f, 0));
                        break;
                }

            }

        }
    }


    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.name.Contains("Laser")) //맞닿은 레이저끼리 파괴,
        {
            if (coll.name.Contains("V")) //가로가 세로에 부딪혔을 때
            {
                for (int i = 0; i < 5; i++)
                {
                    if (coll.name.Contains((i + 1).ToString()))
                    {
                        M_GameManager.instance.ArrayLaser_V[i] = coll.gameObject;

                        //Debug.Log("ArrayLaser_V_" + i + " : " + ArrayLaser_V[i]);
                    }
                }
            }

            if (coll.name.Contains("H")) //세로가 가로에 부딪혔을 때
            {

                for (int i = 0; i < 5; i++)
                {
                    if (coll.name.Contains((i + 1).ToString()))
                    {
                        M_GameManager.instance.ArrayLaser_H[i] = coll.gameObject;
                        //Debug.Log("ArrayLaser_H_" + i + " : " + coll.gameObject);

                    }
                }
            }

        }

        //if (coll.tag == "Player")
        //{
        //    M_GameManager.instance.ViewGameOverBg();
        //}

    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        
        
           

        if (coll.gameObject.layer.ToString() == "9") //레이저랑 오브젝트랑 부딪혔을 시 레이저가 투과하지 못하도록 함. 
        {
            for (int i = 0; i < 5; i++)
            {
                if (this.gameObject.name.Contains("Laser_V_" + (i + 1).ToString()))
                {
                    // Debug.Log("stay");
                    ContactedObj = coll.gameObject;
                    //Debug.Log((i+1)+"번째 레이저랑 충돌한 오브젝트 : "+coll.name);
                    boxcollider2d.transform.position = new Vector3(startPos_V[i].x, (startPos_V[i].y + ContactedObj.transform.position.y) / 2.0f, 0);
                    boxcollider2d.size = new Vector2(0.3f, CalculateDistance(startPos_V[i].y, ContactedObj.transform.position.y)); //가로일때 값


                    lineRenderer.SetPosition(0, startPos_V[i]); //레이저 출력
                    lineRenderer.SetPosition(1, new Vector3(startPos_V[i].x, ContactedObj.transform.position.y, 0));
                    break;
                }

                if (this.gameObject.name.Contains("Laser_H_" + (i + 1).ToString()))
                {
                   
                    ContactedObj = coll.gameObject;
                    //Debug.Log(ContactedObj);
                    boxcollider2d.transform.position = new Vector3((startPos_H[i].x + ContactedObj.transform.position.x) / 2.0f, startPos_H[i].y, 0);
                    boxcollider2d.size = new Vector2(CalculateDistance(startPos_H[i].x, ContactedObj.transform.position.x), 0.3f); //가로일때 값


                    lineRenderer.SetPosition(0, startPos_H[i]); //레이저 출력
                    lineRenderer.SetPosition(1, new Vector3(ContactedObj.transform.position.x, startPos_H[i].y, 0));
                    test++;
                    break;
                }




            }
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.layer.ToString() == "9") //레이저랑 오브젝트랑 부딪혔을 시 레이저가 투과하지 못하도록 함. 
        {
            for (int i = 0; i < 5; i++)
            {
                if (this.gameObject.name.Contains("Laser_V_" + (i + 1).ToString())) //상하
                {
                    // Debug.Log("exit");

                    boxcollider2d.transform.position = new Vector3(startPos_V[i].x, (startPos_V[i].y + endPos_V[i].y) / 2.0f, 0);
                    boxcollider2d.size = new Vector2(0.3f, 15); //가로일때 값


                    lineRenderer.SetPosition(0, startPos_V[i]); //레이저 출력
                    lineRenderer.SetPosition(1, endPos_V[i]);
                    break;
                }

                if (this.gameObject.name.Contains("Laser_H_" + (i + 1).ToString())) //좌우
                {
                    //Debug.Log("exit");

                    boxcollider2d.transform.position = new Vector3((startPos_H[i].x + endPos_H[i].x) / 2.0f, startPos_H[i].y, 0);
                    boxcollider2d.size = new Vector2(20, 0.3f); //가로일때 값


                    lineRenderer.SetPosition(0, startPos_H[i]); //레이저 출력
                    lineRenderer.SetPosition(1, endPos_H[i]);
                    break;
                }


            }
        }
    }

    float CalculateDistance(float A, float B) 
    {
        float result = 0;
        result = Mathf.Abs(A - B);
        return result;
    }


}//end class
