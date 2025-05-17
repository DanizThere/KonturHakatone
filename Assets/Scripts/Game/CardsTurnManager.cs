using UnityEngine;

public class CardsTurnManager : MonoBehaviour
{
    private Turn _turn;
    private Player _player;
    private Cat _cat;

    private void Awake()
    {
        _player = FindAnyObjectByType<Player>();
        _cat = FindAnyObjectByType<Cat>();

        SetTurn(Turn.PLAYER);
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
                Debug.Log(1);
                break;
            case Turn.PLAYER:
                SetTurn(Turn.CAT); 

                Debug.Log(2);
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
