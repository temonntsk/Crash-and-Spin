using UnityEngine;

namespace Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Rigidbody _player;

        public bool IsMoved { get; private set; }

        private void Awake()
        {
            _player = GetComponent<Rigidbody>();
        }

        public void Move(Vector3 direction)
        {
            if (direction.magnitude > 0)
            {
                IsMoved = true;
                transform.Translate(direction * Time.deltaTime * _speed,Space.World);
            }
            else
            {
                IsMoved = false;
            }
        }
    }
}
