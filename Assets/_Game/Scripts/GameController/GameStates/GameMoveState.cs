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
    private Vector3 _offSet = new Vector3(0, 0.4f, 0);
    
    private string _highlightTag = "HighLight";
    private bool _validMove = false;
           
    public GameMoveState(GameFSM stateMachine, GameController controller, State previousState)
    {
        _stateMachine = stateMachine;
        _controller = controller;
        _previousState = previousState;       
    }

    public override void Enter()
    {
        base.Enter();
        // UI
        // get currently picked up gamePiece
        _piece = _controller.CurrentGamePiece;
        // Get tiles from Gameboard
        _tiles = _controller.GameBoard.Tiles;
        // touch input
        _controller.InputManager.TouchPressed += OnTouch;        
    }

    public override void Exit()
    {
        base.Exit();
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
                Vector3 newPosition = new Vector3(x, y, z) + _offSet;

                _piece.SetPosition(newPosition, true);                
                _piece.ResetSize();
                _controller.ClearHighlightedTiles();
                _validMove = true;
                _stateMachine.ChangeState(_stateMachine.KillCheckState);
            }
            else
            {
                _piece?.PutDown();
                _controller.ClearHighlightedTiles();
                _validMove = false;
                _stateMachine.ChangeState(_previousState);
            }
        }
    }
   
}
