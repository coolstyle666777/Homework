using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    [SerializeField] private float _volumeStep;
    private AudioSource _alarmSound;
    private bool _startAlarm;

    public void Awake()
    {
        _alarmSound = GetComponentInChildren<AudioSource>();
        _alarmSound.volume = 0;        
    }

    public void FixedUpdate()
    {
        if (_startAlarm)
        {
            LerpSound(true);
        }
        else
        {
            LerpSound(false);
        }
    }

    private void LerpSound(bool increase)
    {
        if (increase)
        {
            _alarmSound.volume = Mathf.Lerp(_alarmSound.volume, 1, _volumeStep);
        }
        else
        {
            _alarmSound.volume = Mathf.Lerp(_alarmSound.volume, 0, _volumeStep);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _startAlarm = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _startAlarm = false;
        }
    }
}
