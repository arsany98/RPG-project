using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment",menuName = "Inventory/Equipment")]
public class Equipment : Item {

    public EquipmentSlot equipSlot;
    public SkinnedMeshRenderer mesh;
    public EquipmentMeshRegion[] coveredMeshRegion;
    public int DamageModifier;
    public int ArmorModifier;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
        RemoveFromInventory();
    }
}
public enum EquipmentSlot{Head,Chest,Legs,Feet,Weapon,Shield}
public enum EquipmentMeshRegion{Legs,Arms,Torso}