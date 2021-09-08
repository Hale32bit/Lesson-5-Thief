using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface ISensor
{
    event Action<GameObject> TriggeredUp;
    event Action<GameObject> TriggeredDown;
}