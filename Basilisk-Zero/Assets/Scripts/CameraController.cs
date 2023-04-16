using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    private PlayerController playerTarget;
    CinemachineVirtualCamera vc;

    // Start is called before the first frame update
    void Start()
    {
        playerTarget = FindObjectOfType<PlayerController>();
        vc = GetComponent<CinemachineVirtualCamera>();

        vc.Follow = playerTarget.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
