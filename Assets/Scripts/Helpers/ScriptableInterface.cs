using System;
using UnityEngine;

namespace AHLike.Helpers
{
    [Serializable]
    public class ScriptableInterface 
    {
        public static T GetInterface<T>(UnityEngine.Object scriptableInterface) where T: class
        {
            var scriptableInstance = ScriptableObject.CreateInstance(scriptableInterface.name);
            T result = default;
            if(scriptableInstance != null)
            {
                result = scriptableInstance as T;
            } 
            return result;
        }
    }
}