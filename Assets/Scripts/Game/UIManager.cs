using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private GameObject _lose;
    [SerializeField] private GameObject _start;
    [SerializeField] private GameObject _end;
    [SerializeField] private GameObject _textInfo;

    [SerializeField] private RectTransform _hpBar;

    public GameObject Lose => _lose;
    public GameObject Start => _start;
    public GameObject End => _end;
    public RectTransform HpBar => _hpBar;
    public GameObject TextInfo => _textInfo;

    private void Awake()
    {
        Instance = this;

        _lose.SetActive(false);
        _end.SetActive(false);
    }
}
