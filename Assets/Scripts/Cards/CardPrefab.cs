using UnityEngine;
using UnityEngine.UI;

public class CardPrefab : MonoBehaviour
{
    [SerializeField] private Card _card;
    private Image _image;

    public Card Card => _card;
    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void Start()
    {
        _image.sprite = _card.CardImage;
    }
}
