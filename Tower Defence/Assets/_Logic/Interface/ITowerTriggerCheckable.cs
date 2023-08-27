using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITowerTriggerCheckable
{
    bool isWithinAttackRange { get; set; }

    void SetAttackRangeBool(bool withinAttackRange);
}
