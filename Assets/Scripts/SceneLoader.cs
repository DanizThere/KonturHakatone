using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;
    [SerializeField] private GameObject _loadingBar;
    [SerializeField] private Slider _loadingSlider;

    

    public void LoadScene(int sceneId)
    {
        _loadingBar.SetActive(true);
        StartCoroutine(LoadLevelAsync(sceneId));
    }

    private IEnumerator LoadLevelAsync(int sceneId)
    {
        var loadOperation = SceneManager.LoadSceneAsync(sceneId);

        while (loadOperation != null)
        {
            var progress = Mathf.Clamp01(loadOperation.progress / .9f);
            _loadingSlider.value = progress;
            yield return null;
        }
    }

    private void Awake()
    {
        Instance = this;
        _loadingBar.SetActive(false);
    }
}
