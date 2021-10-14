using GildedRose.Console;
using System;
using Xunit;

namespace GildedRose.Tests
{

    public class TestAssemblyTests
    {
        private Console.Program CreateAndUpdate( String name, int sellin, int quality)
        {
            //arrange
            Item[] items = new Item[]
            {
                new Item{ Name=name,SellIn=sellin,Quality=quality }
            };

            //act
            Console.Program app = new Program() { Items = items };
            app.UpdateQuality();
            return app;
        }

        [Fact]
        public void TestTheTruth()
        {
            Assert.True(true);
        }
    
    [Fact]
    public void SystemLowersValues()
    {
        var app = CreateAndUpdate("foo",15, 25);
        
        //assert sellin
        Assert.Equal(14, app.Items[0].SellIn);
        //assert quality
        Assert.Equal(24, app.Items[0].Quality);
    }

     [Fact]
     public void QualityDegradesTwiceAsFast()
        {
            var app = CreateAndUpdate("foo",0, 25);

            //assert quality
            Assert.Equal(23, app.Items[0].Quality);
        }

        

        [Fact]
        public void QualityNeverNegative()
        {
            var app = CreateAndUpdate("foo", 10, 0);

            //assert quality
            Assert.Equal(0, app.Items[0].Quality);

            //assert sellin
            Assert.Equal(9, app.Items[0].SellIn);
        }


        [Fact]
        public void QualityIncreases()
        {
            var app = CreateAndUpdate("Aged Brie", 15, 25);

            //assert quality
            Assert.Equal(26, app.Items[0].Quality);

            //assert sellin
            Assert.Equal(14, app.Items[0].SellIn);
        }

        [Fact]
        public void QualityNotIncreases()
        {
            var app = CreateAndUpdate("Aged Brie", 15, 50);

            //assert quality
            Assert.Equal(50, app.Items[0].Quality);

            //assert sellin
            Assert.Equal(14, app.Items[0].SellIn);
        }

        [Fact]
        public void SulfurasQualityNotIncreases()
        {
            var app = CreateAndUpdate("Sulfuras, Hand of Ragnaros", 15, 80);

            //assert quality
            Assert.Equal(80, app.Items[0].Quality);

            //assert sellin
            Assert.Equal(15, app.Items[0].SellIn);
        }
        [Fact]
        public void BackstagePassesProcess()
        {
            var app = CreateAndUpdate("Backstage passes to a TAFKAL80ETC concert", 0, 20);

            //assert quality
            Assert.Equal(0, app.Items[0].Quality);

            //assert sellin
            Assert.Equal(-1, app.Items[0].SellIn);
        }




    }

}