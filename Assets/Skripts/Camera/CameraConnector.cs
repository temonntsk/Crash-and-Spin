using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class CameraConnector : MonoBehaviour
{
    private Camera _playerCamera;
    private Canvas _canvas;

    private void Awake()
    {
        _canvas = GetComponent<Canvas>();
        _playerCamera = FindFirstObjectByType<Camera>();

        _canvas.worldCamera = _playerCamera;
    }

}
