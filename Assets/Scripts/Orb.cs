using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Orb : MonoBehaviour
{
    public Canvas promptCanvas;
    public Canvas imageCanvas;
    public Image fadeOutImage;
    bool inArea = false;
    float countdown = 10;
    bool startTimer = false;
    public AudioSource explosionClip;

    private void Start()
    {
        promptCanvas.enabled = false;
        imageCanvas.enabled = false;
        fadeOutImage.canvasRenderer.SetAlpha(0.0f);
    }
    private void Update()
    {
        if(inArea)
        {
            if (Input.GetMouseButtonDown(1) || Mathf.Round(Input.GetAxisRaw("Fire2")) < 0)
            {
                imageCanvas.enabled = true;
                fadeOutImage.CrossFadeAlpha(1, 2, false);
                if(!explosionClip.isPlaying)
                {
                    explosionClip.Play();
                }
                startTimer = true;
            }
        }

        if(startTimer)
        {
            if(countdown > 0)
            {
                countdown -= Time.deltaTime;
            }
            else
            {
                File.Delete(Path.Combine(Application.persistentDataPath, "The End.sav"));
                SceneManager.LoadScene(9);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            promptCanvas.enabled = true;
            inArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            promptCanvas.enabled = false;
            inArea = false;
        }
    }
}
