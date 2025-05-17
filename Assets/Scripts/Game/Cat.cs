using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class Cat : Entity
{
    private Deck _deck;
    private AskToCard _askToCard;
    private AudioSource _audioSource;
    private Dictionary<CardValue, CardPhrase> _lines = new();
    private CardsTurnManager _turnManager;
    private UIManager _uiManager;
    private IEnumerator _coroutine; 
    [SerializeField] private CardPhrase[] _phrases;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private AudioClip _voice;

    private void Awake()
    {
        _askToCard = GetComponent<AskToCard>();
        _audioSource = GetComponent<AudioSource>();
        _deck = GetComponent<Deck>();
        _turnManager = FindAnyObjectByType<CardsTurnManager>();
        _uiManager = UIManager.Instance;

        foreach (var phrase in _phrases)
        {
            if (!_lines.ContainsKey(phrase.Value)) _lines.Add(phrase.Value, phrase);
        }
    }

    public void PlayerHaveCard()
    {
        if(_coroutine != null) StopCoroutine(_coroutine);

        var card = _deck.SelectRandomCard();
        _coroutine = CheckCard(card);
        StartCoroutine(_coroutine);
    }

    public IEnumerator CheckCard(CardPrefab card)
    {
        _text.text = null;
        _uiManager.TextInfo.SetActive(true);

        var clips = _lines[(CardValue)card.Card.Value];
        int last = clips.Phrases.Length;

        var clip = clips.Phrases[Random.Range(0, last)];

        var text = clip.Text;
        var voice = _voice;

        var stringbuilder = new StringBuilder();

        foreach (var ch in text)
        {
            stringbuilder.Append(ch.ToString());
            _text.text = stringbuilder.ToString();
            if(voice != null) _audioSource.PlayOneShot(voice, .5f);
            yield return null;
        }
        _uiManager.TextInfo.SetActive(false);

        _askToCard.TryPick(card);
    }
}

public enum CardValue
{
    two = 2,
    three,
    four,
    five,
    six,
    seven,
    eight,
    nine,
    ten,
    eleven,
    twelve,
    thirteen
}
