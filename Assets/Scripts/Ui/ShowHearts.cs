using UnityEngine;

public class ShowHearts : MonoBehaviour
{
    private GameObject _hp;
    private MonoBehaviour[] _hearts;

    public void Init()
    {
        _hp = UIManager.Instance.HpBar;

        _hearts = _hp.GetComponentsInChildren<MonoBehaviour>();
    }

    public void UpdateHearts(int hp)
    {
        for(int i = 0; i < _hearts.Length; i++)
        {
            _hearts[i].gameObject.SetActive(false);
        }

        for(int i = 0; i <= hp; i++)
        {
            _hearts[i].gameObject.SetActive(true);
        }
    }
}
