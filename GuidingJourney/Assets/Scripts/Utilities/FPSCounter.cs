using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    [SerializeField] private Text fpsDisplay;
    [SerializeField] private Text averageFPSDisplay;
    [SerializeField] private Text minFPSDisplay;
    [SerializeField] private Text maxFPSDisplay;

    private int framesPassed = 0;
    private float fpsTotal = 0f;
    private float minFPS = Mathf.Infinity;
    private float maxFPS = 0f;

    //On Awake, Set framerate to 60
    private void Awake() 
    {
        Application.targetFrameRate = 60;
    }

    private void Update() 
    {
        //Calculate FPS
        float _fps = 1 / Time.unscaledDeltaTime;
        fpsDisplay.text = "FPS: " + Mathf.Round(_fps);

        //Calculate Average FPS
        fpsTotal += _fps;
        framesPassed++;
        averageFPSDisplay.text = "FPS Average: " + Mathf.Round(fpsTotal / framesPassed);

        //Calculate maximum FPS
        if (_fps > maxFPS && framesPassed > 10) {
            maxFPS = _fps;
            maxFPSDisplay.text = "FPS Max: " + Mathf.Round(maxFPS);
        }


        //Calculate minimum FPS
        if (_fps < minFPS && framesPassed > 10) {
            minFPS = _fps;
            minFPSDisplay.text = "FPS Min: " + Mathf.Round(minFPS);
        }
    }
}