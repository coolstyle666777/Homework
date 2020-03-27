using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    [SerializeField] private CanvasGroup _doorCanvasGroup;
    private Player _player;   

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _doorCanvasGroup.alpha = 1;
            _player = player;
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (_player.DoorDestroy)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _doorCanvasGroup.alpha = 0;
        }
    }
}
