using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBurnable 
{
    public bool isBurning {  get; set; }
    public void StartBurning(int damagePerSecond);
    public void StopBurning();
}
