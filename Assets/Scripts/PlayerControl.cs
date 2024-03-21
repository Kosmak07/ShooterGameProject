using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    private float _fallVelocity = 0;
    private CharacterController _characterController;
    private Vector3 _moveVector;
    public float gravity = 9.8f;
    public float jumpForce;
    public float Speed;
    public Animator animator;
    public float score = 0;
    public Text text;
    public GameObject gameplayUI;
    public GameObject gameWinScreen;
    public GameObject Gun;


    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        _moveVector = Vector3.zero;
        var runDirection = 0;

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
            runDirection = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
            runDirection = 2;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
            runDirection = 3;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
            runDirection = 4;
        }

        animator.SetInteger("run Direction", runDirection);

        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -jumpForce;
        }

        if (score >= 30)
        {
            gameplayUI.SetActive(false);
            gameWinScreen.SetActive(true);
            animator.SetTrigger("Win");
            Gun.GetComponent<Shooter>().enabled = false;
            GetComponent<CameraRotation>().enabled = false;
            GetComponent<GrenadeCaster>().enabled = false;
            GetComponent<PlayerControl>().enabled = false;
        }
    }

    void FixedUpdate()
    {
        _characterController.Move(_moveVector * Time.deltaTime * Speed);

        _fallVelocity += gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.deltaTime);
        if (_characterController.isGrounded)
        {
            _fallVelocity = 0;
        }
    }

    public void AddPointToScore()
    {
        score++;
        text.text = score.ToString();
    }
}
