using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITriggerCheckable
{
    bool isAggroed { get; set; }
    bool isTooClose { get; set; }

    void SetAggroStatus(bool isAggroed);
    void SetStopStatus(bool tooClose);
}
