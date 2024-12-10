using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueData
{
    public int iIndex;
    public string strText;
    public int strName;
    public List<int> tSprites;
    public List<int> tPositions;
    public int strBackground;

    
    // select
    public List<int> tSelections;
    public List<int> tNextIndexes;
    public int iNextIndex;
}