using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatModType
{
    FLAT,
    PERCENT,
    FULLPERCENT
}

//Full percent is for stats like critical hit that are only in percentage

public enum TargetStat
{
    HEALTH,
    ENERGY,
    ATTACK,
    DEFENSE,
    ATTACKSPEED,
    CRITCHANCE
}


[System.Serializable]
public class CharacterStatModifier 
{
    public float value;
    public StatModType modType;
    public int order;
    public object source;
    public TargetStat targetStat;


    public CharacterStatModifier(float v, StatModType type, int ord, object src, TargetStat trgt)
    {
        value = v;
        modType = type;
        order = ord;
        source = src;
        targetStat = trgt;
    }

    public CharacterStatModifier(float v, StatModType type, TargetStat trgt) : this(v, type, (int)type, null, trgt) { }

    public CharacterStatModifier(float v, StatModType type, int ord, TargetStat trgt) : this(v,  type, ord, null, trgt) { }

    public CharacterStatModifier(float v, StatModType type, object src, TargetStat trgt) : this(v,  type, (int)type, src, trgt) { }
}

