using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LineController : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private List<Transform> _points = new List<Transform>();

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }
    private void Update()
    {
        for(int i = 0; i< _points.Count; i++)
        {
            _lineRenderer.SetPosition(i, _points[i].position);
        }
    }
    public void SetupLine(List<Transform> points)
    {
        _lineRenderer.positionCount = points.Count;
        _points = points;
    }
}

