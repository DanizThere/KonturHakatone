using UnityEngine;

public class Heart : Item
{
    private Player _player;

    private void Awake()
    {
        _player = FindAnyObjectByType<Player>();
    }

    public override void Interact()
    {
        if (!_canInteract) return;

        _player.SetHeal();
        gameObject.SetActive(false);
    }
}
