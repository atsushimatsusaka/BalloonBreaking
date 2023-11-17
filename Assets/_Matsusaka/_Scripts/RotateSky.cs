using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSky : MonoBehaviour
{
    // Start is called before the first frame update

    private Material skyMt;
    private float iniRot;
    [SerializeField] private float rotateSpeed = 1f;

    void Start()
    {
        skyMt = RenderSettings.skybox;
        iniRot = skyMt.GetFloat("_Rotation");
    }

    // Update is called once per frame
    void Update()
    {
        var rot = Mathf.Repeat(skyMt.GetFloat("_Rotation") + rotateSpeed, 360f);

        skyMt.SetFloat("_Rotation", rot);
    }

    private void OnApplicationQuit()
    {
        skyMt.SetFloat("_Rotation", iniRot);
    }
}
