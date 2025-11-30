using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// King.cs
public class King : Piece
{
    public override MoveInfo[] GetMoves()
    {
        // --- TODO ---
        List<MoveInfo> moves = new List<MoveInfo>();

        // 8방향 한 칸씩
        moves.Add(new MoveInfo(1, 0, 1));   // 오른쪽
        moves.Add(new MoveInfo(-1, 0, 1));  // 왼쪽
        moves.Add(new MoveInfo(0, 1, 1));   // 위
        moves.Add(new MoveInfo(0, -1, 1));  // 아래
        moves.Add(new MoveInfo(1, 1, 1));   // 오른쪽 위 대각선
        moves.Add(new MoveInfo(1, -1, 1));  // 오른쪽 아래 대각선
        moves.Add(new MoveInfo(-1, 1, 1));  // 왼쪽 위 대각선
        moves.Add(new MoveInfo(-1, -1, 1)); // 왼쪽 아래 대각선

        return moves.ToArray();
        // ------
    }
}
