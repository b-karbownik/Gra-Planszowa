using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerMove _playerMove;
    public Players _players;
    public SwitchPlayers _switchPlayers;
    public Player player;
    public Dice _dice;
    public CameraManager _cameraManager;
    public bool isPlaying;


    void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        _playerMove = gameObject.GetComponent<PlayerMove>();
        _players = gameObject.GetComponent<Players>();
        _switchPlayers = GetComponent<SwitchPlayers>();
        _cameraManager = GetComponent<CameraManager>();
        _dice = GetComponent<Dice>();
        _dice.Disable();
        _players.AddPlayers();
        player = _players.playersList[0];
        isPlaying = false;
    }


    public void RollDice()
    {
        if (isPlaying == false)
        {
            isPlaying = true;
            _dice.Disable();
            player.steps = _dice.GetNum();
            StartCoroutine(Move());
        }
    }
    
    public IEnumerator Move()
    {
        yield return new WaitForSeconds(3.15f);
        _cameraManager.SwitchCam(player.GetComponentInChildren<Camera>());


        _playerMove.player = player;
        while (player.steps > 0)
        {
            if (_playerMove.StartMove() == true)
            {
                while (_playerMove.MoveToNextField(_playerMove.nextPos))
                {
                    yield return null;
                }
                yield return new WaitForSeconds(0.1f);
            }
            else
            {
                yield return null;
            }
        }  
        CompareFields();
        _dice.Disable();
        
        _cameraManager.SwitchCam(player.GetComponentInChildren<Camera>());
        player = _switchPlayers.Switch(_players, _players.playersList.IndexOf(player));
        isPlaying = false;
    }

    void CompareFields()
    {
        if (player.currentRoute.childFieldList[player.routePosition].CompareTag("AttackField"))
        {
            player.TakeDamage(25);
        }
        
        if (player.currentRoute.childFieldList[player.routePosition].CompareTag("HealField"))
        {
            player.TakeHeal(25);
        }
    }
}
