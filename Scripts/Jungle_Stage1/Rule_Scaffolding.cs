using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rule_Scaffolding : MonoBehaviour
{
    public Canvas Hint_Canvas;

    //발판 규칙 오브젝트
    public GameObject Scaffolding_1379;
    public GameObject Scaffolding_2468;
    public GameObject Scaffolding_5;

    int i = 1;

    static public Rule_Scaffolding instance;
    private void Awake()
    {
        instance = this;
        Hint_Canvas.gameObject.SetActive(false);    
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
       
    }

    void Rotate_Rule_Scaffolding()
    {
        //Scaffolding_1357.transform.position = new Vector3(Scaffolding_1357.transform.position.x + 1f, 0, 0);
        //시계방향대로 90도씩 회전을 원한다면 rotation의 z값을 270, 180, 90,0순으로 돌려야함.
        Scaffolding_1379.transform.rotation = Quaternion.Euler(0, 0, (90 * (4 - i)));
        Scaffolding_2468.transform.rotation = Quaternion.Euler(0, 0, (90 * (4 - i)));
        i++;
        if (i == 5)
        {
            i = 1;
        }
    }

    public void Invoke_Repeating_Rotate_Rule_Scaffolding()
    {
        InvokeRepeating("Rotate_Rule_Scaffolding", 2f, 3f);
    }

    public void Cancle_Hint_UI()
    {
        Hint_Canvas.gameObject.SetActive(false);
        Player.instance.enable_moveplayer = true;
    }

    
}//end class



