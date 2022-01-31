using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Extensions.Generics.Singleton;
using UnityEngine.Video;

public class GlobalVideoPlayer : GenericSingleton<GlobalVideoPlayer, GlobalVideoPlayer>
{
    public VideoPlayer vid;
    public GameObject vidCanvas;

    public void PlayVideo(string _streamingAssetFile, bool _checkAfterPlaying)
    {
        GameManager.Instance.isGamePaused = true;
        vidCanvas.SetActive(true);


        vid.url = System.IO.Path.Combine(Application.streamingAssetsPath, _streamingAssetFile);
        vid.Play();

        if(_checkAfterPlaying)
        {
            vid.loopPointReached += AfterPlaying;
        }
    }

    private void AfterPlaying(UnityEngine.Video.VideoPlayer vp)
    {
        GameManager.Instance.isGamePaused = false;
        vid.clip = null;
        vidCanvas.SetActive(false);

        //Debug.Log("Video Is Over");
    }
}