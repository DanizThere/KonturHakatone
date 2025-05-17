using System.Collections;
using UnityEngine;

public class MicroAnim : MonoBehaviour
{
    private float _sin = 0;
    private RectTransform _rectTransform;
    [SerializeField] private float _force = 1.5f;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    private void FixedUpdate()
    {
        _sin = Mathf.Clamp01(Mathf.Sin(Time.time));
        _rectTransform.anchoredPosition = new Vector2(0, _sin * _force);
    }
}
