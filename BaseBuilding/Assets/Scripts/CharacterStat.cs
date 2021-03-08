using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterStat
{

    [SerializeField]
    private float baseValue;

    public float Value
    {
        get
        {
            if(isDirty || baseValue != lastBaseValue)
            {
                lastBaseValue = baseValue;
                _value = CalculateFinalValue();
                isDirty = false;
            }
            return _value;
        }
    }

    private bool isDirty = true;
    private float _value;
    private float lastBaseValue = float.MinValue;

    [SerializeField]
    private List<CharacterStatModifier> modifiers = new List<CharacterStatModifier>();

    public CharacterStat(float baseValue)
    {
        this.baseValue = baseValue;
        modifiers = new List<CharacterStatModifier>();
    }

    public float GetBaseValue()
    {
        return this.baseValue;
    }

    public void AddModifier(CharacterStatModifier mod)
    {
        isDirty = true;
        modifiers.Add(mod);
        modifiers.Sort(CompareModifierOrder);
    }

    private int CompareModifierOrder(CharacterStatModifier a, CharacterStatModifier b)
    {
        if (a.order < b.order)
        {
            return -1;
        }
        else if (a.order > b.order)
        {
            return 1;
        }
        else return 0;
    }

    public bool RemoveModifier(CharacterStatModifier mod)
    {
        if(modifiers.Remove(mod))
        {
            isDirty = true;
            return true;
        }
        return false;
    }

    public bool RemoveAllModifiersFromSource(object src)
    {
        bool didRemove = false;
        for(int i = modifiers.Count - 1; i >= 0; i--)
        {
            if(modifiers[i].source == src)
            {
                isDirty = true;
                didRemove = true;
                modifiers.RemoveAt(i);
            }
        }

        return didRemove;
    }

    private float CalculateFinalValue()
    {
        float finalValue = baseValue;
        float sumPercentAdd = 0;
        //float sumFullPercentAdd = 0;
        for(int i = 0; i < modifiers.Count; i++)
        {
            CharacterStatModifier mod = modifiers[i];

            if (mod.modType == StatModType.FLAT)
            {
                finalValue += mod.value;
            }

            else if(mod.modType == StatModType.PERCENT)
            {
                sumPercentAdd += mod.value;
                if (i + 1 >= modifiers.Count || modifiers[i + 1].modType != StatModType.PERCENT)
                {
                    finalValue *= 1 + sumPercentAdd;
                    sumPercentAdd = 0;
                }
            }
        }

        return finalValue;
    }

    public void SetDirty()
    {
        this.isDirty = true;
    }
}
