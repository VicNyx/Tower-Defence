using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyTriggerCheckable
{
    bool isAggroed { get; set; }
    bool isWithinStrikingDistance { get; set; }

    void SetAggroStatus(bool aggroed);
    void SetStrikingDistanceBool(bool withinStrikingDistance);
}
