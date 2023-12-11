using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class WayPointsMovement
{
    private List<Vector3> _pointsPosition;
    private float _maxNumberDirection = 3;
    private float _minNumberDirection = -3;

    public WayPointsMovement(int countWayPoint, Vector3 EnemyTransform) => FillPointsPosition(countWayPoint, EnemyTransform);

    private void FillPointsPosition(int countWayPoint, Vector3 EnemyPosition)
    {
        _pointsPosition = new List<Vector3>();

        for (int i = 0; i < countWayPoint; i++)
        {
            Vector3 newPosition = EnemyPosition + new Vector3(UnityEngine.Random.Range(_minNumberDirection, _maxNumberDirection), 0, UnityEngine.Random.Range(_minNumberDirection, _maxNumberDirection));

            _pointsPosition.Add(newPosition);
        }
    }

    public Vector3 GetRandomWayPoint()
    {
        System.Random random = new System.Random();

        return _pointsPosition[random.Next(_pointsPosition.Count)];
    }
}
