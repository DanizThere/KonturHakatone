using System.Collections;
using TMPro;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private Transform _startPos;
    [SerializeField] private Transform _startGamePos;
    [SerializeField] private AudioClip _gameMusic;
    [SerializeField] private AudioClip _startMusic;
    [SerializeField] private AudioClip _CatTolk;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private string text;
    [SerializeField] private Transform _startGamePosMans;
    private UIManager _uiManager;
    private Camera _camera;
    private AudioManager _audioManager;
    private TypingManager _typingManager;

    private void Awake()
    {
        _camera = Camera.main;
        

        _camera.transform.position = _startPos.position;
    }

    private void Start()
    {
        _typingManager = TypingManager.Instance;
        _uiManager = UIManager.Instance;
        _audioManager = AudioManager.Instance;
        _typingManager.StartType(_text, text, _CatTolk);

        _audioManager.PlayMusic(_startMusic);
    }

    public void StartGamePlay()
    {
        _uiManager.Start.SetActive(false);

        StartCoroutine(StartGameplay());
    }

    public void StartMansion()
    {
        StartCoroutine(GoToMansion());
    }

    private IEnumerator StartGameplay()
    {
        _audioManager.PlayMusic(_gameMusic);
        float progress = 0;
        while(progress <= 1.5)
        {
            _camera.transform.position = Vector3.MoveTowards(_camera.transform.position, _startGamePos.position, .1f);
            progress += Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator GoToMansion()
    {
        float progress = 0;
        _audioManager.StopMusic();
        yield return new WaitForSeconds(1.5f);
        while (progress <= 5f)
        {
            _camera.transform.position = Vector3.MoveTowards(_camera.transform.position, _startGamePosMans.position, .04f);
            progress += Time.deltaTime;
            yield return null;
        }
        SceneLoader.Instance.LoadScene(2);
    }
}
