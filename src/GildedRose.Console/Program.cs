using System;
using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        public IList<Item> Items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
            {
                Items = new List<Item>
                                          {
                                              new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                                              new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                                              new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                                              new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                              new Item
                                                  {
                                                      Name = "Backstage passes to a TAFKAL80ETC concert",
                                                      SellIn = 15,
                                                      Quality = 20
                                                  },
                                              new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                                          }

            };

            app.UpdateQuality();

            System.Console.ReadKey();

        }
        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name == "Aged Brie")
                {
                    AgedBrie aged = new AgedBrie();
                    aged.decSellInIn(Items, i);
                    if (Items[i].Quality<50)
                    {
                        aged.qualityLess50(Items,i);
                    }
                     if (Items[i].Quality>0)
                    {
                        aged.qualityMore0(Items, i);
                    }
                }
                if (Items[i].Name == "Sulfuras, Hand of Ragnaros")
                {
                    Sulfuras sul = new Sulfuras();
                    sul.decSellInIn(Items, i);
                    if (Items[i].Quality < 50)
                    {
                        sul.qualityLess50(Items, i);
                    }
                     if (Items[i].Quality > 0)
                    {
                        sul.qualityMore0(Items, i);
                    }
                }
                if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    Backstage back = new Backstage();
                    back.decSellInIn(Items, i);
                    if (Items[i].Quality < 50)
                    {
                        back.qualityLess50(Items, i);
                    }
                     if (Items[i].Quality > 0)
                    {
                        back.qualityMore0(Items, i);
                    }
                }
                if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert" && Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    anyName any = new anyName();
                    any.decSellInIn(Items, i);
                    if (Items[i].Quality < 50)
                    {
                        any.qualityLess50(Items, i);
                    }
                     if (Items[i].Quality > 0)
                    {
                        any.qualityMore0(Items, i);
                    }
                }

            }
        }
       
        
    }
    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }
    public interface Products
    {
        void qualityMore0(IList<Item> Items, int i);
        void qualityLess50(IList<Item> Items, int i);
        void decSellInIn (IList<Item> Items, int i);
        
    }
    public class supesDecIns
    {
        public void incQuality(IList<Item> Items,int i)
        {
            Items[i].Quality = Items[i].Quality + 1;
        }
        public void decQuality(IList<Item> Items, int i)
        {
            Items[i].Quality = Items[i].Quality - 1;
        }
        public void zeroQuality(IList<Item> Items, int i)
        {
            Items[i].Quality = 0;
        }
        public void decSellIn(IList<Item> Items, int i)
        {
            Items[i].SellIn = Items[i].SellIn - 1;
        }
    }
    public class AgedBrie : supesDecIns, Products
    {
        public void decSellInIn (IList<Item> Items, int i)
        {
            decSellIn(Items, i);
        }
        public void qualityLess50(IList<Item> Items, int i)
        {
            incQuality(Items, i);
            
            if (Items[i].SellIn < 0 && Items[i].Quality <50)
            {
                incQuality(Items, i);
            }
            //throw new NotImplementedException();
        }

        public void qualityMore0(IList<Item> Items, int i)
        {
            
           // throw new NotImplementedException();
        }
    }
    public class Backstage : supesDecIns, Products
    {
        public void decSellInIn(IList<Item> Items, int i)
        {
            decSellIn(Items, i);
        }
        public void qualityLess50(IList<Item> Items, int i)
        {
            incQuality(Items, i);
            if (Items[i].SellIn < 11)
            {
                incQuality(Items, i);
            }
            if (Items[i].SellIn < 6)
            {
                incQuality(Items, i);
            }
            if (Items[i].SellIn<0)
            {
                zeroQuality(Items, i);
            }
            //   throw new NotImplementedException();
        }

        public void qualityMore0(IList<Item> Items, int i)
        {
            //     throw new NotImplementedException();
        }
    }
    public class Sulfuras : supesDecIns, Products
    {
        public void decSellInIn(IList<Item> Items, int i)
        {
        }
        public void qualityLess50(IList<Item> Items, int i)
        {
            //    throw new NotImplementedException();
        }

        public void qualityMore0(IList<Item> Items, int i)
        {
            //    throw new NotImplementedException();
        }
    }
    public class anyName : supesDecIns, Products
    {
        public void decSellInIn(IList<Item> Items, int i)
        {
            decSellIn(Items, i);
        }
        public void qualityLess50(IList<Item> Items, int i)
        {
            //   throw new NotImplementedException();
        }

        public void qualityMore0(IList<Item> Items, int i)
        {
            decQuality(Items, i);
            if (Items[i].SellIn < 0)
            {
                decQuality(Items, i);
            }
            //    throw new NotImplementedException();
        }
    }
}
