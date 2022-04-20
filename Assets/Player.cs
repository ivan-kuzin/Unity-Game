using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField] SwipeDirection _swipeDirection;
    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] float _speed;

    private Vector3 _velocity;

    private void FixedUpdate() {
        _rigidbody.velocity = _velocity;
    }

    public void Swipe(SwipeDirection swipeDirection, float sing) {
        if (_swipeDirection == swipeDirection) {
            if (_swipeDirection == SwipeDirection.X) {
                _velocity = Vector3.right * sing * _speed;
            } else {
                _velocity = Vector3.forward * sing * _speed;
            }
        } else {
            _velocity = Vector3.zero;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(this.CompareTag("Player") && other.CompareTag("Finish"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );
        }
    }
    
}
