using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] private Turn _turn;
    private int _specs = 0;

    public int Specs => _specs;
    public Turn Turn => _turn;

    public void AddSpec(int spec)
    {
        _specs += spec;
    }
}
