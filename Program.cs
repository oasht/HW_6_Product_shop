using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Console;
using System.Threading;
using System.Runtime.InteropServices;

namespace HW_6_Product_shop
{

    class Good
    {
        public double price { get; set; }
        public double weight { get; set; }

        public DateTime date;
        DateTime today_date = DateTime.Now;
        public double Check_date(DateTime _date)
        {
            TimeSpan t;
            t = today_date - _date;
            return t.TotalDays;
        }
      

        public Good(double price, double weight, DateTime date)
        {
            this.price = price;
            this.weight = weight;
            this.date = date;
            
        }
        public double Total_price()
        {
            double p = weight * price;
            return p;
        } 
       
        public override string ToString()
        {
            return $"{weight} kg, price/kg = {price} rub";
        }
   
    }

    

    class Dairy_goods : Good
    {
        public double fats { get; set; }
        public Dairy_goods(double fats, double price, double weight, DateTime date) : base(price, weight, date)
        {
            this.fats = fats;
        }
        public override string ToString()
        {
            return $"{base.ToString()}, {fats}% fat";
        }
    }

    class Fruit_goods : Good
    {
        public string color { get; set; }

        public Fruit_goods(string color, double price, double weight, DateTime date) : base(price, weight, date)
        {
            this.color = color;
        }
        public override string ToString()
        {
            return $"{base.ToString()}, {color} color";
        }
    }

    class Milk : Dairy_goods
    {
        public string name { get; set; }
        public Milk(string name, double price, double weight, double fats, DateTime date) : base(fats, price, weight, date)
        {
            this.name = name;
        }
       
        public override string ToString()
        {
            
            
            if (Check_date(date) > 0)
                return $"Milk \"{name}\" {base.ToString()}.\nTotal price = {Math.Round(Total_price(),2)} rubs, expires in {(int)Check_date(date)} days.";
            else
                return "This good has expired";
        }
    }

    class Yogurt : Dairy_goods
    {
        public string taste { get; set; }
        public Yogurt(string taste, double price, double weight, double fats, DateTime date) : base(fats, price, weight, date)
        {
            this.taste = taste;
        }
        
        public override string ToString()
        {
            
            if (Check_date(date) > 0)
                return $"Yogurt \"{taste}\" {base.ToString()}.\nTotal price = {Math.Round(Total_price(), 2)} rubs, expires in {(int)Check_date(date)} days.";
            else
                return "This good has expired";
        }
    }

    class Cream : Dairy_goods
    {
        
        public Cream( double price, double weight, double fats, DateTime date) : base(fats, price, weight, date)
        {
            
        }
       
        public override string ToString()
        {
            
            if (Check_date(date) > 0)
                return $"Cream {base.ToString()}.\nTotal price = {Math.Round(Total_price(), 2)} rubs, expires in {(int)Check_date(date)} days.";
            else
                return "This good has expired";
        }
    }

    class Banana : Fruit_goods
    {
        public string name { get; set; }
        public Banana(string name, double price, double weight, string color, DateTime date) : base(color, price, weight, date)
        {
            this.name = name;
        }
        
        public override string ToString()
        {
            
            if (Check_date(date) > 0)
                return $"Banana {base.ToString()}, brand \"{name}\".\nTotal price = {Math.Round(Total_price(), 2)} rubs, expires in {(int)Check_date(date)} days.";
            else
                return "This good has expired";
        }
    }

    class Apple : Fruit_goods
    {
        public string form { get; set; }

        public Apple(string form, double price, double weight, string color, DateTime date) : base(color, price, weight, date)
        {
            this.form = form;
        }
       
        public override string ToString()
        {
            
            if (Check_date(date) > 0)
                return $"Apple {base.ToString()}, form - {form}.\nTotal price = {Math.Round(Total_price(), 2)} rubs, expires in {(int)Check_date(date)} days.";
            else
                return "This good has expired";
        }
    }

    class Kiwi : Fruit_goods
    {
        public string taste { get; set; }

        public Kiwi(string taste, double price, double weight, string color, DateTime date) : base(color, price, weight, date)
        {
            this.taste = taste;
        }

        public override string ToString()
        {

            if (Check_date(date) > 0)
                return $"Apple {base.ToString()}, taste - {taste}.\nTotal price = {Math.Round(Total_price(), 2)} rubs, expires in {(int)Check_date(date)} days.";
            else
                return "This good has expired";
        }
    }

    internal class Program
    {
        public static DateTime Get_date()
        {
            Random gen = new Random();
            DateTime start = new DateTime(2023, 01, 30);
            int range = (DateTime.Today - start).Days;
            Thread.Sleep(2);
            return start.AddDays(gen.Next(range+5));
           

        }
        static void Main(string[] args)
        {
           

            Good milk = new Milk("Prostokvashino", 60.34, 0.8, 3.2, Get_date());
            Good yogurt = new Yogurt("Berries", 40.75, 0.3, 30.0, Get_date());
            Good cream = new Cream(100.22, 0.5, 40.5, Get_date());
            Good banana = new Banana("Boom", 60.73, 4, "yellow", Get_date());
            Good apple = new Apple("round", 72.33, 6, "green", Get_date());
            Good kiwi = new Kiwi("sour", 65.15, 3, "brown", Get_date());

            Good[] ar = { milk, yogurt, cream, banana, apple, kiwi };
            foreach (var item in ar)
            { 
                WriteLine(item);
                WriteLine();
            }
            double s=0;
            for (int i = 0; i < ar.Length; i++)
            {
                s += ar[i].Total_price();
            }
            WriteLine($"\n\nTotal price of your purchase = {s} rubs");

        }
    }
}


