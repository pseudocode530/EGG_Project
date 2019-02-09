using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csEventLevelManager : MonoBehaviour {

    private static csEventLevelManager instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        Initialize();
    }

    static public csEventLevelManager Instance()
    {
        return instance;
    }

    private int CurrentEventLevel;
    private Dictionary<GameObject, int> EventObjectLevel;
    public GameObject[] EventObject;
    

    void Initialize()
    {
        CurrentEventLevel = 0;
        EventObjectLevel = new Dictionary<GameObject, int>();

        for (int i = 0; i < EventObject.Length; i++)
        {
            if(EventObject[i] != null)
            {
                EventObjectLevel.Add(EventObject[i], i);
            }
        }
    }

    public bool CheckEventLevel(GameObject Object)
    {
        for (int i = 0; i < EventObject.Length; i++)
        {
            if(EventObject[i] == Object)
            {
                int eventLevel;
                if (EventObjectLevel.TryGetValue(EventObject[i], out eventLevel))
                {
                    if (CurrentEventLevel == eventLevel)
                    {
                        CurrentEventLevel++;
                        return true;
                    }
                }
            }
        }
        return false;
    }

    

}
