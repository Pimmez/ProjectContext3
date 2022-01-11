using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class UIButtonSoundEvent : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    [SerializeField] private AudioClip hoverSound = null;
    [SerializeField] private AudioClip clickSound = null;

    public void OnPointerEnter(PointerEventData ped)
    {
        SoundManager.Instance.Play(hoverSound);
    }

    public void OnPointerDown(PointerEventData ped)
    {
        SoundManager.Instance.Play(clickSound);
    }
}
