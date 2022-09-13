using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStartEr { public  void StartIt(); }
public interface ITriggEr { public  void TriggerIt(); }
//public interface ISetErGO { public  void SetGO(GameObject go); }
public class TriggEr : ScriptableObject, IStartEr, ITriggEr
{
    [SerializeField] public GameObject go;
    [SerializeField] public MonoBehaviour mb;
    [SerializeField] public ScriptableObject so;
    //public void SetGO(GameObject go) { }

    public virtual void StartIt()
    {

    }

    public virtual void TriggerIt()
    {
        Debug.Log("trigger!");
    }

}
