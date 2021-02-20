using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Shows a placeholder canvas saying a day has passed
/// </summary>
public class EndDay : MonoBehaviour
{
    [SerializeField] Canvas promptCanvas;
    [SerializeField] Canvas dayEndCanvas;
    [SerializeField] GameObject activeObjective;
    [SerializeField] TextMeshProUGUI objectiveText;
    bool coroutineStarted = false;
    [SerializeField] Light directionalLight;

    private void Update()
    {
        if(promptCanvas.enabled && !coroutineStarted)
        {
            if (Input.GetMouseButtonDown(1) || Mathf.Round(Input.GetAxisRaw("Fire2")) < 0)
            {
                coroutineStarted = true;
                StartCoroutine(StartNextDay());
            }
        }
    }

    IEnumerator StartNextDay()
    {
        dayEndCanvas.enabled = true;
        promptCanvas.enabled = false;
        Time.timeScale = 0;
        AudioListener.pause = true;

        yield return new WaitForSecondsRealtime(5);

        dayEndCanvas.enabled = false;
        promptCanvas.enabled = false;
        Time.timeScale = 1;
        AudioListener.pause = false;
        objectiveText.enabled = true;
        objectiveText.text = "Go back to the office";
        directionalLight.intensity = 1.46f;
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        print(activeObjective.GetComponent<BoxCollider>().enabled);
        if(activeObjective.GetComponent<BoxCollider>().enabled)
        {
            print("youre in");
            objectiveText.enabled = false;
            promptCanvas.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        promptCanvas.enabled = false;
    }
}
