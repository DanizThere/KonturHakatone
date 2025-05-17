using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;

public class TypingManager : MonoBehaviour
{
    [SerializeField] private AudioClip _voice;
    [SerializeField] private AudioSource _audioSource;
    public static TypingManager Instance;

    private void Awake()
    {
        Instance = this;

    }

    public void StartType(TextMeshProUGUI textfield, string text, AudioClip clip)
    {
        Cancel();
        StartCoroutine(Type(textfield, text, clip));
    }

    public void Cancel()
    {
        StopAllCoroutines();
    }

    private IEnumerator Type(TextMeshProUGUI textfield, string text, AudioClip clip)
    {
        var stringbuilder = new StringBuilder();
        _audioSource.PlayOneShot(clip, .5f);

        foreach (var ch in text)
        {
            stringbuilder.Append(ch.ToString());
            textfield.text = stringbuilder.ToString();
            yield return null;
        }
    }
}
