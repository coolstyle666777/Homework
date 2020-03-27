using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Text _healthText;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _healthChangeStep;
    private float _currentHealth;
    private Slider _slider;

    public void Start()
    {
        _slider = GetComponent<Slider>();
        _currentHealth = _maxHealth;
        SetText();
    }

    public void FixedUpdate()
    {
        _slider.value = Mathf.Lerp(_slider.value, _currentHealth / _maxHealth, Time.fixedDeltaTime + _healthChangeStep);
    }

    public void HealthUp()
    {
        if (_currentHealth < _maxHealth)
        {
            _currentHealth += 10;
            SetText();          
        }  
    }

    public void HealthDown()
    {
        if (_currentHealth != 0)
        {
            _currentHealth -= 10;
            SetText();            
        }
    }

    private void SetText()
    {
        _healthText.text = _currentHealth.ToString();
    }
}
