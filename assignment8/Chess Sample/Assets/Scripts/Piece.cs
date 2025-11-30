using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Piece : MonoBehaviour
{
    public (int, int) MyPos;    // 자신의 좌표
    public int PlayerDirection = 1; // 자신의 방향 1 - 백, 2 - 흑
    
    public Sprite WhiteSprite;  // 백일 때의 sprite
    public Sprite BlackSprite;  // 흑일 때의 sprite
    
    protected GameManager MyGameManager;
    protected SpriteRenderer MySpriteRenderer;

    void Awake()
    {
        MyGameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        MySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Piece의 초기 설정 함수
    public void initialize((int, int) targetPos, int direction)
    {
        PlayerDirection = direction;
        initSprite(PlayerDirection);
        MoveTo(targetPos);
    }

    // sprite 초기 설정 함수
    void initSprite(int direction)
    {
        // direction에 따라 sprite를 결정하고, 방향을 결정함
        // --- TODO ---
        if (direction == 1) // 백
        {
            MySpriteRenderer.sprite = WhiteSprite;
            MySpriteRenderer.flipY = false; // 필요하다면 방향 설정
        }
        else if (direction == -1) // 흑
        {
            MySpriteRenderer.sprite = BlackSprite;
            MySpriteRenderer.flipY = true; // 필요하다면 반전
        }
        // ------
    }

    // piece의 실제 이동 함수
    public void MoveTo((int, int) targetPos)
    {
        // MyPos를 업데이트하고, targetPos로 이동
        // MyGameManager.Pieces를 업데이트
        // --- TODO ---
        if (Utils.IsInBoard(MyPos))
        {
            MyGameManager.Pieces[MyPos.Item1, MyPos.Item2] = null;
        }

        // 새 위치 기록
        MyPos = targetPos;

        // GameManager의 Pieces 배열 갱신
        MyGameManager.Pieces[targetPos.Item1, targetPos.Item2] = this;

        // 실제 위치 이동 (Unity 좌표)
        transform.localPosition = new Vector3(targetPos.Item1, 0.5f, targetPos.Item2);
        // ------
    }
    public abstract MoveInfo[] GetMoves();
}
