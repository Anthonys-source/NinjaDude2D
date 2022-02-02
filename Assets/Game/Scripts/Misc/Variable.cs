using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Variable<T>
{
    public T Value { get; set; }
    public Variable(T value)
    {
        this.Value = value;
    }
}
