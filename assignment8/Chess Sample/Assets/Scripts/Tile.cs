using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public (int, int) MyPos;    // Tile의 좌표
    Color tileColor = new Color(255 / 255f, 193 / 255f, 204 / 255f);    // 색깔
    SpriteRenderer MySpriteRenderer;

    private void Awake()
    {
        MySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // 타일을 처음에 배치하는 함수
    public void Set((int, int) targetPos)
    {
        // MyPos를 targetPos로 지정함
        // 위치를 targetPos 이동시키고, 배치에 따라 색깔을 지정
        // --- TODO ---
        MyPos = targetPos;

        // 위치 이동 (보드 좌표 → Unity 좌표)
        transform.localPosition = new Vector3(
            targetPos.Item1 * Utils.TileSize,
            0,
            targetPos.Item2 * Utils.TileSize
        );

        // 색깔 지정 (체스판 패턴)
        if ((targetPos.Item1 + targetPos.Item2) % 2 == 0)
        {
            MySpriteRenderer.color = tileColor; // 분홍빛 칸
        }
        else
        {
            MySpriteRenderer.color = Color.white; // 흰 칸
        }
        // ------
    }
}
