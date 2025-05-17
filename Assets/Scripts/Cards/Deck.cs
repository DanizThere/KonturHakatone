using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Deck : MonoBehaviour
{
    protected List<CardPrefab> _cards = new();
    protected AllDeck _allDeck;
    [SerializeField] protected Transform _rootTransform;

    private void Awake()
    {
        _allDeck = FindAnyObjectByType<AllDeck>();
    }

    private void Start()
    {
        AddCardRandomly();
    }

    public void AddCardRandomly()
    {
        for(int i = 0; i < 6; i++)
        {
            var item = _allDeck.AddCardToDeck();
            if (item == null) break;
            AddCard(item);
        }
    }

    public virtual void AddCard(CardPrefab card)
    {
        card.gameObject.SetActive(true);
        card.transform.SetParent(_rootTransform);
        _cards.Add(card);

        var cards = _cards.Where(x => x.Card.Value == card.Card.Value).ToList();

        for(int i = cards.Count - 1; i >= 1; i--)
        {
            int c = i;
            var cardp = cards[c];
            var cardn = cards[c - 1];
            cardp.transform.SetParent(cardn.transform);
        }
    }

    public void StealCards(CardPrefab card, Deck deck)
    {
        var cards = deck.SelectRandomCards(card);

        foreach(var deckCard in cards)
        {
            AddCard(deckCard);
        }
    }

    public bool CheckCard(CardPrefab card)
    {
        var cards = _cards.Where(x => x.Card.Value == card.Card.Value).ToList();
        if (cards.Count == 0) return false;
        return true;
    }

    public CardPrefab SelectRandomCard()
    {
        var card = _cards[UnityEngine.Random.Range(0, _cards.Count)];
        if(card == null) SelectRandomCard();
        return card;
    }

    public int DoExistsFourCards()
    {
        var bools = 0;
        for(int i = 0; i < 14; i++)
        {
            var cards = _cards.Where(x => x.Card.Value == i).ToList();

            if (cards.Count != 4) continue;
            bools++;
            foreach (var card in cards)
            {
                _cards.Remove(card);
                card.transform.SetParent(null);
                card.gameObject.SetActive(false);
            }
        }
        return bools;
    }

    private List<CardPrefab> SelectRandomCards(CardPrefab card)
    {
        var cards = _cards.Where(x => x.Card.Value == card.Card.Value).ToList();

        if(!cards.Any()) return null;

        foreach(var deckCard in cards)
        {
            _cards.Remove(deckCard);
        }

        return cards;
    }
}
