using Xunit;
using System.Collections.Generic;
using System;

namespace GildedRoseKata.Tests
{
    public class GildedRoseTests
    {
        [Fact]
        public void AgedBrie_QualityIncreasesWithTime()
        {
            // Arrange
            var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 20 } };
            var app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(21, items[0].Quality); // Qualidade aumenta em 1
            Assert.Equal(9, items[0].SellIn);   // SellIn diminui em 1
        }

        [Fact]
        public void BackstagePasses_QualityIncreasesBy2_WhenSellInIs10OrLess()
        {
            // Arrange
            var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20 } };
            var app = new GildedRose(items);

            // Act
            app.IncreaseQuality(items[0]);

            // Assert
            Assert.Equal(22, items[0].Quality); // Qualidade aumenta em 2
        }

        [Fact]
        public void BackstagePasses_QualityDropsToZero_AfterConcert()
        {
            // Arrange
            var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 } };
            var app = new GildedRose(items);

            // Act
            app.IncreaseQuality(items[0]);

            Console.WriteLine($"Quality: {items[0].Quality}, SellIn: {items[0].SellIn}"); // Debugging output

            // Assert
            Assert.Equal(0, items[0].Quality); // Qualidade zera após o evento
            Assert.Equal(0, items[0].SellIn); // SellIn diminui em 1
        }

        [Fact]
        public void ConjuredItem_QualityDecreasesTwiceAsFast()
        {
            // Arrange
            var items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 5, Quality = 10 } };
            var app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(8, items[0].Quality); // Qualidade diminui em 2
            Assert.Equal(4, items[0].SellIn);  // SellIn diminui em 1
        }

        [Fact]
        public void Sulfuras_QualityAndSellInDoNotChange()
        {
            // Arrange
            var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
            var app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(80, items[0].Quality); // Qualidade permanece a mesma
            Assert.Equal(0, items[0].SellIn);   // SellIn permanece o mesmo
        }

        [Fact]
        public void NormalItem_QualityDecreasesBy1()
        {
            // Arrange
            var items = new List<Item> { new Item { Name = "Normal Item", SellIn = 5, Quality = 10 } };
            var app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(9, items[0].Quality); // Qualidade diminui em 1
            Assert.Equal(4, items[0].SellIn);  // SellIn diminui em 1
        }

        [Fact]
        public void NormalItem_QualityDecreasesBy2_WhenSellInIsNegative()
        {
            // Arrange
            var items = new List<Item> { new Item { Name = "Normal Item", SellIn = 0, Quality = 10 } };
            var app = new GildedRose(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(8, items[0].Quality); // Qualidade diminui em 2
            Assert.Equal(-1, items[0].SellIn); // SellIn diminui em 1
        }
    }
}
