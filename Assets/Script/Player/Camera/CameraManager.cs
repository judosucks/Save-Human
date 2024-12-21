using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    public NewCamera newCamera;
    private CinemachineBrain brain;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance.gameObject);
        }
        else
        {
            instance = this;
        }

        if (newCamera == null)
        {
            Debug.Log("newcamera is null");
            newCamera = GameObject.FindWithTag("Camera").GetComponent<NewCamera>();
            Debug.Log("newcamera"+newCamera);
        }else if(newCamera != null)
        {
            Debug.Log("newcamera is not null");
        }

        brain = newCamera.GetComponent<CinemachineBrain>();
        if (brain == null)
        {
            Debug.LogError("CinemachineBrain is null");
        }
    }
    public void AdjustGrenadeCameraScreenX(float targetScreenX, float smoothTime)
    {
        if (newCamera != null)
        {
            newCamera.SetScreenX(newCamera.grenadeCamera, targetScreenX, smoothTime);
        }
    }

    public void AdjustPlayerCameraScreenX(float targetScreenX, float smoothTime)
    {
        if (newCamera != null)
        {
            
            newCamera.SetScreenX(newCamera.playerCamera, targetScreenX, smoothTime);
        }
    }

    public CinemachineVirtualCamera GetCurrentActiveCamera()
    {
        if (brain != null && brain.ActiveVirtualCamera is CinemachineVirtualCamera activeVirtualCamera)
        {
            return activeVirtualCamera;
        }
        return null; // no active camera
    }
}
