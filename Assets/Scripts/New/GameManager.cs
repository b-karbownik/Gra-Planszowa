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
    public ShowArrow _showArrow;
    public ChoiceActivity _choiceActivity;
    public CanvasManager _canvasManager;
    public SelectPlayer _selectPlayer;
    public bool isPlaying;
    public bool Activity;


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
        _choiceActivity = GetComponent<ChoiceActivity>();
        _canvasManager = GetComponent<CanvasManager>();
        _selectPlayer = GetComponent<SelectPlayer>();
        _dice = GetComponent<Dice>();
        _dice.Disable();
        _players.AddPlayers();
        player = _players.playersList[0];
        isPlaying = false;
        Activity = false;
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
                    _showArrow.Hide();
                    yield return null;
                }
                yield return new WaitForSeconds(0.1f);
                
            }
            else
            {
                if(player.currentRoute.availableRoutesChanges.Count == 1)
                {
                    _playerMove.ChangeRoute(1);
                }
                _showArrow.Show();
                yield return null;
            }
        }

        //zmien napis na przycisku "roll dice" na "skip turn".
        //zmien dzialanie przycisku.
        _canvasManager.ShowIcons();
        _selectPlayer.SelectPlayersList();


        CompareFields();
        _dice.Disable();
        
        _cameraManager.SwitchCam(player.GetComponentInChildren<Camera>());

        while (Activity == false)
        {
            yield return new WaitForSeconds(0.1f);
        }

        isPlaying = false;
        player = _switchPlayers.Switch(_players, _players.playersList.IndexOf(player));

        //zmien napis na przycisku "skip turn" na "roll dice".
        //zmien dzialanie przycisku
        _canvasManager.HideIcons();
        _selectPlayer.ClearPlayersList();
    }

    void CompareFields()
    {
        if (player.currentRoute.childFieldList[player.routePosition].CompareTag("AttackField"))
        {
            player.TakeDamage(25);
            Debug.Log("Zadano obrazenia!");
        }
        else if (player.currentRoute.childFieldList[player.routePosition].CompareTag("HealField"))
        {
            player.TakeHeal(25);
            Debug.Log("Uleczono!");
        }
        else if (player.currentRoute.childFieldList[player.routePosition].CompareTag("Fireball"))
        {
            player.TakeFireball();
            Debug.Log("Dodano 1 fireball!");
        }

    }


}
