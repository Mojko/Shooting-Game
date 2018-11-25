using UnityEngine;
using System.Collections;

public interface IStateRepository  
{
    void Register();
    TState Resolve<TState>();
}