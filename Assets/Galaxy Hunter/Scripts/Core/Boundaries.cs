using UnityEngine;

namespace Galaxy_Hunter.Scripts.Core
{
    public class Boundaries : MonoBehaviour
    {
        private Vector3 _screenBounds;
        private float _playerWidth;
        private float _playerHeight;

        [SerializeField] private float margin = 0.2f;

        private void Awake()
        {
            _screenBounds = Camera.main.ScreenToWorldPoint(
                new Vector3(
                    Screen.width, 
                    Screen.height, 
                    0));
            _playerWidth = 
                GetComponentInChildren<SpriteRenderer>().size.x / 2 + margin;
            _playerHeight = 
                GetComponentInChildren<SpriteRenderer>().size.y / 2 + margin;
        }

        private void LateUpdate()
        {
            Vector3 pos = transform.position;
            pos.x = Mathf.Clamp(
                pos.x,
                -(_screenBounds.x - _playerWidth),
                (_screenBounds.x - _playerWidth));
            pos.z = Mathf.Clamp(
                pos.z,
                -(_screenBounds.z - _playerHeight),
                _screenBounds.z - _playerWidth);
            transform.position = pos;
        }
    }
}