using System;
using System.Collections.Generic;

public interface IInventoryView
{
    void Display(List<IItem> items);
}