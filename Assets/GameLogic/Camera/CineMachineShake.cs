using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CineMachineShake : MonoBehaviour
{

    public static CineMachineShake Instance { get; private set; }


    private CinemachineVirtualCamera virtualCamera;
    private float shakeTimer;
    private float shakeTimeTotal;
    private float startingIntensity;
    private void Awake()
    {
        Instance = this;
        virtualCamera = GetComponent<CinemachineVirtualCamera>();   
    }
    
    public void ShakeCamera(float intensity, float time)
    {

        CinemachineBasicMultiChannelPerlin basicPerlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        basicPerlin.m_AmplitudeGain = intensity;

        startingIntensity = intensity;

        shakeTimeTotal = time;
        shakeTimer = time;
    }

    // Update is called once per frame
    void Update()
    {
        if(shakeTimer> 0)
        {
            shakeTimer -= Time.deltaTime;
            CinemachineBasicMultiChannelPerlin basicPerlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            basicPerlin.m_AmplitudeGain = Mathf.Lerp(startingIntensity, 0f, 1 - (shakeTimer / shakeTimeTotal));




        }
    }
}
