///<summary>
///Script that handles the functionality of the torchlight
///</summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torchlight : MonoBehaviour
{
    [SerializeField] float intensityDecay = 0.1f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minAngle = 40;
    Light light;
    [SerializeField] AudioClip clip;
    [SerializeField] Canvas canvas;

    private void Start()
    {
        light = GetComponent<Light>();
        light.enabled = false;
        canvas.enabled = true;
        Time.timeScale = 0;
        Cursor.visible = false;
    }

    private void Update()
    {
        ToggleLight();
        if(light.enabled)
        {
            DecreaseLightAngle();
            DecreaseLightIntensity();
        }
    }

    private void ToggleLight()
    {
        if(Input.GetKeyDown("f") || Mathf.Round(Input.GetAxisRaw("Torch")) > 0)
        {
            if(canvas.enabled == true)
            {
                canvas.enabled = false;
                Time.timeScale = 1;
            }
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

    private void DecreaseLightAngle()
    {
        if(light.spotAngle <= minAngle)
        {
            return;
        }
        light.spotAngle -= angleDecay * Time.deltaTime;
    }

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
}
