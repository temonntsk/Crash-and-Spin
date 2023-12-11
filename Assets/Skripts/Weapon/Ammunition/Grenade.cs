using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Grenade : Ammunition
{
    private const float MaxPathPercentage = 1f; 

    [SerializeField] private float _flightHeight;

    private Vector3 _dropPoint;
    private float _distance;
    private float _startTime; 
    private float _currentDistance; 
    private float _pathPercentage; 
    private float _currentHeight; 

    private void Update()
    {
        TangentialFlight();
    }

    public void TakeDropPoint(Vector3 dropPoint)
    {
        _dropPoint = dropPoint;

        PrepareFlight();
    }

    private void PrepareFlight()
    {
        _distance = Vector3.Distance(transform.position, _dropPoint);
        _startTime = Time.time; 
    }

    private void TangentialFlight()
    {
        if (_dropPoint != null)
        {
            Flight�alculation();
          
            Fly();
        }

        if (_pathPercentage >= MaxPathPercentage)
        {
            gameObject.SetActive(false);
        }
    }

    private void Fly()
    {
        Vector3 tangent = (_dropPoint - transform.position).normalized;
        Vector3 newPosition = transform.position + (tangent * _currentDistance) + (Vector3.up * _currentHeight);

        transform.position = Vector3.MoveTowards(transform.position, newPosition, Time.deltaTime * Speed);
    }

    private void Flight�alculation()
    {
        _currentDistance = (Time.time - _startTime) * Speed;
        _pathPercentage = _currentDistance / _distance;
        _currentHeight = Mathf.Sin(_pathPercentage * Mathf.PI) * _flightHeight;
    }
}
