using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XyzTextFading : MonoBehaviour
{
    [Header("Values")] 
    public bool autoRun;
    public float delayToStart;
    public float speedOfFading;
    private float _valueOfFading;
    public bool setStartColor;
    public bool hideAfterDone;
    private bool _delay = true;
    [SerializeField] private bool worker;
    
    [Header("Points")]
    public Color xColor;
    public Color yColor;
    
    [Header("Objects")] 
    public Text image;
    
    private void Awake()
    {
        if (autoRun)
        {
            if (setStartColor)
            {
                image.color = xColor;
            }
            worker = true;
            StartCoroutine(DelayToStart());
        }
    }
    
    private void FixedUpdate()
    {
        if (worker && !_delay)
        {
            _valueOfFading += (Time.deltaTime + speedOfFading) / 1000;
            image.color =
                Vector4.Lerp(xColor, yColor, _valueOfFading);
            if (image.color == yColor)
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
            _valueOfFading = 0;
            worker = true;
            if (newPos == "")
            {
                (xColor, yColor) = (yColor, xColor);
                hideAfterDone = false;
            }else if (newPos == "D")
            {
                (xColor, yColor) = (yColor, xColor);
                hideAfterDone = true;
            }

            if (setStartColor)
            {
                image.color = xColor;
            }
            StartCoroutine(DelayToStart());
        }
    }
    
    private IEnumerator DelayToStart()
    {
        yield return new WaitForSeconds(delayToStart);
        _valueOfFading = 0;
        _delay = false;
    }
}
