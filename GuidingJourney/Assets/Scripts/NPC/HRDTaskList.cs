using Extensions.Generics.Singleton;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class HRDTaskList : GenericSingleton<HRDTaskList, HRDTaskList>
{
    [Header("Component References")]
    [SerializeField] private GameObject backpackObject = null;
    [SerializeField] private GameObject targetObject = null;
    //[SerializeField] private VideoPlayer vid;
    //[SerializeField] private GameObject vidCanvas;

    [SerializeField] private GameObject digTrigger1;
    [SerializeField] private GameObject digTrigger2;


    [SerializeField] private AudioClip sfxClip = null;
    [SerializeField] private GameObject backpack = null;

    [Header("Range Value")]
    [SerializeField] private float minRange = 200f;

    public GameObject DialogueManager = null;
    public GameObject D_Character = null;
    public GameObject D_Printer = null;

    public ElinahDialogue dialogueElinah;
    public bool SetTutorialTextActive = false;
    public bool SetCaveTextActive = false;
    public bool SetWeirdVoicesActive = false;
    public bool ForestTextActive = false;
    public bool DoForestTextOnce = true;

    public bool ClickBagTextActive = false;
    public bool LetterTextActive = false;
    
    //Action Events
    public static Action<bool> GrabbedItemEvent;
    public static Action<bool> AfterCaveTalkEvent;
    public static Action<bool> Task3AEvent;
    public static Action<bool> Task3BEvent;
    public static Action<bool> Task3CEvent;
    public static Action<bool> CampSiteEvent;

    public static Action<bool> ClickBagEvent;
    public static Action<bool> LetterEvent;

    //Privates
    private bool completedTaskBag = false;

    private void Start()
    {
        backpack.SetActive(false);
        DialogueManager.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (completedTaskBag == false)
        {
            if (Vector3.Distance(backpackObject.transform.position, transform.position) < minRange)
            {
                completedTaskBag = true;
                backpackObject.SetActive(false);
                backpack.SetActive(true);
                SoundManager.Instance.Play(sfxClip);
                GameManager.Instance.isHoldingObject = false;
                if (completedTaskBag)
                {
                    dialogueElinah.AfterCaveDialogue();

                    if (GrabbedItemEvent != null)
                    {
                        GrabbedItemEvent(true);
                    }
                }
            }
        }

        if (GameManager.Instance.isLetterFound == true)
        {
            if (Vector3.Distance(targetObject.transform.position, transform.position) < minRange)
            {
                SceneManager.LoadScene("Cinematic_2Scene");
                /*
                GameManager.Instance.isGamePaused = true;
                
                //Debug.Log("BEFORE VideoPlayer now playing: " + vid.clip.name.);
                //Debug.Log("BEFORE vidcanvas active?: " + vidCanvas.activeSelf);
                //Debug.Log("BEFORE Videoplayer active?" + vid.enabled);
                //Debug.Log("BEFORE StreamingAsset Path: " + Application.streamingAssetsPath);

                SoundManager.Instance.Play(sfxClip);
                GameManager.Instance.isHoldingObject = false;

                vidCanvas.SetActive(true);
                vid.url = System.IO.Path.Combine(Application.streamingAssetsPath, "Cutscene4.mp4");

                Debug.Log("COME ON VIDEO JUST PLAY");
                vid.Play();

                //Debug.Log("VideoPlayer now playing: " + vid.clip.name);
                //Debug.Log("vidcanvas active?: " + vidCanvas.activeSelf);
                //Debug.Log("Videoplayer active?" + vid.enabled);
                //Debug.Log("StreamingAsset Path: " + Application.streamingAssetsPath);


                //Debug.Log("playing cutscene 4");

                vid.loopPointReached += NextVideo;
                */
            }
        }
    }

    /*
    private void NextVideo(UnityEngine.Video.VideoPlayer vp)
    {
        vid.url = System.IO.Path.Combine(Application.streamingAssetsPath, "Cutscene5.mp4");
        vid.Play();
        Debug.Log("playing cutscene 5");

        vid.loopPointReached += EndGame;

        //Debug.Log("Video Is Over");
    }

    private void EndGame(UnityEngine.Video.VideoPlayer vp)
    {
        Debug.Log("clear, go to menu scene");

        GameManager.Instance.isGamePaused = false;
        GlobalVideoPlayer.Instance.vid.clip = null;
        vidCanvas.SetActive(false);

        SceneManager.LoadScene("Menuscene"); 
        //Debug.Log("Video Is Over");
    }
    */

    private void AfterCaveTalk()
    {
        if (AfterCaveTalkEvent != null)
        {
            AfterCaveTalkEvent(true);
        }
    }

    private void Task3AComplete(int _taskType)
    {
        if (Task3AEvent != null && _taskType == 0)
        {
            Task3AEvent(true);
        }
    }

    private void Task3BComplete(int _taskType)
    {
        digTrigger1.SetActive(true);
        if (Task3BEvent != null && _taskType == 1)
        {
            Task3BEvent(true);
        }
    }

    private void Task3CComplete(int _taskType)
    {
        digTrigger2.SetActive(true);
        if (Task3CEvent != null && _taskType == 2)
        {
            Task3CEvent(true);
        }
    }

    private void CampSiteComplete()
    {
        if (CampSiteEvent != null)
        {
            CampSiteEvent(true);
        }
    }

    private void ClickBagNow()
    {
        if (ClickBagEvent != null)
        {
            ClickBagEvent(true);
        }
    }

    private void LetterNow()
    {
        if (LetterEvent != null)
        {
            LetterEvent(true);
        }
    }

    private void OnEnable()
    {
        GrabStick.ActivateTaskEvent += Task3AComplete;
        GrabStick.ActivateTaskEvent += Task3BComplete;
        GrabStick.ActivateTaskEvent += Task3CComplete;
    }

    private void OnDisable()
    {
        GrabStick.ActivateTaskEvent -= Task3AComplete;
        GrabStick.ActivateTaskEvent -= Task3BComplete;
        GrabStick.ActivateTaskEvent -= Task3CComplete;
    }
}