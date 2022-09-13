using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplifyEr : MonoBehaviour
{
    public List<GameObject> trigger_go_s;
    public List<GameObject> go_s;

    //ScriptableObject so;
    public List<TriggEr> trigger;

    // Start is called before the first frame update
    void Start()
    {
        // so = ScriptableObject.CreateInstance<TriggEr>();
        foreach (var go in go_s) 
            go.SetActive(false);
        //TriggEr trig =(TriggEr) so; 
        //((TriggEr) so).trigger();
        trigger[0] = ScriptableObject.CreateInstance<HandlErForBool>();
       
        trigger[0].go = trigger_go_s[0];
         trigger[0].StartIt();
         trigger[0].TriggerIt();
    }
    TriggEr GetTriggEr(string triggerString)
    {
        return null; // trigger_go_s.
    }
}
