using System;
using System.Collections.Generic;
using UnityEngine.Events;

public interface IInventoryView
{
    void Display(List<IItem> items);
    void Init(); //UnityAction startGame);
}