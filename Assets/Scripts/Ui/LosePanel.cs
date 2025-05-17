using TMPro;
using UnityEngine;

public class LosePanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private Player _player;

    private void Awake()
    {
        _player = FindAnyObjectByType<Player>();
    }

    private void OnEnable()
    {
        _text.text = $"Ñ÷¸ò: {_player.Score}";
    }
}
