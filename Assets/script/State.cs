using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public virtual void OnEnter() { }       //chiamata quando si entra in uno stato
    public virtual void OnUpdate() { }      //chiamata l'update 
    public virtual void OnExit() { }

}
