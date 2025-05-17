using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizBattle : MonoBehaviour
{
    public static QuizBattle Instance;

    [SerializeField] private Button[] _buttons;
    [SerializeField] private Color _color;
    [SerializeField] private AudioClip _win;
    [SerializeField] private AudioClip _hit;
    [SerializeField] private TextMeshProUGUI _text;

    private GameObject _battlefield;
    private AudioManager _audioManager;
    private QuizQuestion _question;
    private Player _player;
    private Doors _doors;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _battlefield = UIManager.Instance.Battlefield;
        _audioManager = AudioManager.Instance;
    }

    public void InitBattle(QuizQuestion question, Player player, Doors enemy)
    {
        foreach (var button in _buttons)
        {
            var txt = button.GetComponentInChildren<TMPro.TMP_Text>();
            txt.color = Color.black;
            txt.text = null;
            button.onClick.RemoveAllListeners();
            button.interactable = true;
        }

        _doors = enemy;
        _question = question;
        _player = player;

        _battlefield.SetActive(true);

        _text.text = _question.Question;

        var lst = new List<Button>(_buttons);

        var anwser = lst[UnityEngine.Random.Range(0, lst.Count)];
        anwser.GetComponentInChildren<TMP_Text>().text = _question.Anwser;
        lst.Remove(anwser);

        var b1 = lst[UnityEngine.Random.Range(0, lst.Count)];
        b1.GetComponentInChildren<TMP_Text>().text = _question.BadAnwser[0];
        lst.Remove(b1);

        var b2 = lst[UnityEngine.Random.Range(0, lst.Count)];
        b2.GetComponentInChildren<TMP_Text>().text = _question.BadAnwser[1];

        anwser.onClick.AddListener(delegate { StartCoroutine(Anwser(anwser)); });

        b1.onClick.AddListener(delegate { BadAnwser(b1); });
        b2.onClick.AddListener(delegate { BadAnwser(b2); });
    }

    private IEnumerator Anwser(Button b)
    {
        _doors.OnLoose();
        b.interactable = false;

        foreach(var button in _buttons)
        {
            button.interactable = false;
        }

        _player.Score += 500;
        _audioManager.PlaySound(_win);
        yield return new WaitForSeconds(1);
        _battlefield.SetActive(false);
    }

    private void BadAnwser(Button b)
    {
        _player.SetHit(1);
        _audioManager.PlaySound(_hit);
        b.interactable = false;
        b.GetComponentInChildren<TMPro.TMP_Text>().color = _color;
    }
}
