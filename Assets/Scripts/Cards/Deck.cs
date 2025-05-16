using System;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    private List<CardPrefab> _cards = new();
    private AllDeck _allDeck;
    [SerializeField] private Transform _rootTransform;

    private void Awake()
    {
        AddCardRandomly();
    }

    public void AddCardRandomly()
    {
        for(int i = 0; i < 6; i++)
        {
            var item = _allDeck.CardPrefabs[^1];
            if (_allDeck.CardPrefabs.Contains(item))
            {
                _cards.Add(item);
                _allDeck.CardPrefabs.Remove(item);
            }
        }
    }

    public void AddCard(CardPrefab card)
    {
        if(_allDeck.CardPrefabs.Contains(card))
        {
            _allDeck.CardPrefabs.Remove(card);
            card.transform.SetParent(_rootTransform);
            _cards.Add(card);
        }
    }
}
