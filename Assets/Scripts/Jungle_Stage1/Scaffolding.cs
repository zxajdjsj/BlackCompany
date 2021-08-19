using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaffolding : MonoBehaviour
{
    //발판 9개
    public SpriteRenderer Scaffolding_1;
    public SpriteRenderer Scaffolding_2;
    public SpriteRenderer Scaffolding_3;
    public SpriteRenderer Scaffolding_4;
    public SpriteRenderer Scaffolding_5;
    public SpriteRenderer Scaffolding_6;
    public SpriteRenderer Scaffolding_7;
    public SpriteRenderer Scaffolding_8;
    public SpriteRenderer Scaffolding_9;

    //문양 9개
    public SpriteRenderer Ancient_Pattern_1;
    public SpriteRenderer Ancient_Pattern_2;
    public SpriteRenderer Ancient_Pattern_3;
    public SpriteRenderer Ancient_Pattern_4;
    public SpriteRenderer Ancient_Pattern_5;
    public SpriteRenderer Ancient_Pattern_6;
    public SpriteRenderer Ancient_Pattern_7;
    public SpriteRenderer Ancient_Pattern_8;
    public SpriteRenderer Ancient_Pattern_9;

    // 켜지고 꺼지는 문양의 모습 스프라이트
    public Sprite On_Ancient_Pattern;
    public Sprite Off_Ancient_Pattern;

    //리셋 발판
    public SpriteRenderer Reset_Scaffolding;

    //발판의 불이 켜졌는지 꺼졌는지 관련 변수
    public bool[] scaffolding = new bool[9];

    //스테이지 1 해결인지 아닌지 확인하는 변수
    public bool jungle_stage_1 = false;

    //발판을 밟았을 때의 발판 모양
    public GameObject Tread_Scaffolding;
    //발판을 안밟았을 때의 발판 모양
    public Sprite Default_Scaffolding;

    static public Scaffolding instance;

    private void Awake()
    {
        instance = this;

        //배열 초기화
        for(int i=0; i<9; i++)
        {
            scaffolding[i] = false;
           
        }

        Tread_Scaffolding.SetActive(false);
    
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!jungle_stage_1)
        {
            Change_Scaffolding_Color();
        }    
    }

    void Change_Scaffolding_Color()
    {
        bool[] odd = new bool[4]; //발판 배열의 인덱스값인 1,3,5,7 이 true일 경우 for문에서 확인하기 위한 배열
        bool[] even = new bool[5]; //발판 배열의 인덱스값인 0,2,4,6,8이 false일 경우 for문에서 확인하기 위한 배열

        //각각의 짝수와 홀수의 배열값들을 발판배열의 값과 동일하게 초기화
        for(int i=0; i<4; i++)
        {
            odd[i] = scaffolding[(i*2)+1];
        }

        for(int i=0; i<5; i++)
        {
            even[i] = scaffolding[i * 2]; 
        }

   
        //특정 발판들을 밟았을 시 성공 -> 문양 색깔 바꾸기
        //2,4,6,8발판을 밟았을시 ->발판의 배열의 인덱스 값 = 1,3,5,7
        for (int i = 0; i < 5; i++)
        {
            if(even[i] ==true)
            {
                break;
            }
            if(i==4)
            {
                for(int a=0; a<4; a++)
                {
                    if(odd[a] ==false)
                    {
                        break;
                    }

                    if (a == 3)
                    {
                        Debug.Log("특정 무늬가 완성되었습니다.");
                        Ancient_Pattern_2.gameObject.GetComponent<SpriteRenderer>().sprite = On_Ancient_Pattern;
                        Ancient_Pattern_4.gameObject.GetComponent<SpriteRenderer>().sprite = On_Ancient_Pattern;
                        Ancient_Pattern_6.gameObject.GetComponent<SpriteRenderer>().sprite = On_Ancient_Pattern;
                        Ancient_Pattern_8.gameObject.GetComponent<SpriteRenderer>().sprite = On_Ancient_Pattern;


                        Ancient_Pattern_2.color = new Color(1, 0.92f, 0.016f, 1);
                        Ancient_Pattern_4.color = new Color(1, 0.92f, 0.016f, 1);
                        Ancient_Pattern_6.color = new Color(1, 0.92f, 0.016f, 1);
                        Ancient_Pattern_8.color = new Color(1, 0.92f, 0.016f, 1);
                      

                        jungle_stage_1 = true;
                    }
                }
            }

        }
    }

    public void Reset_Scaffolding_State()
    {
        //원래 발판 모양 되돌려놓기
        Scaffolding_1.gameObject.GetComponent<SpriteRenderer>().sprite = Default_Scaffolding;
        Scaffolding_2.gameObject.GetComponent<SpriteRenderer>().sprite = Default_Scaffolding;
        Scaffolding_3.gameObject.GetComponent<SpriteRenderer>().sprite = Default_Scaffolding;
        Scaffolding_4.gameObject.GetComponent<SpriteRenderer>().sprite = Default_Scaffolding;
        Scaffolding_5.gameObject.GetComponent<SpriteRenderer>().sprite = Default_Scaffolding;
        Scaffolding_6.gameObject.GetComponent<SpriteRenderer>().sprite = Default_Scaffolding;
        Scaffolding_7.gameObject.GetComponent<SpriteRenderer>().sprite = Default_Scaffolding;
        Scaffolding_8.gameObject.GetComponent<SpriteRenderer>().sprite = Default_Scaffolding;
        Scaffolding_9.gameObject.GetComponent<SpriteRenderer>().sprite = Default_Scaffolding;
       
        //모든 발판의 상태값 false
        for (int i=0; i<9; i++)
        { 
            Scaffolding.instance.scaffolding[i] = false;
            Off_Scaffolding(i);
        }

    }

 
    public void On_Scaffolding(int input) //문양을 키는 함수
    {
        switch(input)
        {
            case 0:
                Ancient_Pattern_1.gameObject.GetComponent<SpriteRenderer>().sprite = On_Ancient_Pattern;
                break;
            case 1:
                Ancient_Pattern_2.gameObject.GetComponent<SpriteRenderer>().sprite = On_Ancient_Pattern;
                break;
            case 2:
                Ancient_Pattern_3.gameObject.GetComponent<SpriteRenderer>().sprite = On_Ancient_Pattern;
                break;
            case 3:
                Ancient_Pattern_4.gameObject.GetComponent<SpriteRenderer>().sprite = On_Ancient_Pattern;
                break;
            case 4:
                Ancient_Pattern_5.gameObject.GetComponent<SpriteRenderer>().sprite = On_Ancient_Pattern;
                break;
            case 5:
                Ancient_Pattern_6.gameObject.GetComponent<SpriteRenderer>().sprite = On_Ancient_Pattern;
                break;
            case 6:
                Ancient_Pattern_7.gameObject.GetComponent<SpriteRenderer>().sprite = On_Ancient_Pattern;
                break;
            case 7:
                Ancient_Pattern_8.gameObject.GetComponent<SpriteRenderer>().sprite = On_Ancient_Pattern;
                break;
            case 8:
                Ancient_Pattern_9.gameObject.GetComponent<SpriteRenderer>().sprite = On_Ancient_Pattern;
                break;
        }
    }

    public void Off_Scaffolding(int input) //문양을 끄는 함수
    {
        switch (input)
        {
            case 0:
                Ancient_Pattern_1.gameObject.GetComponent<SpriteRenderer>().sprite = Off_Ancient_Pattern;
                break;
            case 1:
                Ancient_Pattern_2.gameObject.GetComponent<SpriteRenderer>().sprite = Off_Ancient_Pattern;
                break;
            case 2:
                Ancient_Pattern_3.gameObject.GetComponent<SpriteRenderer>().sprite = Off_Ancient_Pattern;
                break;
            case 3:
                Ancient_Pattern_4.gameObject.GetComponent<SpriteRenderer>().sprite = Off_Ancient_Pattern;
                break;
            case 4:
                Ancient_Pattern_5.gameObject.GetComponent<SpriteRenderer>().sprite = Off_Ancient_Pattern;
                break;
            case 5:
                Ancient_Pattern_6.gameObject.GetComponent<SpriteRenderer>().sprite = Off_Ancient_Pattern;
                break;
            case 6:
                Ancient_Pattern_7.gameObject.GetComponent<SpriteRenderer>().sprite = Off_Ancient_Pattern;
                break;
            case 7:
                Ancient_Pattern_8.gameObject.GetComponent<SpriteRenderer>().sprite = Off_Ancient_Pattern;
                break;
            case 8:
                Ancient_Pattern_9.gameObject.GetComponent<SpriteRenderer>().sprite = Off_Ancient_Pattern;
                break;
        }
    }

    public void TreadEffect_Delete_Postpone()
    {
        Invoke("TreadEffect_Delete", 0.5f);
    }

    public void TreadEffect_Delete()
    {
        Tread_Scaffolding.SetActive(false);
        
    }
}//end class
