// code from https://forum.unity.com/threads/how-to-know-video-player-is-finished-playing-video.483935/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoIsOver : MonoBehaviour {
	// When the video is finished playing, the last frame remains visible.
	// So, disable the video player when the video is finished.

	public VideoPlayer vid;
	public GameObject credits;

	void Start(){vid.loopPointReached += isOver;}

	void isOver(UnityEngine.Video.VideoPlayer vp)
	{
		print  ("Video Is Over");
		vp.enabled = false;
		credits.SetActive (true);
	}

}