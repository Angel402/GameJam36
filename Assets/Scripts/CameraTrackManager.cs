using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class CameraTrackManager : MonoBehaviour
{
    [SerializeField] private Transform mainCam;
    [SerializeField] private List<CameraPoint> cameraPoints;
 
    [Serializable]
    public class CameraPoint
    {
        public float transitionTime = 1;
        public Transform point;
        public Ease ease = Ease.OutSine;
    }

    private void Start()
    {
        StartCoroutine(CameraTrack());
        
    }

    private IEnumerator CameraTrack()
    {
        foreach (var cameraPoint in cameraPoints)
        {
            mainCam.DOMove(cameraPoint.point.position, cameraPoint.transitionTime)
                .SetEase(cameraPoint.ease);
            mainCam.DORotate(cameraPoint.point.eulerAngles, cameraPoint.transitionTime)
                .SetEase(cameraPoint.ease);
            yield return new WaitForSeconds(cameraPoint.transitionTime);
        }
    }
    /*
    [SerializeField]
    private CinemachineVirtualCamera[] cameraStopPoints;
    private int currentPointIndex;

    private void Start()
    {
        currentPointIndex = 0;
    }

    private void Update()
    {
        
        /*if(Input.GetKeyDown(KeyCode.Space))
        {
            AdvanceCamera();
        }#1#
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

    [Tooltip("Change how many seconds it takes to move between cameras")]
    public void ChangeCameraSpeed(float seconds)
    {
        mainCam.m_DefaultBlend.m_Time = seconds;
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
    }*/
}
