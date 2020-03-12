using UnityEngine;

[CreateAssetMenu(fileName = "New Key", menuName = "Inventory/KeyCard")]
public class KeyCard : Item
{
    public string opens;
    public override void Use()
    {
        Debug.Log("Using "+ name);
    }
}
