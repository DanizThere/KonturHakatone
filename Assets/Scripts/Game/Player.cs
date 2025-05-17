using UnityEngine;
using UnityEngine.UI;

public class Player : Entity
{
    [SerializeField] private int _maxHp;
    [SerializeField] private AudioClip _lose;
    [SerializeField] private AudioClip _hit;
    [SerializeField] private AudioClip _heal;
    private Image _image;
    private UIManager _uiManager;
    private AudioManager _audioManager;

    private int _hp;
    private int _score;

    public int HP => _hp;
    public int Score
    {
        get => _score;
        set => Mathf.Clamp(_score, 0, int.MaxValue);
    }

    private void Awake()
    {
        _hp = _maxHp;
        _score = 1000;
        _uiManager = UIManager.Instance;
        _audioManager = AudioManager.Instance;
    }

    public void SetSprite(Sprite sprite)
    {
        _image.sprite = sprite;
    }

    public void SetHit(int value)
    {
        _hp -= value;
        _score -= value * 100;
        _audioManager.PlaySound(_hit);

        if (_hp <= 0) 
        {
            _audioManager.PlayMusic(_lose);
            _uiManager.Lose.SetActive(true); 
        }
    }

    public void SetHeal()
    {
        if(!(_hp + 1 > _maxHp))
        {
            _hp += 1;
            _score += 500;
        }
        else
        {
            _hp = _maxHp;
            _score += 1000;
        }

        _audioManager.PlaySound(_heal);
    }
}
