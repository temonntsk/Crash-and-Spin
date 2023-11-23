using UnityEngine;

namespace Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _rotationSpeed;

        private Rigidbody _player;

        private void Awake()
        {
            _player = GetComponent<Rigidbody>();
        }

        internal void Move(Vector3 direction)
        {
            _player.velocity = direction * Time.deltaTime * _speed;
            
            transform.Rotate(Vector3.up * Time.deltaTime * _rotationSpeed);
        }
    }
}
