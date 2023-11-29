using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XyzImageFading : MonoBehaviour
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
    public Image image;
    
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
    public void StartFading(string input)
    {
        xColor = yColor;
        worker = true;
        var color = input.Split(',');
        if (color.Length == 1)
        {
            ColorUtility.TryParseHtmlString(color[0], out yColor);
        }
        else if (color.Length == 2)
        {
            ColorUtility.TryParseHtmlString(color[0], out yColor);
            ColorUtility.TryParseHtmlString(color[1], out xColor);
        }

        StartCoroutine(DelayToStart());
    }
    
    private IEnumerator DelayToStart()
    {
        yield return new WaitForSeconds(delayToStart);
        _valueOfFading = 0;
        _delay = false;
    }
}
