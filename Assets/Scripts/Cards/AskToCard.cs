using UnityEngine;

public class AskToCard : MonoBehaviour
{
    private Deck _owner;
    private AllDeck _allDeck;
    [SerializeField] private Deck _against;

    private CardsTurnManager _turnManager;
    private Entity _entity;

    private void Awake()
    {
        _owner = GetComponent<Deck>();
        _entity = GetComponent<Entity>();
        _allDeck = FindAnyObjectByType<AllDeck>();
        _turnManager = FindAnyObjectByType<CardsTurnManager>();
    }

    public void TryPick(CardPrefab card)
    {
        if(card == null) card = _owner.SelectRandomCard();

        if (!_turnManager.ReturnTurn(_entity.Turn))
        {
            return;
        }

        if (_against.CheckCard(card) && _turnManager.ReturnTurn(_entity.Turn))
        {
            _owner.StealCards(card, _against);
            _turnManager.CheckTurn();
            return;
        }
        
    }
}
