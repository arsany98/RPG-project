using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    #region singleton
        public static Inventory instance;

        private void Awake()
        {
            if(instance != null)
            {
                Debug.LogWarning("More than one instance of Inventory found!");
                return;
            }
            instance = this;
        }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged Callback;
    public int space = 20;

    public List<Item> Items = new List<Item>();

    public bool Add(Item item)
    {
        if(!item.isEquipped)
        {
            if(Items.Count >= space)
            {
                Debug.Log("Not enough room.");
                return false;
            }
            Items.Add(item);
            if(Callback!=null)
                Callback.Invoke();
        }
        return true;
    }
    public void Remove(Item item)
    {
        Items.Remove(item);
        if (Callback != null)
            Callback.Invoke();
    }
}
