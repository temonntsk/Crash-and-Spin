using System;
using UnityEngine;

namespace Movement
{
    public class PlayerMovement : MonoBehaviour, ISlippined
    {
        [SerializeField] private float _speed;

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

        public void Move(Vector3 direction)
        {
            if (direction.magnitude > 0)
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