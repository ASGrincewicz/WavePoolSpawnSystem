using System.Collections.Generic;
using UnityEngine;
public class LineTesting : MonoBehaviour
{
    [SerializeField] private List<Transform> _points = new List<Transform   >();
    [SerializeField] private LineController _lineController;

    

    private void Start()
    {
        _lineController.SetupLine(_points);
    }
}
