using UnityEngine;

public class CatDeck : Deck
{
    public override void AddCard(CardPrefab card)
    {
        card.transform.SetParent(_rootTransform);
        _cards.Add(card);
    }
}
