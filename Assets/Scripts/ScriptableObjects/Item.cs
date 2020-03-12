using UnityEngine;

public abstract class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public abstract void Use();
}
