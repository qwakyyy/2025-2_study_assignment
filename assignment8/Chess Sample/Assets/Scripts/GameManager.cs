using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 프리팹들
    public GameObject TilePrefab;
    public GameObject[] PiecePrefabs;   // King, Queen, Bishop, Knight, Rook, Pawn 순
    public GameObject EffectPrefab;

    // 오브젝트의 parent들
    private Transform TileParent;
    private Transform PieceParent;
    private Transform EffectParent;
    
    private MovementManager movementManager;
    private UIManager uiManager;
    
    public int CurrentTurn = 1; // 현재 턴 1 - 백, 2 - 흑
    public Tile[,] Tiles = new Tile[Utils.FieldWidth, Utils.FieldHeight];   // Tile들
    public Piece[,] Pieces = new Piece[Utils.FieldWidth, Utils.FieldHeight];    // Piece들

    void Awake()
    {
        TileParent = GameObject.Find("TileParent").transform;
        PieceParent = GameObject.Find("PieceParent").transform;
        EffectParent = GameObject.Find("EffectParent").transform;
        
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        movementManager = gameObject.AddComponent<MovementManager>();
        movementManager.Initialize(this, EffectPrefab, EffectParent);
        
        InitializeBoard();
    }

    void InitializeBoard()
    {
        // 8x8로 타일들을 배치
        // TilePrefab을 TileParent의 자식으로 생성하고, 배치함
        // Tiles를 채움
        // --- TODO ---
        for (int x = 0; x < Utils.FieldWidth; x++)
        {
            for (int y = 0; y < Utils.FieldHeight; y++)
            {
                GameObject tileObj = Instantiate(TilePrefab, TileParent);
                tileObj.transform.localPosition = new Vector3(x, 0, y);

                Tile tile = tileObj.GetComponent<Tile>();
                tile.Set((x, y));

                Tiles[x, y] = tile;
            }
        }
        // ------

        PlacePieces(1);
        PlacePieces(-1);
    }

    void PlacePieces(int direction)
    {
        // PlacePiece를 사용하여 Piece들을 적절한 모양으로 배치
        // --- TODO ---
        int startRow = (direction == 1) ? 0 : 7;
        int pawnRow  = (direction == 1) ? 1 : 6;

        // Rooks
        PlacePiece(4, (0, startRow), direction);
        PlacePiece(4, (7, startRow), direction);

        // Knights
        PlacePiece(3, (1, startRow), direction);
        PlacePiece(3, (6, startRow), direction);

        // Bishops
        PlacePiece(2, (2, startRow), direction);
        PlacePiece(2, (5, startRow), direction);

        // Queen
        PlacePiece(1, (3, startRow), direction);

        // King
        PlacePiece(0, (4, startRow), direction);

        // Pawns
        for (int x = 0; x < Utils.FieldWidth; x++)
        {
            PlacePiece(5, (x, pawnRow), direction);
        }
        // ------
    }

    Piece PlacePiece(int pieceType, (int, int) pos, int direction)
    {
        // Piece를 배치 후, initialize
        // PiecePrefabs의 원소를 사용하여 배치, PieceParent의 자식으로 생성
        // Pieces를 채움
        // 배치한 Piece를 리턴
        // --- TODO ---
        GameObject pieceObj = Instantiate(PiecePrefabs[pieceType], PieceParent);
        pieceObj.transform.localPosition = new Vector3(pos.Item1, 0.5f, pos.Item2);

        Piece piece = pieceObj.GetComponent<Piece>();
        piece.initialize(pos, direction);

        Pieces[pos.Item1, pos.Item2] = piece;

        return piece;
        // ------
    }

    public bool IsValidMove(Piece piece, (int, int) targetPos)
    {
        return movementManager.IsValidMove(piece, targetPos);
    }

    public void ShowPossibleMoves(Piece piece)
    {
        movementManager.ShowPossibleMoves(piece);
    }

    public void ClearEffects()
    {
        movementManager.ClearEffects();
    }


    public void Move(Piece piece, (int, int) targetPos)
    {
        if (!IsValidMove(piece, targetPos)) return;
        
        // 해당 위치에 다른 Piece가 있다면 삭제
        // Piece를 이동시킴
        // --- TODO ---
        if (!IsValidMove(piece, targetPos)) return;

        // 기존 위치 비우기
        Pieces[piece.MyPos.Item1, piece.MyPos.Item2] = null;

        // 타겟 위치에 다른 말이 있으면 제거
        if (Pieces[targetPos.Item1, targetPos.Item2] != null)
        {
            Destroy(Pieces[targetPos.Item1, targetPos.Item2].gameObject);
        }

        // 이동
        piece.MyPos = targetPos;
        piece.transform.localPosition = new Vector3(targetPos.Item1, 0.5f, targetPos.Item2);

        Pieces[targetPos.Item1, targetPos.Item2] = piece;

        ChangeTurn();
        // ------
    }
    void ChangeTurn()
    {
        // 턴을 변경하고, UI에 표시
        // --- TODO ---
        CurrentTurn = (CurrentTurn == 1) ? 2 : 1;
        uiManager.UpdateTurn(CurrentTurn);
        // ------
    }
}
