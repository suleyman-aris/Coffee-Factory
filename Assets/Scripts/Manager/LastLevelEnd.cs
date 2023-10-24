using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastLevelEnd : MonoBehaviour
{
    void Start()
    {
        MatchCMList.matchCMList.lastLevelCount += MatchCMList_lastLevelCount;
    }

    private void MatchCMList_lastLevelCount(int obj)
    {
        if (obj >= 16)
        {
            YsoCorp.GameUtils.YCManager.instance.OnGameFinished(true);
        }
    }
}
