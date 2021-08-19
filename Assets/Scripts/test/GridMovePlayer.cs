using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovePlayer : MonoBehaviour
{
    //일정간격으로 이동하기 관련 변수
    bool isMoving;
    Vector3 origPos, targetPos;
    float timeToMove = 0.2f;
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && !isMoving)
            StartCoroutine(GridMovePlayer_routine(Vector3.up));

        if (Input.GetKey(KeyCode.DownArrow) && !isMoving)
            StartCoroutine(GridMovePlayer_routine(Vector3.down));

        if (Input.GetKey(KeyCode.LeftArrow) && !isMoving)
            StartCoroutine(GridMovePlayer_routine(Vector3.left));

        if (Input.GetKey(KeyCode.RightArrow) && !isMoving)
            StartCoroutine(GridMovePlayer_routine(Vector3.right));
    }

    IEnumerator GridMovePlayer_routine(Vector3 direction)
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
