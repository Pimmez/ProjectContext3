using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPrompts : MonoBehaviour
{
    [SerializeField] private GameObject text_input;
    [SerializeField] private GameObject text_npcTalk;
    [SerializeField] private GameObject text_GrabObject;
    [SerializeField] private GameObject text_presskey;
    [SerializeField] private GameObject text_finish;


    [SerializeField] private Camera Maincam;
    [SerializeField] private Camera sideCam;

    private bool onlyOnce = false;
    private bool DoCameraOnce = false;

    [SerializeField] private Animator anim;

    // Start is called before the first frame update
    private void Awake()
    {
        Maincam.enabled = true;
        sideCam.enabled = false;
        text_input.SetActive(true);
        text_npcTalk.SetActive(false);
        text_GrabObject.SetActive(false);
        text_presskey.SetActive(false);
        text_finish.SetActive(false);
    }

    private void Update()
    {
        if(!onlyOnce)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S))
            {
                text_input.SetActive(false);
                onlyOnce = true;
                NPCTalk();
            }
        }        
    }

    //EVENTS
    private void NPCTalk()
    {
        text_npcTalk.SetActive(true);
        text_input.SetActive(false);
        text_GrabObject.SetActive(false);
        text_presskey.SetActive(false);
        text_finish.SetActive(false);

    }

    private void NPCGetObject()
    {
        if(!DoCameraOnce)
        {
            text_GrabObject.SetActive(true);
            text_input.SetActive(false);
            text_npcTalk.SetActive(false);
            text_presskey.SetActive(false);
            text_finish.SetActive(false);


            Maincam.enabled = false;
            sideCam.enabled = true;

            //play camera animation
            anim.SetBool("CanPlayCameraAnim", true);
            DoCameraOnce = true;
        }
    }

    public void CameraDoneAnimated()
    {
        Maincam.enabled = true;
        sideCam.enabled = false;
        text_GrabObject.SetActive(false);
        text_presskey.SetActive(false);
        text_input.SetActive(false);
        text_npcTalk.SetActive(false);
        text_finish.SetActive(false);


    }

    private void GrabObjectInfo()
    {
        text_presskey.SetActive(true);
        text_input.SetActive(false);
        text_npcTalk.SetActive(false);
        text_GrabObject.SetActive(false);
        text_finish.SetActive(false);

    }

    private void FinishPrototype()
    {
        text_finish.SetActive(true);
        text_presskey.SetActive(false);
        text_input.SetActive(false);
        text_npcTalk.SetActive(false);
        text_GrabObject.SetActive(false);
    }

    private void OnEnable()
    {
        HRDRadius.OnWalkEvent += NPCGetObject;
        PressToGrab.isNearObjectEvent += GrabObjectInfo;
        HRDRadius.FinishEvent += FinishPrototype;
    }

    private void OnDisable()
    {
        HRDRadius.OnWalkEvent -= NPCGetObject;
        PressToGrab.isNearObjectEvent -= GrabObjectInfo;
        HRDRadius.FinishEvent -= FinishPrototype;
    }
}