using GildedRoseKata;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using Moq;

namespace GildedRoseKata.Tests;

public class ItemTests
{
    // Método que fornece os dados para o teste
    public static IEnumerable<object[]> GetItems()
    {
        yield return new object[]
        {
            new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
            new Item { Name = "+5 Dexterity Vest", SellIn = 9, Quality = 19 } // Estado esperado
        };
        yield return new object[]
        {
            new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
            new Item { Name = "Aged Brie", SellIn = 1, Quality = 1 } // Estado esperado
        };
        yield return new object[]
        {
            new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
            new Item { Name = "Elixir of the Mongoose", SellIn = 4, Quality = 6 } // Estado esperado
        };
    }

    [Theory]
    [MemberData(nameof(GetItems))]
    public void TestItemUpdateQuality(Item initialItem, Item expectedItem)
    {
        // Arrange
        var items = new List<Item> { initialItem };
        var app = new GildedRose(items);

        // Act
        app.UpdateQuality();

        // Assert
        Assert.Equal(expectedItem.Name, items[0].Name);
        Assert.Equal(expectedItem.SellIn, items[0].SellIn);
        Assert.Equal(expectedItem.Quality, items[0].Quality);
    }

    [Fact]
    public void Main_ShouldCallUpdateQuality()
    {
        // Arrange
        var mockItems = new List<Item>
    {
        new Item { Name = "Test Item", SellIn = 5, Quality = 10 }
    };

        var mockGildedRose = new Mock<IGildedRose>();
        mockGildedRose.SetupProperty(x => x.Items, mockItems);

        Program.GildedRoseInstance = mockGildedRose.Object;

        var args = new string[] { "1" };

        // Act
        Program.Main(args);

        // Assert
        mockGildedRose.Verify(x => x.UpdateQuality(), Times.AtLeastOnce);
    }
}