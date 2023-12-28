using System;
using UnityEngine;

namespace Movement
{
    public class PlayerMovement : MonoBehaviour, ISlippinble
    {
        private float _speed;
        private float _minSpeed;
        private Vector3 _directionIceSurface;

        public bool IsMoved { get; private set; }
        public bool IsOnSlippined { get; set; }

        public Vector3 FirstPosition => transform.position;
        public Vector3 SecondPosition => transform.position;

        private void Update()
        {
            if (IsOnSlippined)
            {
                Move(_directionIceSurface);
            }
        }

        public void TakeSpeed(float speed)
        {
            if (speed <= _minSpeed)
            {
                _speed = ++_minSpeed;
            }

            _speed = speed;
        }

        public void Move(Vector3 direction)
        {
            if (direction.sqrMagnitude > 0)
            {
                IsMoved = true;
                transform.Translate(_speed * Time.deltaTime * direction, Space.World);
            }
            else
            {
                IsMoved = false;
            }
        }

        public void TakeSlippinedDirection(Vector3 slippinedDirection)
        {
            _directionIceSurface = slippinedDirection;
        }
    }
}