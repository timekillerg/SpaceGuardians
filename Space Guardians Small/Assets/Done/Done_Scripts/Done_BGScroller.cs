using UnityEngine;
using System.Collections;

public class Done_BGScroller : MonoBehaviour
{
    public float scrollSpeed;

    private float _startTime;
    private float _timeInPlay;
    private float endXPosition;

    void Awake()
    {
        _startTime = Time.time; 
        _timeInPlay = 0.001f;
    }

    void Start()
    {
        _startTime = Time.time;
        _timeInPlay = 0.001f;
        endXPosition = transform.position.z - transform.localScale.y + 25;
    }

    void Update()
    {
        _timeInPlay = Time.time - _startTime;
        if (transform.position.z > endXPosition)
            transform.position = transform.position + Vector3.forward * Time.deltaTime * scrollSpeed / (_timeInPlay <= 60 ? 1 : _timeInPlay / 60);
    }
}