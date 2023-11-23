using UnityEngine;

namespace Movement
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _movement;
        [SerializeField] private FloatingJoystick _floatingJoystick;

        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        private Vector3 _moveVector;

        private void Update()
        {
            _moveVector = GettSouseDirection();
        }

        private void FixedUpdate()
        {
            _movement.Move(_moveVector);
        }

        private Vector3 GettSouseDirection()
        {
            if (_floatingJoystick.IsActive)
            {
                return new Vector3(_floatingJoystick.Horizontal, 0, _floatingJoystick.Vertical);
            }

            return new Vector3(Input.GetAxis(Horizontal), 0, Input.GetAxis(Vertical));
        }
    }
}
