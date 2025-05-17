using UnityEngine;

public class Player : Entity
{
    [SerializeField] private int _maxHp;

    private int _hp;
    private int _score;

    public int HP {
        get => _hp;
        set => Mathf.Clamp(value, 0, _maxHp);
    }
    public int Score
    {
        get => _score;
        set => Mathf.Clamp(_score, 0, int.MaxValue);
    }

    private void Awake()
    {
        _hp = _maxHp;
        _score = 0;
    }
}
