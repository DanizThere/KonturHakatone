using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] private Turn _turn;

    public Turn Turn => Turn;
}
