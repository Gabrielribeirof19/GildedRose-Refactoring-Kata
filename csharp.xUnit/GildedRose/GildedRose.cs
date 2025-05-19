using System;
using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose : IGildedRose
{
    public IList<Item> Items { get; set; }

    public GildedRose(IList<Item> items) 
    {
        Items = items;
    }
    static bool IsConjured(string name)
    {
        if (string.IsNullOrEmpty(name))
            return false;
        return name.Contains("Conjured", StringComparison.OrdinalIgnoreCase);
    }
    public virtual void UpdateQuality()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            if (Items[i].Quality < 50 && Items[i].Quality > -1 && Items[i].Name != "Sulfuras, Hand of Ragnaros")
            {
                IncreaseQuality(Items[i]);
                if (Items[i].Name != "Sulfuras, Hand of Ragnaros") Items[i].SellIn -= 1;
                DecreaseQuality(Items[i]);
            }
        }
    }

    public void DecreaseQuality(Item Item)
    {
        if (Item.Name != "Aged Brie" && Item.Name != "Backstage passes to a TAFKAL80ETC concert") 
        {
            int mul = 1;
            bool conjured = IsConjured(Item.Name);
            if (Item.SellIn < 0) { mul *= 2; }
            if (conjured) { mul *= 2; }
            Item.Quality -= 1 * mul;
        }
    }

    public void IncreaseQuality(Item Item)
    {
        if (Item.Name == "Backstage passes to a TAFKAL80ETC concert")
        {
            IncreaseBackstageQuality(Item);
        } else if (Item.Name == "Aged Brie") {Item.Quality += 1;}
    }
    private void IncreaseBackstageQuality(Item Item)
    {
        if (Item.SellIn <= 0)
        {
            Item.Quality = 0;
        }
        else if (Item.SellIn <= 5)
        {
            Item.Quality += 3;
        }
        else if (Item.SellIn <= 10)
        {
            Item.Quality += 2;
        }
        else
        {
           Item.Quality += 1;
        }
    }
}