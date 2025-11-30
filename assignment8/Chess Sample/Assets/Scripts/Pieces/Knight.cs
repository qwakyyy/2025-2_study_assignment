using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Knight.cs
public class Knight : Piece
{
    public override MoveInfo[] GetMoves()
    {
        // --- TODO ---
        List<MoveInfo> moves = new List<MoveInfo>();

        // 8가지 L자 이동
        moves.Add(new MoveInfo(2, 1, 1));
        moves.Add(new MoveInfo(2, -1, 1));
        moves.Add(new MoveInfo(-2, 1, 1));
        moves.Add(new MoveInfo(-2, -1, 1));

        moves.Add(new MoveInfo(1, 2, 1));
        moves.Add(new MoveInfo(1, -2, 1));
        moves.Add(new MoveInfo(-1, 2, 1));
        moves.Add(new MoveInfo(-1, -2, 1));

        return moves.ToArray();
        // ------
    }
}