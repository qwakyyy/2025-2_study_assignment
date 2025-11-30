using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : Piece
{
    public override MoveInfo[] GetMoves()
    {
        // --- TODO ---
        List<MoveInfo> moves = new List<MoveInfo>();

        int maxDistance = Mathf.Max(Utils.FieldWidth, Utils.FieldHeight);

        // 직선 4방향
        moves.Add(new MoveInfo(1, 0, maxDistance));   // 오른쪽
        moves.Add(new MoveInfo(-1, 0, maxDistance));  // 왼쪽
        moves.Add(new MoveInfo(0, 1, maxDistance));   // 위
        moves.Add(new MoveInfo(0, -1, maxDistance));  // 아래

        // 대각선 4방향
        moves.Add(new MoveInfo(1, 1, maxDistance));   // 오른쪽 위
        moves.Add(new MoveInfo(1, -1, maxDistance));  // 오른쪽 아래
        moves.Add(new MoveInfo(-1, 1, maxDistance));  // 왼쪽 위
        moves.Add(new MoveInfo(-1, -1, maxDistance)); // 왼쪽 아래

        return moves.ToArray();
        // ------
    }
}