using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Piece
{
    public override MoveInfo[] GetMoves()
    {
        // --- TODO ---
            List<MoveInfo> moves = new List<MoveInfo>();

        // 대각선 네 방향
        moves.Add(new MoveInfo(1, 1, Mathf.Max(Utils.FieldWidth, Utils.FieldHeight)));
        moves.Add(new MoveInfo(1, -1, Mathf.Max(Utils.FieldWidth, Utils.FieldHeight)));
        moves.Add(new MoveInfo(-1, 1, Mathf.Max(Utils.FieldWidth, Utils.FieldHeight)));
        moves.Add(new MoveInfo(-1, -1, Mathf.Max(Utils.FieldWidth, Utils.FieldHeight)));

        return moves.ToArray();
        // ------
    }
}