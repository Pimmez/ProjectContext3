using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ElinahCutsceneTrigger : MonoBehaviour
{
    //public VideoPlayer vid;
    //public GameObject vidCanvas;
    public GameObject pigeonActivation;
    public GameObject emptystamp;

    //Reference to Dialogue Script
    // public Waypoints waypoints;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tags.NPC)
        {
            GlobalVideoPlayer.Instance.PlayVideo("Cutscene2.mp4", true);
            pigeonActivation.SetActive(true);

            HRDTaskList.Instance.ClickBagTextActive = true;

            /*
            vid.url = System.IO.Path.Combine(Application.streamingAssetsPath, "Cutscene2.mp4");
            vid.Play();

            vid.loopPointReached += CheckOver;
            */
        }
    }
}