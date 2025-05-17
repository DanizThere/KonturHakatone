using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Doors : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private Doors[] unlocables;
    [SerializeField] private QuizQuestion _question;
    private Player _player;
    private Camera _camera;
    private QuizBattle _quizBattle;

    private void Awake()
    {
        _player = FindAnyObjectByType<Player>();
        _camera = Camera.main;
        _quizBattle = QuizBattle.Instance;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _quizBattle.InitBattle(_question, _player, this);
    }

    public void OnLoose()
    {
        _player.SetSprite(_sprite);
        _player.transform.position = _playerTransform.position;
        _camera.transform.position = _cameraTransform.position;

        foreach (var door in unlocables)
        {
            var sprite = door.GetComponent<Image>();
            sprite.raycastTarget = true;
        }
    }
}
