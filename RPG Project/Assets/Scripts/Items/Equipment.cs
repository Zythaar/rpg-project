﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item 
{
    public EqipmentSlot equipSlot;

    public int armorModifier;
    public int damageModifier;

    public override void Use()
    {
        base.Use();

        EquipmentManager.instance.Equip(this);
        RemoveFromInventory();
    }


}

public enum EqipmentSlot { Head, Chest, Legs, Weapon, Shield, Feet }
