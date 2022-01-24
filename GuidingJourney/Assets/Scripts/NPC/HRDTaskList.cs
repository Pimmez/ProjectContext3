using Extensions.Generics.Singleton;
using UnityEngine;
using System;

public class HRDTaskList : GenericSingleton<HRDTaskList, HRDTaskList>
{
    [Header("Component References")]
    [SerializeField] private GameObject targetObject = null;
    [SerializeField] private AudioClip sfxClip = null;
    

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

    //Action Events
    public static Action<bool> GrabbedItemEvent;
    public static Action<bool> AfterCaveTalkEvent;
    public static Action<bool> Task3AEvent;
    public static Action<bool> Task3BEvent;
    public static Action<bool> Task3CEvent;
    public static Action<bool> CampSiteEvent;

    //Privates
    private bool completedTaskBag = false;

    private void Start()
    {
        DialogueManager.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (completedTaskBag == false)
        {
            if (Vector3.Distance(targetObject.transform.position, transform.position) < minRange)
            {
                completedTaskBag = true;
                Destroy(targetObject);
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
    }

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
        if (Task3BEvent != null && _taskType == 1)
        {
            Task3BEvent(true);
        }
    }

    private void Task3CComplete(int _taskType)
    {
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