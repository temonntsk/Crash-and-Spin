using UnityEngine;

public class Grenade : Ammunition
{
    [SerializeField] private float _height;

    private Vector3 _dropPoint;
    private Vector3 _midpoint;

    private void Update()
    {
        TangentialFlight();
    }

    public void TakeDropPoint(Vector3 dropPoint)
    {
        _dropPoint = dropPoint;
        _midpoint = (_dropPoint - transform.position) / 2;
    }

    private void TangentialFlight()
    {
        // transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        transform.RotateAround(_dropPoint, _midpoint, _height * Time.deltaTime);


        if (_dropPoint == transform.position)
        {
            gameObject.SetActive(false);
        }
    }
}
