using UnityEngine;

public class AskToCard : MonoBehaviour
{
    private Deck _owner;
    private AllDeck _allDeck;
    [SerializeField] private Deck _against;

    private CardsTurnManager _turnManager;
    private Entity _entity;
    private Cat _cat;

    private void Awake()
    {
        _owner = GetComponent<Deck>();
        _entity = GetComponent<Entity>();
        _allDeck = FindAnyObjectByType<AllDeck>();
        _turnManager = FindAnyObjectByType<CardsTurnManager>();
        _cat = FindAnyObjectByType<Cat>();
    }

    public void TryPick(CardPrefab card = null)
    {
        if(card == null) card = _owner.SelectRandomCard();

        if (!_turnManager.ReturnTurn(_entity.Turn))
        {
            return;
        }

        if (_against.CheckCard(card) && _turnManager.ReturnTurn(_entity.Turn))
        {
            if(_turnManager.ReturnTurn(_cat.Turn)) _cat.PlayerHaveCard();
            _owner.StealCards(card, _against);
            return;
        }

        if(!_against.CheckCard(card) && _turnManager.ReturnTurn(_entity.Turn))
        {
            _owner.AddCard(_allDeck.AddCardToDeck());
            _turnManager.CheckTurn();
        }

        int c = _owner.DoExistsFourCards();

        _entity.AddSpec(c);
    }
}
