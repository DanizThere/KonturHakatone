using System.Collections;
using UnityEngine;

public class MicroAnim : MonoBehaviour
{
    private float _sin = 0;

    private void FixedUpdate()
    {
        _sin = Mathf.Sin(1);
        transform.position = new Vector2(0, _sin);
    }
}
