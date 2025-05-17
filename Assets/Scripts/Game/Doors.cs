using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Doors : MonoBehaviour
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private Doors[] unlocables;
    [SerializeField] private QuizQuestion _question;
    private Button _button;
    private Player _player;
    private Camera _camera;
    private QuizBattle _quizBattle;

    public Button Button => _button;

    private void Awake()
    {
        _player = FindAnyObjectByType<Player>();
        _camera = Camera.main;
        _button = GetComponent<Button>();
    }

    private void Start()
    {
        _quizBattle = QuizBattle.Instance;
    }

    public void OnPointerDown()
    {
        _quizBattle.InitBattle(_question, _player, this);
    }

    public void OnLoose()
    {
        _player.SetSprite(_sprite);
        Vector2 pos = _cameraTransform.position;
        _player.transform.position = _playerTransform.position;
        _camera.transform.position = new Vector3(pos.x, pos.y, -10);

        foreach (var door in unlocables)
        {
            door.Button.interactable = true;
        }

        gameObject.SetActive(false);
    }
}
