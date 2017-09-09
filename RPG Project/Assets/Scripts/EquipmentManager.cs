﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour 
{

    #region Singleton
    public static EquipmentManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one EquipmentManager instance!");
            return;
        }

        instance = this;
    }

    #endregion

    Equipment[] currentEquipment;

    public delegate void OnequipmentChanged(Equipment newItem, Equipment oldItem);
    public OnequipmentChanged onEquipmentChanged;

    Inventory inventory;

    private void Start()
    {
        inventory = Inventory.instance;

        int numSlots = System.Enum.GetNames(typeof(EqipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
    }

    public void Equip (Equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot;

        Equipment oldItem = null;

        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
        }

        if (onEquipmentChanged != null)
            onEquipmentChanged.Invoke(newItem, oldItem);

        currentEquipment[slotIndex] = newItem;
    }

    public void Unequip (int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            Equipment oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);

            currentEquipment[slotIndex] = null;


            if (onEquipmentChanged != null)
                onEquipmentChanged.Invoke(null, oldItem);
        }
    }

    public void UnequipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            UnequipAll();
        }
    }

}