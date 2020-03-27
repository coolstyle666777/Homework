using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private CharacterMover _CharacterMover;
    private Animator _playerAnimator;
    private Rigidbody2D _rigidbody2D;
    private float _horizontalMove;
    private bool _isJump;
    private bool _doorDestroy;

    public bool DoorDestroy => _doorDestroy;

    private void Awake()
    {
        _CharacterMover = GetComponent<CharacterMover>();
        _playerAnimator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckInputs();
    }

    private void FixedUpdate()
    {
        MoveAction();
    }

    private void SetAnimationMove()
    {
        if (_horizontalMove != 0)
        {
            _playerAnimator.SetBool("Running", true);
        }
        else
        {
            _playerAnimator.SetBool("Running", false);
        }
    }

    private void CheckInputs()
    {
        _horizontalMove = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            _isJump = true;
            _playerAnimator.SetBool("Grounded", false);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            _doorDestroy = true;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            _doorDestroy = false;
        }
    }

    private void MoveAction()
    {
        _CharacterMover.Move(_horizontalMove, _isJump);
        _isJump = false;
        SetAnimationMove();
    }
}
