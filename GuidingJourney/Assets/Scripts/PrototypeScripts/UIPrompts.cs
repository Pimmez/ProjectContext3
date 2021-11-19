using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class UIPrompts : MonoBehaviour
{
    [SerializeField] private GameObject text_input;
    [SerializeField] private GameObject text_npcTalk;
    [SerializeField] private GameObject text_GrabObject;
    [SerializeField] private GameObject text_presskey;
    [SerializeField] private GameObject text_finish;

    [SerializeField] private GameObject warpWall;
    [SerializeField] private Camera Maincam;
    [SerializeField] private Camera sideCam;

    [SerializeField] private NavMeshAgent navMeshPlayer = null;
    [SerializeField] private TestCharacterController charControllerPlayer = null;

    private bool onlyOnce = false;
    private bool DoCameraOnce = false;
    private bool doOnce = false;


    [SerializeField] private Animator anim;
    [SerializeField] private Animator selfAnim;

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
        warpWall.SetActive(false);
    }

    private void Update()
    {
        if (!onlyOnce)
        {
            if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Vertical") > 0 || Input.GetMouseButtonDown(0))
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
        selfAnim.SetBool("isWaving", true);
        text_npcTalk.SetActive(true);
        text_input.SetActive(false);
        text_GrabObject.SetActive(false);
        text_presskey.SetActive(false);
        text_finish.SetActive(false);
    }

    private void NPCGetObject()
    {
        if (!DoCameraOnce)
        {
            if (navMeshPlayer != null)
                navMeshPlayer.speed = 0;

            if (charControllerPlayer != null)
                charControllerPlayer.moveSpeed = 0;
            selfAnim.SetBool("isWaving", false);

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

        if (navMeshPlayer != null)
            navMeshPlayer.speed = 30;

        if (charControllerPlayer != null)
            charControllerPlayer.moveSpeed = 40;

        warpWall.SetActive(true);
        text_GrabObject.SetActive(false);
        text_presskey.SetActive(false);
        text_input.SetActive(false);
        text_npcTalk.SetActive(false);
        text_finish.SetActive(false);
    }

    private void GrabObjectInfo()
    {
        if (!doOnce)
        {
            text_presskey.SetActive(true);
            doOnce = true;
        }
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
        
        if (navMeshPlayer != null)
            navMeshPlayer.speed = 0;

        if (charControllerPlayer != null)
            charControllerPlayer.moveSpeed = 0;

        StartCoroutine("Ending");
    }

    private IEnumerator Ending()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("EndDemoScene");
    }


    private void OnEnable()
    {
        HRDRadius.OnWalkEvent += NPCGetObject;
        ClickObject.isNearObjectEvent += GrabObjectInfo;
        PressToGrab.isNearObjectEvent += GrabObjectInfo;
        HRDRadius.FinishEvent += FinishPrototype;
    }

    private void OnDisable()
    {
        HRDRadius.OnWalkEvent -= NPCGetObject;
        ClickObject.isNearObjectEvent -= GrabObjectInfo;
        PressToGrab.isNearObjectEvent -= GrabObjectInfo;
        HRDRadius.FinishEvent -= FinishPrototype;
    }
}