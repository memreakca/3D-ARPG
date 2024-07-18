using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void ModifiedEvent();
[System.Serializable]
public class ModifiableInt 
{

    [SerializeField]
    public int baseValue;
    public int BaseValue { get { return baseValue; } set { baseValue = value; UpdateModifiedValue(); } }

    [SerializeField]
    public int modifiedValue;
    public int ModifiedValue { get { return modifiedValue; } private set { modifiedValue = value; } }

    public List<IModifiers> modifiers = new List<IModifiers>();

    public event ModifiedEvent ValueModified;
    public ModifiableInt(ModifiedEvent method = null)
    {
        modifiedValue = BaseValue;
        if (method != null)
            ValueModified += method;
    }

    public void RegisterModEvent(ModifiedEvent method)
    {
        ValueModified += method;
    }
    public void UnregisterModEvent(ModifiedEvent method)
    {
        ValueModified -= method;
    }

    public void UpdateModifiedValue()
    {
        var valueToAdd = 0;
        for (int i = 0; i < modifiers.Count; i++) 
        {
            modifiers[i].AddValue(ref valueToAdd);
        }
        ModifiedValue = baseValue + valueToAdd;
        if (ValueModified != null)
            ValueModified.Invoke();
    }

    public void AddModifier(IModifiers _modifier)
    {
        modifiers.Add(_modifier);
        UpdateModifiedValue();
    }
    public void RemoveModifier(IModifiers _modifier)
    {
        modifiers.Remove(_modifier);
        UpdateModifiedValue();
    }
}
