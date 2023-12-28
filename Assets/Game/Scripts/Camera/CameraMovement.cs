using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _cameraPosition;


    private void FixedUpdate()
    {
        Vector3 newPosition = _player.position + _cameraPosition;
        transform.position = Vector3.Lerp(transform.position, newPosition, _speed * Time.deltaTime);
    }
}
