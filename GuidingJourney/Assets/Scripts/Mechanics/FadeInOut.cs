using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    [Header("Component References")]
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject fadeImage;

    private void Awake()
    {
        fadeImage.SetActive(false);
    }

    private void ActivateStartFade()
    {
        anim.SetTrigger("StartFade");
        fadeImage.SetActive(true);
    }

    private void ActivateEndFade()
    {
        anim.SetTrigger("EndFade");
    }

    public void ResetFade()
    {
        fadeImage.SetActive(false);
        anim.SetTrigger("IdleFade");
    }

    private void OnEnable()
    {
        PlayerInteractions.StartFadeEvent += ActivateStartFade;
        PlayerInteractions.EndFadeEvent += ActivateEndFade;
    }

    private void OnDisable()
    {
        PlayerInteractions.StartFadeEvent -= ActivateStartFade;
        PlayerInteractions.EndFadeEvent -= ActivateEndFade;
    }
}