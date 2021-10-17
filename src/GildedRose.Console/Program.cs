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
                //func that inc and dic quality 
                //conditions are:
                //name not (Aged Brie,Backstage passes to a TAFKAL80ETC concert,Sulfuras, Hand of Ragnaros)
                //and Quality>0
                //else:
                //name not (Aged Brie,Backstage passes to a TAFKAL80ETC concert)
                //Quality < 50 and SellIn < 11
                //or SellIn < 6
                noneNameAndBigQuality(i);

                //sec sellIn If name not Sulfuras
                SulfurasSellIn(i);

                //func that inc and dic quality 
                //conditions are:
                //SellIn < 0 for all in:
                //name not (Aged Brie,Backstage passes to a TAFKAL80ETC concert,Sulfuras, Hand of Ragnaros)
                //and Quality > 0
                //else:
                //name not(Aged Brie)
                //else:
                //name is (Aged Brie) and Quality < 50
                allNamesLimitQuality(i);

            }
        }
        public void noneNameAndBigQuality(int i)
        {
            if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                if (Items[i].Quality > 0 && Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    {
                        decQuality(i);
                    }
                }
            }
            else
            {
                if (Items[i].Quality < 50)
                {
                    incQuality(i);

                    if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert" && Items[i].SellIn < 11 )
                    {
                        {
                            incQuality(i);
                        }

                        if (Items[i].SellIn < 6)
                        {
                            incQuality(i);
                        }
                    }
                }
            }

        }
        public void SulfurasSellIn(int i)
        {
            if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
            {
                decSellIn(i);
            }
        }
        public void allNamesLimitQuality(int i)
        {
            if (Items[i].SellIn < 0)
            {
                if (Items[i].Name != "Aged Brie")
                {
                    if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (Items[i].Quality > 0 && Items[i].Name != "Sulfuras, Hand of Ragnaros")
                        {
                            decQuality(i);
                        }
                    }
                    else
                    {
                        zeroQuality(i);
                    }
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        incQuality(i);
                    }
                }
            }
        }
        public void incQuality(int i)
        {
            Items[i].Quality = Items[i].Quality + 1;
        }
        public void decQuality(int i)
        {
            Items[i].Quality = Items[i].Quality - 1;
        }
        public void zeroQuality(int i)
        {
            Items[i].Quality = 0;
        }
        public void decSellIn(int i)
        {
            Items[i].SellIn = Items[i].SellIn - 1;
        }
    }
    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }
    public class AgedBrie
    {
    }
    public class Backstage
    {
    }
    public class Sulfuras
    {    }
}
