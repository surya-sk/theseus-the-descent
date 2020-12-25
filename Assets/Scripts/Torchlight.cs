///<summary>
///Script that handles the functionality of the torchlight
///</summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torchlight : MonoBehaviour, ISaveable
{
    [SerializeField] float intensityDecay = 0.1f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minAngle = 40;
    Light light;
    [SerializeField] AudioClip clip;
    [SerializeField] Canvas torchCanvas;
    bool disableTorchCanvas;

    private void Start()
    {
        light = GetComponent<Light>();
        light.enabled = false;
        print(disableTorchCanvas);
    }

    private void Update()
    {
        ToggleLight();
        if(light.enabled)
        {
            DecreaseLightAngle();
            DecreaseLightIntensity();
        }
        if (!disableTorchCanvas)
        {
            torchCanvas.enabled = true;
            if (Input.GetKeyDown("f") || Mathf.Round(Input.GetAxisRaw("Torch")) > 0)
            {
                disableTorchCanvas = true;
            }
        }
        else
        {
            torchCanvas.enabled = false;
        }
    }

    /// <summary>
    /// Toggle the torchlight on and off based on input
    /// </summary>
    private void ToggleLight()
    {
        if(Input.GetKeyDown("f") || Mathf.Round(Input.GetAxisRaw("Torch")) > 0)
        {
            AudioSource.PlayClipAtPoint(clip, gameObject.transform.position);
            if(light.enabled)
            {
                light.enabled = false;
            }
            else
            {
                light.enabled = true;
            }
        }
    }

    /// <summary>
    /// Decrease the light angle over time
    /// </summary>
    private void DecreaseLightAngle()
    {
        if(light.spotAngle <= minAngle)
        {
            return;
        }
        light.spotAngle -= angleDecay * Time.deltaTime;
    }

    /// <summary>
    /// Decrease the light intensity over time
    /// </summary>
    private void DecreaseLightIntensity()
    {
        light.intensity -= intensityDecay * Time.deltaTime;
    }

    public void ResetLightAngle(float restoreAmount)
    {
        light.spotAngle = restoreAmount;
    }

    public void ResetLightIntensity(float intensityAmount)
    {
        light.intensity = intensityAmount;
    }

    public object CaptureState()
    {
        return disableTorchCanvas;
    }

    public void RestoreState(object state)
    {
        disableTorchCanvas = (bool)state;
    }
}
