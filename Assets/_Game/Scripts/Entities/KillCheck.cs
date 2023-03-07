using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCheck : MonoBehaviour
{
    [SerializeField] private float _destroyDelay = 0;
    private int _tileCount = 4;    
    private int _offSetZ = 2;
    private int _killCount = 0;
    private bool _somethingKilled = false;
    private int _myTeam;
    private int CurrentX;
    private int CurrentZ;

    private void Start()
    {
        _myTeam = GetComponent<GamePiece>().Team;        
    }

    public int CheckForKills(GamePiece[,] board)
    {
        _killCount = 0;

        CurrentX = (int)transform.position.x;
        CurrentZ = (int)transform.position.z;
        int pieceCurrentX = CurrentX + 2;
        int pieceCurrentZ = CurrentZ + 2;
        
        // Up
        if ((pieceCurrentZ + 2) <= _tileCount)
        {
            GamePiece p1 = board[pieceCurrentX, pieceCurrentZ + 1];
            GamePiece p2 = board[pieceCurrentX, pieceCurrentZ + 2];

            _somethingKilled = KillOne(p1, p2, _myTeam);
            if(_somethingKilled == true)
            {
                _killCount++;
            }
        }

        //Down
        if((pieceCurrentZ - 2) >= 0)
        {
            GamePiece p1 = board[pieceCurrentX, pieceCurrentZ - 1];
            GamePiece p2 = board[pieceCurrentX, pieceCurrentZ - 2];

            _somethingKilled = KillOne(p1, p2, _myTeam);
            if(_somethingKilled == true)
            {
                _killCount++;
            }
        }

        //Right
        if((pieceCurrentX + 2) <= _tileCount)
        {
            GamePiece p1 = board[pieceCurrentX + 1, pieceCurrentZ];
            GamePiece p2 = board[pieceCurrentX + 2, pieceCurrentZ];

            _somethingKilled = KillOne(p1, p2, _myTeam);
            if(_somethingKilled == true)
            {
                _killCount++;
            }
        }

        //Left
        if((pieceCurrentX - 2) >= 0)
        {
            GamePiece p1 = board[pieceCurrentX - 1, pieceCurrentZ];
            GamePiece p2 = board[pieceCurrentX - 2, pieceCurrentZ];

            _somethingKilled = KillOne(p1, p2, _myTeam);
            if(_somethingKilled == true)
            {
                _killCount++;
            }
        }

        // Top Right
        if((pieceCurrentX + 2) <= _tileCount && (pieceCurrentZ + 2) <= _tileCount)
        {
            GamePiece p1 = board[pieceCurrentX + 1, pieceCurrentZ + 1];
            GamePiece p2 = board[pieceCurrentX + 2, pieceCurrentZ + 2];

            _somethingKilled = KillOne(p1, p2, _myTeam);
            if(_somethingKilled == true)
            {
                _killCount++;
            }            
        }

        // Bottom Right
        if((pieceCurrentX + 2) <= _tileCount && (pieceCurrentZ -2) >= 0)
        {
            GamePiece p1 = board[pieceCurrentX + 1, pieceCurrentZ - 1];
            GamePiece p2 = board[pieceCurrentX + 2, pieceCurrentZ - 2];

            _somethingKilled = KillOne(p1, p2, _myTeam);
            if(_somethingKilled == true)
            {
                _killCount++;
            }
        }

        // Top Left
        if((pieceCurrentX - 2) >= 0 && (pieceCurrentZ + 2) <= _tileCount)
        {
            GamePiece p1 = board[pieceCurrentX - 1, pieceCurrentZ + 1];
            GamePiece p2 = board[pieceCurrentX - 2, pieceCurrentZ + 2];

            _somethingKilled = KillOne(p1, p2, _myTeam);
            if(_somethingKilled == true)
            {
                _killCount++;
            }
        }

        //Bottom Left
        if((pieceCurrentX - 2) >= 0 && (pieceCurrentZ - 2) >= 0)
        {
            GamePiece p1 = board[pieceCurrentX - 1, pieceCurrentZ - 1];
            GamePiece p2 = board[pieceCurrentX - 2, pieceCurrentZ - 2];

            _somethingKilled = KillOne(p1, p2, _myTeam);
            if(_somethingKilled == true)
            {
                _killCount++;
            }
        }

        // Up & Down
        if((pieceCurrentZ + 1) <= _tileCount && (pieceCurrentZ - 1) >= 0)
        {
            GamePiece p1 = board[pieceCurrentX, pieceCurrentZ + 1];
            GamePiece p2 = board[pieceCurrentX, pieceCurrentZ - 1];

            _somethingKilled = KillTwo(p1, p2, _myTeam);
            if(_somethingKilled == true)
            {
                _killCount += 2;
            }
        }        

        // Up & Down repeated kill count Fix
        if((pieceCurrentZ + 1) <= _tileCount && (pieceCurrentZ - 1) >= 0)
        {
            GamePiece p1 = board[pieceCurrentX, pieceCurrentZ + 1];
            GamePiece p2 = board[pieceCurrentZ, pieceCurrentZ - 1];

            // top 2 down 1
            if((pieceCurrentZ + 2) <= _tileCount)
            {
                GamePiece p3 = board[pieceCurrentX, pieceCurrentZ + 2];

                _somethingKilled = KillOnlyOne(p1, p2, p3, _myTeam);
                if(_somethingKilled == true)
                {
                    // kill 2 minus 1 double counted
                    _killCount -= 1;
                }
            }
            // top 1 down 2
            if((pieceCurrentZ - 2) >= 0)
            {
                GamePiece p3 = board[pieceCurrentX, pieceCurrentZ - 2];

                _somethingKilled = KillOnlyOne(p1, p2, p3, _myTeam);
                if(_somethingKilled == true)
                {
                    // kill 2 minus 1 double counted
                    _killCount -= 1;
                }
            }
            // top 2 down 2
            if((pieceCurrentZ + 2) <= _tileCount && (pieceCurrentZ - 2) >= 0)
            {
                GamePiece p3 = board[pieceCurrentX, pieceCurrentZ + 2];
                GamePiece p4 = board[pieceCurrentX, pieceCurrentZ - 2];

                _somethingKilled = KillNone(p1, p2, p3, p4, _myTeam);
                if(_somethingKilled == true)
                {
                    // kill 2 minus 2 double counted
                    _killCount -= 2;
                }
            }            
        }
        //sides
        if ((pieceCurrentX + 1) <= _tileCount && (pieceCurrentX - 1) >= 0)
        {
            GamePiece p1 = board[pieceCurrentX + 1, pieceCurrentZ];
            GamePiece p2 = board[pieceCurrentX - 1, pieceCurrentZ];

            _somethingKilled = KillTwo(p1, p2, _myTeam);
            if (_somethingKilled == true)
            {
                _killCount += 2;
            }
        }
        // sides repeated kill count fix
        if ((pieceCurrentX + 1) <= _tileCount && (pieceCurrentX - 1) >= 0)
        {
            GamePiece p1 = board[pieceCurrentX + 1, pieceCurrentZ];
            GamePiece p2 = board[pieceCurrentX - 1, pieceCurrentZ];
            // right 2 left 1
            if((pieceCurrentX + 2) <= _tileCount)
            {
                GamePiece p3 = board[pieceCurrentX + 2, pieceCurrentZ];

                _somethingKilled = KillOnlyOne(p1, p2, p3, _myTeam);
                if(_somethingKilled == true)
                {
                    // kill 2 minus 1 double counted
                    _killCount -= 1;
                }                
            }
            // right 1 left 2
            if ((pieceCurrentX - 2) >= 0)
            {
                GamePiece p3 = board[pieceCurrentX - 2, pieceCurrentZ];

                _somethingKilled = KillOnlyOne(p1, p2, p3, _myTeam);
                if(_somethingKilled == true)
                {
                    // kill 2 minus 1 double counted
                    _killCount -= 1;
                }
            }
            // right 2  left 2
            if((pieceCurrentX + 2) <= _tileCount && (pieceCurrentX - 2) >= 0)
            {
                GamePiece p3 = board[pieceCurrentX + 2, pieceCurrentZ];
                GamePiece p4 = board[pieceCurrentX - 2, pieceCurrentZ];

                _somethingKilled = KillNone(p1, p2, p3, p4, _myTeam);
                if(_somethingKilled == true)
                {
                    // kill 2 minus 2 double counted
                    _killCount -= 2;
                }
            }
        }
        

        //right diagonal
        if((pieceCurrentX + 1) <= _tileCount && (pieceCurrentX - 1) >= 0
            && (pieceCurrentZ + 1) <= _tileCount && (pieceCurrentZ - 1 >= 0))
        {
            GamePiece p1 = board[pieceCurrentX + 1, pieceCurrentZ + 1];
            GamePiece p2 = board[pieceCurrentX - 1, pieceCurrentZ - 1];

            _somethingKilled = KillTwo(p1, p2, _myTeam);
            if(_somethingKilled == true)
            {
                _killCount += 2;
            }
        }

        // right diagonal repeated kill count fix
        if((pieceCurrentX + 1) <= _tileCount && (pieceCurrentX - 1) >= 0 &&
            (pieceCurrentZ + 1) <= _tileCount && (pieceCurrentZ - 1) >= 0)
        {
            GamePiece p1 = board[pieceCurrentX + 1, pieceCurrentZ + 1];
            GamePiece p2 = board[pieceCurrentX - 1, pieceCurrentZ - 1];
            //top 2 down 1
            if((pieceCurrentX + 2) <= _tileCount && (pieceCurrentZ + 2) <= _tileCount)
            {
                GamePiece p3 = board[pieceCurrentX + 2, pieceCurrentZ + 2];

                _somethingKilled = KillOnlyOne(p1, p2, p3, _myTeam);
                if(_somethingKilled == true)
                {
                    _killCount -= 1;
                }
            }
            // top 1 down 2
            if((pieceCurrentX - 2) >= 0 && (pieceCurrentZ - 2) >= 0)
            {
                GamePiece p3 = board[pieceCurrentX - 2, pieceCurrentZ - 2];

                _somethingKilled = KillOnlyOne(p1, p2, p3, _myTeam);
                if(_somethingKilled == true)
                {
                    _killCount -= 1;
                }
            }
            // top 2 down 2
            if((pieceCurrentX + 2) <= _tileCount && (pieceCurrentZ + 2) <= _tileCount &&
                (pieceCurrentX - 2) >= 0 && (pieceCurrentZ - 2) >= 0)
            {
                GamePiece p3 = board[pieceCurrentX + 2, pieceCurrentZ + 2];
                GamePiece p4 = board[pieceCurrentX - 2, pieceCurrentZ - 2];

                _somethingKilled = KillNone(p1, p2, p3, p4, _myTeam);
                if(_somethingKilled == true)
                {
                    _killCount -= 2;
                }
            }            
        }
        // left diagonal
        if ((pieceCurrentX + 1) <= _tileCount && (pieceCurrentX - 1) >= 0 &&
                (pieceCurrentZ + 1) <= _tileCount && (pieceCurrentZ - 1) >= 0)
        {
            GamePiece p1 = board[pieceCurrentX + 1, pieceCurrentZ - 1];
            GamePiece p2 = board[pieceCurrentX - 1, pieceCurrentZ + 1];

            _somethingKilled = KillTwo(p1, p2, _myTeam);
            if(_somethingKilled == true)
            {
                _killCount += 2;
            }
        }
        // left diagonal Repeated kill fix
        if ((pieceCurrentX + 1) <= _tileCount && (pieceCurrentX - 1) >= 0 &&
                (pieceCurrentZ + 1) <= _tileCount && (pieceCurrentZ - 1) >= 0)
        {
            GamePiece p1 = board[pieceCurrentX + 1, pieceCurrentZ - 1];
            GamePiece p2 = board[pieceCurrentX - 1, pieceCurrentZ + 1];

            // top 2 down 1
            if((pieceCurrentX - 2) >= 0 && (pieceCurrentZ + 2) <= _tileCount)
            {
                GamePiece p3 = board[pieceCurrentX - 2, pieceCurrentZ + 2];

                _somethingKilled = KillOnlyOne(p1, p2, p3, _myTeam);
                if(_somethingKilled == true)
                {
                    // kill 2 minus 1 double counted
                    _killCount -= 1;
                }
            }
            // top 1 down 2
            if((pieceCurrentX + 2) <= _tileCount && (pieceCurrentZ - 2) >= 0)
            {
                GamePiece p3 = board[pieceCurrentX + 2, pieceCurrentZ - 2];

                _somethingKilled = KillOnlyOne(p1, p2, p3, _myTeam);
                if(_somethingKilled == true)
                {
                    // kill 2 minus 1
                    _killCount -= 1;
                }
            }
            // top 2 down 2
            if((pieceCurrentX + 2) <= _tileCount && (pieceCurrentZ + 2) <= _tileCount &&
                (pieceCurrentX - 2) >= 0 && (pieceCurrentZ - 2) >= 0)
            {
                GamePiece p3 = board[pieceCurrentX - 2, pieceCurrentZ + 2];
                GamePiece p4 = board[pieceCurrentX + 2, pieceCurrentZ - 2];

                _somethingKilled = KillNone(p1, p2, p3, p4, _myTeam);
                if(_somethingKilled == true)
                {
                    // kill 2 minus 2 double counted
                    _killCount -= 2;
                }
            }

        }

            return _killCount;
    }       

    private bool KillOne(GamePiece p1, GamePiece p2, int team)
    {
        if(p1 != null && p1.Team != team &&
            p2 != null && p2.Team == team)
        {
            // TODO sfx, feedBack

            StartDestroyOne(p1);            
            return true;
        }
        return false;
    }

    private bool KillTwo(GamePiece p1, GamePiece p2, int team)
    {
        if(p1 != null && p1.Team != team &&
                p2 != null && p2.Team != team)
        {
            //TODO feedback
            StartDestroyTwo(p1, p2);
            return true;
        }        
        return false;
    }

    private bool KillOnlyOne(GamePiece p1, GamePiece p2, GamePiece p3, int team)
    {
        if (p1 & p2 & p3 != null &&
            p1.Team != team &&
            p2.Team != team &&
            p3.Team == team)
        {
            // TODO feedback
            EliminateTwo(p1, p2);
            return true;
        }
        return false;
    }

    private bool KillNone(GamePiece p1, GamePiece p2, GamePiece p3, GamePiece p4, int team)
    {
        if (p1 & p2 & p3 & p4 != null &&
            p1.Team != team &&
            p2.Team != team &&
            p3.Team == team &&
            p4.Team == team)
        {
            //TODO feedback
            EliminateTwo(p1, p2);
            return true;
        }
        return false;

    }

    private void EliminateTwo(GamePiece p1, GamePiece p2)
    {
        //TODO feedback
        StartDestroyTwo(p1, p2);
    }

    private void StartDestroyOne(GamePiece p)
    {
        // TODO feedback
       // yield return new WaitForSeconds(_destroyDelay);
        Destroy(p.gameObject);
        p = null;
    }

    private void StartDestroyTwo(GamePiece p1, GamePiece p2)
    {
        // TODO feedback
       // yield return new WaitForSeconds(_destroyDelay);

        Destroy(p1.gameObject);
        Destroy(p2.gameObject);
        p1 = null;
        p2 = null;
    }
}
