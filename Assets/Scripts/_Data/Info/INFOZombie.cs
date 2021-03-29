using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class INFOZombie
{
    public Enum.eZombieStatus eStatus;
    public Enum.eCondition eCondition;
    public Enum.eCompleteStatus? eComplete = null;
    public int cur_deadline_second;
    public int cur_calm_down;
    public int cur_training_point;
    public int required_training_point;
    public DateTime? releaseDate = null;
}
