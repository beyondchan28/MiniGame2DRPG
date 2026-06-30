using System.Collections.Generic;
using UnityEngine;

public class WorldData : MonoBehaviour
{
    public static WorldData Instance;

    private Dictionary<string, bool> interactionIDs = new Dictionary<string, bool>();

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        SetupInteractions();
        DontDestroyOnLoad(this);
    }

    void SetupInteractions()
    {
        Interaction[] allInteraction = Object.FindObjectsByType<Interaction>();
        foreach (var i in allInteraction)
        {
            RegisterID(i.Guid);
            i.Data.Setup();
        }
    }

    public void RegisterID(string id)
    {
        interactionIDs.Add(id, false);
    }

    public void Interacted(string id)
    {
        interactionIDs[id] = true;
    }

    public bool IsInteracted(string id)
    {
        return interactionIDs[id];
    }



}
