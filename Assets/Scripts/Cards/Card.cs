using UnityEngine;

[CreateAssetMenu(fileName ="Card_",menuName = "Cards")]
public class Card : ScriptableObject
{
    public Sprite CardImage;
    public int Value;
    public TypeOfCard TypeOfCard;
}

public enum TypeOfCard
{
    DIAMONDS,
    HEARTS,
    SPADES,
    CLUBS
}
