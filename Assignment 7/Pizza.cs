using System;
using System.Collections.Generic;
using System.Drawing;


/*
 Create a class named Pizza that stores information about a single pizza. It should contain the following: 

Private  instance  variables  to  store  the  size  of  the  pizza  
the  number of  cheese toppings, 
the number of pepperoni toppings, and
the number of ham toppings

Methods : 

Constructor(s) that set all of the instance variables. 
Use get set methods
Public methods to get and set the instance variables. 
A public method named calcCost( ) that returns a double that is the cost of the pizza.
Pizza cost is determined by: 
Small: $10 + $2 per topping 
Medium: $12 + $2 per topping 
Large: $14 + $2 per topping  
public method named getDescription( ) that returns a String containing the pizzaSize, quantity of each topping.


Store some Records and display them (Which structure we should use)
*/
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