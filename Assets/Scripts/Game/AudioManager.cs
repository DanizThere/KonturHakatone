using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource _musicInGame;
    [SerializeField] private AudioSource _sounds;
    [HideInInspector] public AudioClip _lastMusic;

    private void Awake()
    {
        Instance = this;
    }

    public void PlaySound(AudioClip clip)
    {
        _sounds.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip)
    {
        _musicInGame.Stop();
        _musicInGame.PlayOneShot(clip);
    }
}
