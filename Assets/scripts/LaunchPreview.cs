using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPreview : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector3 pushStartPosition;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void SetStartPoint(Vector3 worldPoint)
    {
        pushStartPosition = worldPoint;
        lineRenderer.SetPosition(0, pushStartPosition);
    }

    public void SetEndPoint(Vector3 worldPoint) //이건 나중에 제거할필요있으면 제거 ㄱ
    {
        Vector3 pointoffset = worldPoint - pushStartPosition;
        Vector3 endPoint = transform.position + pointoffset;//여기 !

        lineRenderer.SetPosition(1, endPoint);
    }

}
