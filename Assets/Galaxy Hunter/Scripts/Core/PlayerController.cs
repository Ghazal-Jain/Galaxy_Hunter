using Unity.Mathematics;
using UnityEngine;

namespace Galaxy_Hunter.Scripts.Core
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private Transform _transform;
        private Camera _camera;
        private Vector3 _moveDirection;
        private Vector3 _mousePos;
        private Vector3 _lookDir;
        private Vector3 _movement;
        
        public float maxSpeed = 5.0f;

        private void Awake()
        {
            _camera = Camera.main;
            _rigidbody = GetComponent<Rigidbody>();
            _transform = GetComponent<Transform>();
        }

        private void Update()
        {
            _movement = new Vector2(
                Input.GetAxis("Horizontal"), 
                Input.GetAxis("Vertical"));
        }

        private void FixedUpdate()
        {
            MovePlayer(_movement);
        }

        private void MovePlayer(Vector2 move)
        {
            _moveDirection = (new Vector3(move.x, 0, move.y)).normalized;
            _rigidbody.AddForce(_moveDirection * maxSpeed);

            // clamp speed
            _rigidbody.velocity = new Vector3(
                Mathf.Clamp(_rigidbody.velocity.x, -maxSpeed, maxSpeed),
                Mathf.Clamp(_rigidbody.velocity.y, -maxSpeed, maxSpeed),
                Mathf.Clamp(_rigidbody.velocity.z, -maxSpeed, maxSpeed));

            // look at mouse pointer
            _mousePos = _camera.ScreenToWorldPoint(new Vector3(
                Input.mousePosition.x, Input.mousePosition.y, 0.0f));
            _mousePos = new Vector3(_mousePos.x, 0, _mousePos.z);
            _lookDir = (_mousePos - _transform.position).normalized;
            _transform.localRotation = quaternion.LookRotation(_lookDir, Vector3.up);
        }
    }
}