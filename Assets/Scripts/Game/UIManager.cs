using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private GameObject _lose;
    [SerializeField] private GameObject _start;
    [SerializeField] private GameObject _end;
    [SerializeField] private GameObject _textInfo;
    [SerializeField] private GameObject _battlefield;

    [SerializeField] private GameObject _hpBar;

    public GameObject Lose => _lose;
    public GameObject Start => _start;
    public GameObject End => _end;
    public GameObject HpBar => _hpBar;
    public GameObject Battlefield => _battlefield;
    public GameObject TextInfo => _textInfo;

    private void Awake()
    {
        Instance = this;

        _start.SetActive(true);

        _lose.SetActive(false);
        _end.SetActive(false);
    }
}
