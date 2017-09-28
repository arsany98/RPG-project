using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayaerManager : MonoBehaviour {

    #region singleton
    public static PlayaerManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }
    #endregion

    public GameObject player;
}

