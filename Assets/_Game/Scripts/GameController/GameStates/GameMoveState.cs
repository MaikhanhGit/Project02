using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMoveState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;
    private State _previousState;
    private GameObject[,] _tiles;
    private GamePiece _piece;
    private GameBoard _board;
    private Vector3 _offSet = new Vector3(0, 0.2f, 0);
    
    private string _highlightTag = "HighLight";
    private bool _validMove = false;
           
    public GameMoveState(GameFSM stateMachine, GameController controller)
    {        
        _stateMachine = stateMachine;
        _controller = controller;        
    }

    public override void Enter()
    {
        base.Enter();
        // UI
        // get currently picked up gamePiece
        
        Debug.Log("Enter Move State");
        _piece = _controller.CurrentGamePiece;
        // Get tiles from Gameboard
        _tiles = _controller.GameBoard.Tiles;
        // touch input
        _controller.InputManager.TouchPressed += OnTouch;        
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Exit Move State");
        _controller.InputManager.TouchPressed -= OnTouch;
    }

   
    public override void Tick()
    {
        base.Tick();
    }

    private void OnTouch(Collider collider)
    {
        
        BoxCollider boxCollider = collider.GetComponent<BoxCollider>();
        Vector3 tileCenter = new Vector3(0,0,0);
        
        if (boxCollider != null)
        {
            tileCenter = boxCollider.center;

            if (boxCollider.tag == _highlightTag)
            {
                int x = (int)tileCenter.x;
                int y = (int)tileCenter.y;
                int z = (int)tileCenter.z;                

                int curX = (int)_piece.transform.position.x;
                int curZ = (int)_piece.transform.position.z;

                Vector3 newPosition = new Vector3(x, y, z) + _offSet;
                Vector2 currentPos = new Vector2(curX, curZ) + new Vector2 (2,2);
                Vector2 newPos = new Vector2 (x, z) + new Vector2(2, 2);

                _board = _controller.GameBoard;
                _board.RePositionPiece(_piece, currentPos, newPos);
                _piece.SetPosition(newPosition, true);                
                _controller.ClearHighlightedTiles();
                _validMove = true;
                _stateMachine.ChangeState(_stateMachine.KillCheckState);
            }
            else
                StartExit();
        }
        else
        {
            StartExit();
        }
    }

    private void StartExit()
    {       
        _piece?.PutDown();
        _controller.ClearHighlightedTiles();
        _validMove = false;
        _stateMachine.ChangeStateToPrevious();
    }
   
}
