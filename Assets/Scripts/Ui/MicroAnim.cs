using System.Collections;
using UnityEngine;

public class MicroAnim : MonoBehaviour
{
    private float _sin = 0;
    private RectTransform _rectTransform;
    [SerializeField] private bool _clamping = true;
    [SerializeField] private float _force = 1.5f;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    private void FixedUpdate()
    {
        if (_clamping)
        {
            _sin = Mathf.Clamp01(Mathf.Sin(Time.time));
        }
        else
        {
            _sin = Mathf.Sin(Time.time);
        }
        _rectTransform.position = new Vector2(0, _sin * _force);
    }
}
