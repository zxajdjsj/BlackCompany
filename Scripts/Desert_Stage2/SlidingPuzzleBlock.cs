using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingPuzzleBlock : MonoBehaviour
{
    public event System.Action<SlidingPuzzleBlock> OnBlockPressed;
    public event System.Action OnFinishedMoving;

    public Vector2Int coord;
    Vector2Int startingCoord;

    public void Init(Vector2Int startingCoord,Texture2D image)
    {
        this.startingCoord = startingCoord;
        coord = startingCoord;

        GetComponent<MeshRenderer>().material = Resources.Load<Material>("Block"); //조명효과를 꺼줌. 이게 없으면 어둡다.
        GetComponent<MeshRenderer>().material.mainTexture = image;
    }

    public void MoveToPosition(Vector2 target, float duration)
    {
        StartCoroutine(AnimateMove(target, duration));
    }

    private void OnMouseDown()
    {
        if(OnBlockPressed != null)
        {
            OnBlockPressed(this); //마우스로 클릭된 객체 설정
        }
    }

    IEnumerator AnimateMove(Vector2 target, float duration)
    {
        Vector2 initialPos = transform.position;
        float percent = 0;

        while(percent <1)
        {
            percent += Time.deltaTime / duration;
            transform.position = Vector2.Lerp(initialPos, target, percent); //Lerp: 선형보간
            //시작위치와 종료위치를 기준으로 보간위치를 계산한다.
            //오브젝트를 부드럽게 이동시키거나 회전할 시 사용한다.
            yield return null;
        }

        if(OnFinishedMoving != null)
        {
            OnFinishedMoving();
        }
    }

    public bool IsAtStartingCoord()
    {
        return coord == startingCoord;
    }

}//end class
