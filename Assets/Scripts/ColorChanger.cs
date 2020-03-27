using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Image _sliderFill;
    [SerializeField] private Color _from;
    [SerializeField] private Color _to;
        
    public void SetPosition(float positon)
    {
        _sliderFill.color = Color.Lerp(_from, _to, positon);
    }
}
