using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;
    
    
    WebCamTexture camTexture;

    public RawImage cameraViewImage;

    private void Awake()
    {
        Instance = this;
    }
    public void CameraOn()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
        {
            Permission.RequestUserPermission(Permission.Camera);
        }

        if (WebCamTexture.devices.Length == 0)
        {
            Debug.Log("no camera!");
            return;
        }

        WebCamDevice[] devices = WebCamTexture.devices;
        int selectedCameraIndex = -1;

        print(devices.Length);

        for(int i = 0; i < devices.Length; i++)
        {
            if(devices[i].isFrontFacing == false)
            {
                selectedCameraIndex = i;
                break;
            }

         
        }

        Debug.Log(selectedCameraIndex);
        if(selectedCameraIndex >= 0)
        {
            Debug.Log("no camera!");
            camTexture = new WebCamTexture(devices[selectedCameraIndex].name);
            camTexture.requestedFPS = 30;
            cameraViewImage.texture = camTexture;
            camTexture.Play();
        }
    }

    public void CameraOff()
    {
        if(camTexture != null)
        {
            camTexture.Stop();
            WebCamTexture.Destroy(camTexture);
            camTexture = null;
        }
    }
}
