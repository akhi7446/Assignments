using System;
using System.Collections.Generic;
using System.Drawing;

class Pizza
{
    private string size;
    private int CheeseTopping;
    private int PeperoniTopping;
    private int HamTopping;

    public Pizza(string size, int cheese, int peperoni, int ham)
    {
        this.size = size;
        CheeseTopping = cheese;
        PeperoniTopping = peperoni;
        HamTopping = ham;
    }

    public string GetSize() {  return size; }
    public void SetSize(string value) {  size = value; }

    public int GetCheeseTopping() {return CheeseTopping;}
    public void SetCheeseTopping(int value) {CheeseTopping=value;}

    public int GetPeperoniTopping() { return PeperoniTopping;}
    public void SetPeperoniTopping(int value) {PeperoniTopping=value;}

    public int GetHamTopping() {return HamTopping;}
    public void setHamTopping(int value) {HamTopping=value;}

    public double CalcCost()
    {
        int toppings = CheeseTopping + PeperoniTopping + HamTopping;
        double baseprice = 0;

        if(size.ToLower() == "small")
            baseprice =10;
        else if (size.ToLower() == "medium")
            baseprice =12;
        else if(size.ToLower() == "large")
            baseprice = 14;

            return baseprice+(2*toppings);

    }
    public string GetDescription()
    {
        return $"Size : {size}, Cheese : {CheeseTopping}, Pepperoni : {PeperoniTopping}, Ham : {HamTopping},Total Cost : ${CalcCost()}";
    }
}