using System;
using System.Collections.Generic;
using GameMaker.Core.Runtime;
using UnityEngine;

public abstract class BaseScriptableObjectDataManager<T,M> :ScriptableObjectSingleton<T> where T : ScriptableObject where M: IDefinition
{
    [SerializeField]
    protected BaseDefinitionManager<M> dataManager = new();

    public List<M> GetDefinitions(Func<M, bool> predicate = null)
    {
        return dataManager.GetDefinitions(predicate);
    }
    public void AddDefinition(M definition)
    {
        dataManager.AddDefinition(definition);
    }
    public void RemoveDefinition(M definition)
    {
        dataManager.RemoveDefinition(definition);
    }
}