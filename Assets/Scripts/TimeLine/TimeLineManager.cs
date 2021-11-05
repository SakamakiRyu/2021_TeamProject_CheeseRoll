using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
public class TimeLineManager : MonoBehaviour
{
    [SerializeField]
    List<PlayableDirector> _playableDirectorList = new List<PlayableDirector>();


   public void PlayTimeLine(int index)
    {
        _playableDirectorList[index].Play();
    }
    
}
