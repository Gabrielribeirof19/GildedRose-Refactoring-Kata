using GildedRoseKata;
using System.Collections.Generic;

public interface IGildedRose
{
    IList<Item> Items { get; set; }
    void UpdateQuality();
}
