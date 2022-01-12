using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoHandle : MonoBehaviour
{
    public RawImage mScreen = null;
    public VideoPlayer mVideoPlayer = null;



    void Start()
    {
        if(mScreen != null && mVideoPlayer != null)
        {
            StartCoroutine(PrepareVideo());
        }
    }
    protected IEnumerator PrepareVideo()
    {
        mVideoPlayer.Prepare();
        while (!mVideoPlayer.isPrepared)
        {
            yield return new WaitForSeconds(0.5f);
        }
        mScreen.texture = mVideoPlayer.texture;
    }
    public void PlayVideo()
    {
        if(mVideoPlayer != null && mVideoPlayer.isPrepared)
        {
            mVideoPlayer.Play();
        }
    }
    public void StopVideo()
    {
        if(mVideoPlayer != null && mVideoPlayer.isPrepared)
        {
            mVideoPlayer.Stop();
        }
    }
}
