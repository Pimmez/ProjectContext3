using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonSoundEvent : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    [Header("Audio References")]
    [SerializeField] private AudioClip hoverSound = null;
    [SerializeField] private AudioClip clickSound = null;

    public void OnPointerEnter(PointerEventData _ped)
    {
        SoundManager.Instance.Play(hoverSound);
    }

    public void OnPointerDown(PointerEventData _ped)
    {
        SoundManager.Instance.Play(clickSound);
    }
}