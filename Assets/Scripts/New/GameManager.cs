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
    public RandomCoinSystem _coinSystem;
    public bool isPlaying;
    public bool Activity;
    public GameObject StartField;


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
        _coinSystem = GetComponent<RandomCoinSystem>();
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
                if (_playerMove.nextPos == StartField.transform.position)
                {
                    player.points += 1;
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

        _canvasManager.ShowIcons();
        _selectPlayer.ClearPlayersList();
        _selectPlayer.SelectPlayersList(_players.playersList.IndexOf(player));
       
        CompareFields();
        _dice.Disable();
        
        _cameraManager.SwitchCam(player.GetComponentInChildren<Camera>());

        while (Activity == false)
        {
            yield return new WaitForSeconds(0.1f);
        }

        CheckHpAmount();

        isPlaying = false;
        player = _switchPlayers.Switch(_players, _players.playersList.IndexOf(player));

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
        else if (player.currentRoute.childFieldList[player.routePosition].CompareTag("MedKit"))
        {
            player.TakeMedkit();
            Debug.Log("Dodano 1 medkit!");
        }
        else if (player.currentRoute.childFieldList[player.routePosition].CompareTag("Coin"))
        {
            player.TakeCoin();
            _coinSystem.NewRandomCoin();
            Debug.Log("Dodano 1 coin!");
        }
    }

    void CheckHpAmount()
    {
        foreach (Player player in _players.playersList)
        {
            if (player.health <= 0)
            {
                GameObject respawnPoint = GameObject.FindGameObjectWithTag("Respawn");

                if (respawnPoint != null)
                {
                    Vector3 respawnPosition = respawnPoint.transform.position;
                    player.transform.position = respawnPosition;
                    player.routePosition = 0;
                    player.currentRoute = GameObject.Find("Route1").GetComponent<Route>();
                    player.health += 100;
                }
                else
                {
                    Debug.LogWarning("Brak obiektu z tagiem 'Respawn' w scenie.");
                }
            }
        }
    }
}



