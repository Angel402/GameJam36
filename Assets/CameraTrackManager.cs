using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraTrackManager : MonoBehaviour
{
    [SerializeField]
    private CinemachineBrain mainCam;

    [SerializeField]
    private CinemachineVirtualCamera[] cameraStopPoints;

    private int currentPointIndex;

    private void Start()
    {
        currentPointIndex = 0;
    }

    private void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            AdvanceCamera();
        }
    }

    public void AdvanceCamera()
    {
        if (currentPointIndex == cameraStopPoints.Length - 1)
        {
            Debug.Log("Already at last point.");
            return;
        }
        cameraStopPoints[currentPointIndex].Priority = 0;

        currentPointIndex++;
        cameraStopPoints[currentPointIndex].Priority = 10;
    }

    public void PreviousPoint()
    {
        cameraStopPoints[currentPointIndex].Priority = 0;

        currentPointIndex--;
        cameraStopPoints[currentPointIndex].Priority = 10;
    }

    public void GotToPoint(int index)
    {
        cameraStopPoints[currentPointIndex].Priority = 0;

        currentPointIndex = index;
        cameraStopPoints[currentPointIndex].Priority = 10;
    }

    private void InitializeCameraPriority()
    {
        for(int i = 0; i < cameraStopPoints.Length; i++)
        {
            cameraStopPoints[i].Priority = 0;
        }
        cameraStopPoints[0].Priority = 10;
    }
}
