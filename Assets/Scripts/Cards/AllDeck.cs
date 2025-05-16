using System.Collections.Generic;
using UnityEngine;

public class AllDeck : MonoBehaviour
{
    public List<CardPrefab> CardPrefabs;

    public void Shuffle()
    {
        System.Random rand = new System.Random();

        for (int i = CardPrefabs.Count - 1; i >= 1; i--)
        {
            int j = rand.Next(i + 1);

            var tmp = CardPrefabs[j];
            CardPrefabs[j] = CardPrefabs[i];
            CardPrefabs[i] = tmp;
        }
    }

    private void Awake()
    {
        Shuffle();
    }
}
