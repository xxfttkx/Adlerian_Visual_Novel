using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventHandler
{
    public static event Action AddItemEvent;
    public static void CallAddItemEvent()
    {
        AddItemEvent?.Invoke();
    }
}