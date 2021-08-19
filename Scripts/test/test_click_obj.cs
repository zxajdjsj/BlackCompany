using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_click_obj : MonoBehaviour
{
    //오브젝트 근처에 마우스가 갈 시 이펙트효과 관련 변수
    public Transform[] Obj = new Transform[5];


    Vector3[] Obj_V3 = new Vector3[5];

    //오브젝트 클릭관련 변수
    GameObject target =null ;
    Vector2 pos;
    RaycastHit2D hit;

    GameObject tmp_target = null;


    bool enable = false;

    //GameObject before_target = null;

    //오브젝트에 마우스가 갈시(클릭 x)선택 되는 것같은 효과 테두리 띄우기
    public GameObject PressedEffect;

    private void Awake()
    {
        for(int i=0; i<5; i++)
        {
            Obj_V3[i] = Obj[i].transform.localScale; //각 오브젝트의 크기를 담는다.
        }
    }

    // Update is called once per frame
    void Update()
    {
        click_obj();
        if (enable == true)
        {
            target_move();
        }
    }

  

    //이전에 target을 다른곳에 저장해놓고 이전 타겟과 현재 클릭되어있는 타겟이 다를때만 블럭 움직이도록 하면 될듯.
    void click_obj()
    {

        //Vector2.zero
        //레이캐스트 사용할때 모든 물체가 Collider를 가지고 있어야함.
        //Collider가 없는 물체를 클릭했을 경우
        //NullReferenceException: Object reference not set to an instance of an object 라고 오류가 난다.
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
        if (hit.collider != null)
        {
            Debug.Log("tmp 타겟이름 : " + hit.collider.name);
            //PressedEffect.transform.position = hit.transform.position;
            //PressedEffect.transform.localScale = hit.transform.localScale *1.1f; ->오브젝트의 크기에 맞게 효과를 설정할수있다.
            tmp_target = hit.collider.gameObject;
            hit.collider.gameObject.GetComponent<SpriteRenderer>().color = new Color(255,255,0,120); //마우스에 맞닿은 물체 색깔 변경
            //오류내용: 마우스의 움직임이 너무 빨라서 물체에서 물체로 마우스가 이동할때 물체에서 잠깐 벗어난 것을 인지못하고 색깔이 원래대로 안돌아옴.
            //불완전하기 때문에 오브젝트 마우스 클릭시 이펙트나 색깔 바꾸고, 다른 타겟으로 이동하면 그때 원래 색으로 복원 하기로 해야할듯 

            //각각의 블럭 크기에 맞추어 프리팹한 이펙트의 크기를 조절할수있게 해보기
        }
        else
        {
            Debug.Log("tmp타겟에서 벗어남");
            if(tmp_target != null)
            {
                tmp_target.GetComponent<SpriteRenderer>().color = new Color(220, 210, 210, 255);
                tmp_target = null;
            }
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            //target = null;
          
            if (hit.collider != null)
            {
                //Debug.Log(hit.collider.name);
                target = hit.collider.gameObject;               
                Debug.Log("타겟이름 : " + target.name);
                enable = true;
            }
        }
        
    }

    void target_move()
    {     
        if(hit.collider != null)
        {
            switch(target.name)
            {
                case "0":
                    target_key(); 
                    break;
                case "1":
                    target_key();
                    break;
                case "2":
                    target_key();
                    break;
                case "3":
                    target_key();
                    break;
                case "4":
                    target_key();
                    break;
            }
        }
    }

    void target_key()
    {
        if (Input.GetKeyUp(KeyCode.D))
        {
            Debug.Log("D");
            target.transform.position = new Vector2(target.transform.position.x + 0.5f, target.transform.position.y);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            Debug.Log("A");

            target.transform.position = new Vector2(target.transform.position.x - 0.5f, target.transform.position.y);
        }
    }

}//end class
