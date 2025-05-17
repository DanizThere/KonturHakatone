using UnityEngine;

public class CardsTurnManager : MonoBehaviour
{
    private Turn _turn;
    private Player _player;
    private Cat _cat;
    private UIManager _manager;
    private void Awake()
    {
        _player = FindAnyObjectByType<Player>();
        _cat = FindAnyObjectByType<Cat>();

        SetTurn(Turn.PLAYER);

        _manager = UIManager.Instance;
    }

    private void FixedUpdate()
    {
        if(_player.Specs == 2)
        {
            _manager.End.SetActive(true);
        }
        else if(_cat.Specs == 2)
        {
            _player.HP--;
            if (_player.HP <= 0) _manager.Lose.SetActive(true);
        }
    }

    public void StartCards()
    {
        SetTurn(Turn.PLAYER);
    }

    private void SetTurn(Turn turn)
    {
        _turn = turn;
    }

    public void CheckTurn()
    {
        switch (_turn)
        {
            case Turn.CAT:
                SetTurn(Turn.PLAYER);
                break;
            case Turn.PLAYER:
                SetTurn(Turn.CAT);
                _cat.PlayerHaveCard();
                break;
        }
    }

    public bool ReturnTurn(Turn turn)
    {
        return _turn == turn;
    }
}

public enum Turn
{
    PLAYER,
    CAT
}
