using System;
using System.Collections;
using UnityEngine;

public class XyzUITransition : MonoBehaviour
{
    [Header("Values")] 
    public bool autoRun;
    public float delayToStart;
    public float speedOfTransition;
    private float _valueOfTransition;
    
    // if true => current position = firstPosition
    public bool setStartPosition;
    public bool hideAfterDone;
    private bool _delay = true;
    
    // don't touch this
    [SerializeField] private bool worker;
    
    [Header("Points")]
    public Vector2 firstPosition;
    public Vector2 secondPosition;
    
    [Header("Objects")] 
    public RectTransform rect;

    private void Awake()
    {
        if (autoRun)
        {
            if (setStartPosition)
            {
                rect.anchoredPosition = firstPosition;
            }
            worker = true;
            StartCoroutine(DelayToStart());
        }
    }

    private void FixedUpdate()
    {
        if (worker && !_delay)
        {
            _valueOfTransition += (Time.deltaTime + speedOfTransition) / 1000;
            rect.anchoredPosition =
                Vector2.Lerp(firstPosition, secondPosition, _valueOfTransition);
           if (rect.anchoredPosition == secondPosition)
           {
               worker = false;
               _delay = true;
               if (hideAfterDone)
               {
                   gameObject.SetActive(false);
               }
           }
        }
    }

    public void StartTransition(string newPos)
    {
        if (!worker)
        {
            _valueOfTransition = 0;
            worker = true;
            if (newPos == "")
            {
                (firstPosition, secondPosition) = (secondPosition, firstPosition);
                hideAfterDone = false;
            }else if (newPos == "D")
            {
                (firstPosition, secondPosition) = (secondPosition, firstPosition);
                hideAfterDone = true;
            }

            if (setStartPosition)
            {
                rect.anchoredPosition = firstPosition;
            }
            StartCoroutine(DelayToStart());
        }
    }
    
    private IEnumerator DelayToStart()
    {
        yield return new WaitForSeconds(delayToStart);
        _valueOfTransition = 0;
        _delay = false;
    }
}
