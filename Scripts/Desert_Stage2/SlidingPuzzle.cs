using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingPuzzle : MonoBehaviour
{
    public Texture2D image;
    public int blocksPerLine = 4;
    public int shuffleLength = 20;
    public float defaultMoveDuration = .2f;
    public float shuffleMoveDuration = .1f;

    enum PuzzleState { Solved, Shuffling, InPlay};
    PuzzleState state;

    SlidingPuzzleBlock emptyBlock;
    SlidingPuzzleBlock[,] blocks;
    Queue<SlidingPuzzleBlock> inputs;
    bool blockIsMoving;
    int shuffleMovesRemaining;
    Vector2Int prevShuffleOffset;

    private void Start()
    {
        CreatePuzzle();
    }

    private void Update()
    {
        if(state == PuzzleState.Solved && Input.GetKeyDown(KeyCode.Space))
        {
            StartShuffle();
        }
    }

    void CreatePuzzle()
    {
        blocks = new SlidingPuzzleBlock[blocksPerLine, blocksPerLine];
        Texture2D[,] imageSlices = ImageSlicer.GetSlices(image, blocksPerLine);
        for(int y=0; y< blocksPerLine; y++)
        {
            for (int x = 0; x < blocksPerLine; x++)
            {
                GameObject blockObject = GameObject.CreatePrimitive(PrimitiveType.Quad); //쿼드(평면의 정사각형)오브젝트를 생성한다.
                blockObject.transform.position = -Vector2.one * (blocksPerLine - 1) * .5f + new Vector2(x,y);
                blockObject.transform.parent = transform; //이 블럭객체들을 하나의 부모오브젝트 밑에 둔다.

                SlidingPuzzleBlock block = blockObject.AddComponent<SlidingPuzzleBlock>(); //각 객체들에 스크립트 추가
                block.OnBlockPressed += PlayerMoveBlockInput; //함수를 담는듯?
                block.OnFinishedMoving += OnBlockFinishedMoving;
                block.Init(new Vector2Int(x, y), imageSlices[x, y]);
                blocks[x, y] = block;

                if(y==0 && x == blocksPerLine -1)
                {
                    emptyBlock = block;
                }
            }
        }

        Camera.main.orthographicSize = blocksPerLine * .55f; //블럭 개수에 맞게 카메라 화면크기를 조정한다.
        inputs = new Queue<SlidingPuzzleBlock>();
    }

    void PlayerMoveBlockInput(SlidingPuzzleBlock blockToMove)
    {
        if(state == PuzzleState.InPlay)
        {
            inputs.Enqueue(blockToMove);
            MakeNextPlayerMove();
        }    
    }

    void MakeNextPlayerMove()
    {
        while (inputs.Count > 0 && !blockIsMoving)
        {
            MoveBlock(inputs.Dequeue(), defaultMoveDuration);
        }
    }

    void MoveBlock(SlidingPuzzleBlock blockToMove, float duration)
    {
        //마우스로 눌린 객체의 상하좌우(근처 오브젝트)오브젝트에서만 클릭되게 한다.
        //sqrMagnitude : 두 점간의 거리의 제곱에 루트를 한 값. -> 두 점간의 거리의 차이를 2차원 함수값으로 계산한다.
        if ((blockToMove.coord - emptyBlock.coord).sqrMagnitude == 1)
        {
            blocks[blockToMove.coord.x, blockToMove.coord.y] = emptyBlock;
            blocks[emptyBlock.coord.x, emptyBlock.coord.y] = blockToMove;

            Vector2Int targetCoord = emptyBlock.coord; //swap 생각하면 될듯 
            emptyBlock.coord = blockToMove.coord; //빈공간을 담당하는 객체의 좌표를 클릭한 객체의 좌표로 설정
            blockToMove.coord = targetCoord; //클릭한 객체의 좌표를 빈공간을 담당하는 객체의 좌표로 설정

            Vector2 targetPosition = emptyBlock.transform.position;
            emptyBlock.transform.position = blockToMove.transform.position;
            blockToMove.MoveToPosition(targetPosition, duration); //블럭들을 부드럽고 느리게 이동시킨다.
            blockIsMoving = true;
        }

    }

    void OnBlockFinishedMoving()
    {
        blockIsMoving = false;
        CheckIfSolved();

        if(state == PuzzleState.InPlay)
        {
            MakeNextPlayerMove();
        }
        else if(state == PuzzleState.Shuffling)
        {
            if (shuffleMovesRemaining > 0)
            {
                MakeNextShuffleMove();
            }
            else
            {
                state = PuzzleState.InPlay;
            }
        }     
    }

    void StartShuffle()
    {
        state = PuzzleState.Shuffling;
        shuffleMovesRemaining = shuffleLength;
        emptyBlock.gameObject.SetActive(false);
        MakeNextShuffleMove();
    }

    void MakeNextShuffleMove()
    {
        Vector2Int[] offsets = { new Vector2Int(1, 0), new Vector2Int(-1, 0), new Vector2Int(0, 1), new Vector2Int(0, -1) };
        int randomIndex = Random.Range(0, offsets.Length);

        for(int i=0; i<offsets.Length; i++)
        {
            Vector2Int offset = offsets[(randomIndex+i) % offsets.Length];
            if(offset != prevShuffleOffset * -1)
            {
                Vector2Int moveBlockCoord = emptyBlock.coord + offset;
                if (moveBlockCoord.x >= 0 && moveBlockCoord.x < blocksPerLine && moveBlockCoord.y >= 0 && moveBlockCoord.y < blocksPerLine)
                {
                    MoveBlock(blocks[moveBlockCoord.x, moveBlockCoord.y], shuffleMoveDuration);
                    shuffleMovesRemaining--;
                    prevShuffleOffset = offset;
                    break;
                }
            }                
        }
       
    }

    void CheckIfSolved()
    {
        foreach(SlidingPuzzleBlock block in blocks)
        {
            if(!block.IsAtStartingCoord())
            {
                return;
            }
        }

        state = PuzzleState.Solved;
        emptyBlock.gameObject.SetActive(true);
    }
}//end class
