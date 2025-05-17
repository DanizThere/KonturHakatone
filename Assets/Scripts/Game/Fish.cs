using UnityEngine;

public class Fish : Item
{
    private Player _player;

    private void Awake()
    {
        _player = FindAnyObjectByType<Player>();
    }

    public override void Interact()
    {
        if (!_canInteract) return;
        _player.Score += 1500;
        gameObject.SetActive(false);
    }
}
