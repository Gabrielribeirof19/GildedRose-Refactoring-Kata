﻿using System;
using System.Collections.Generic;

namespace GildedRoseKata;

public class Program
{
    public static IGildedRose GildedRoseInstance { get; set; }
    public static void Main(string[] args)
    {
        Console.WriteLine("OMGHAI!");
        if (GildedRoseInstance == null)
        {
            GildedRoseInstance = new GildedRose(new List<Item>());
        }

        GildedRoseInstance.Items = new List<Item>
        {
            new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
            new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
            new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
            new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
            new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 15,
                Quality = 20
            },
            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 10,
                Quality = 49
            },
            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 5,
                Quality = 49
            },
            // this conjured item does not work properly yet
            new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
        };

        //GildedRoseInstance = new GildedRose(items);

        int days = 2;
        if (args.Length > 0)
        {
            days = int.Parse(args[0]) + 1;
        }

        for (var i = 0; i < days; i++)
        {
            Console.WriteLine("-------- day " + i + " --------");
            Console.WriteLine("name, sellIn, quality");
            foreach (var item in GildedRoseInstance.Items)
            {
                Console.WriteLine($"{item.Name}, {item.SellIn}, {item.Quality}");
            }
            Console.WriteLine("");
            GildedRoseInstance.UpdateQuality();
        }
    }
}