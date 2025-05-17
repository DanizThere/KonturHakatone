using System.Collections;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private Transform _startPos;
    [SerializeField] private Transform _startGamePos;
    [SerializeField] private AudioClip _gameMusic;
    private Camera _camera;
    private AudioManager _audioManager;


    private void Awake()
    {
        _camera = Camera.main;
        _audioManager = AudioManager.Instance;

        _camera.transform.position = _startPos.position;

        StartCoroutine(StartGameplay());
    }

    public IEnumerator StartGameplay()
    {
        float progress = 0;
        while(progress <= 1.5)
        {
            _camera.transform.position = Vector3.MoveTowards(_camera.transform.position, _startGamePos.position, .5f);
            yield return null;
        }
        _audioManager._lastMusic = _gameMusic;
        _audioManager.PlayMusic(_gameMusic);
    }
}
