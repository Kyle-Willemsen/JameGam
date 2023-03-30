using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamShake : MonoBehaviour
{

    public static CamShake Instance { get; private set; }
    private CinemachineVirtualCamera virtCam;
    private float shakeTimer;

    private void Awake()
    {
        Instance = this;
        virtCam = GetComponent<CinemachineVirtualCamera>();
    }

    public void StartShake(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin perlin = virtCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        perlin.m_AmplitudeGain = intensity;
        shakeTimer = time;
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer < 0f)
            {
                CinemachineBasicMultiChannelPerlin perlin = virtCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                perlin.m_AmplitudeGain = 0f;
            }
        }
    }
}
