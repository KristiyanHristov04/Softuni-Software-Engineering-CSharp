using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Enums;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private List<IBakedFood> bakedFoods;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private decimal totalIncome;

        public Controller()
        {
            this.bakedFoods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
        }
        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;
            if (type == "Tea")
            {
                drink = new Tea(name, portion, brand);
            }
            else
            {
                drink = new Water(name, portion, brand);
            }

            this.drinks.Add(drink);
            return String.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = null;
            if (type == "Bread")
            {
                food = new Bread(name, price);
            }
            else
            {
                food = new Cake(name, price);
            }

            this.bakedFoods.Add(food);
            return String.Format(OutputMessages.FoodAdded, name, type);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;
            if (type == "InsideTable")
            {
                table = new InsideTable(tableNumber, capacity);
            }
            else
            {
                table = new OutsideTable(tableNumber, capacity);
            }

            this.tables.Add(table);
            return String.Format(OutputMessages.TableAdded, tableNumber);
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var table in this.tables.Where(table => !table.IsReserved))
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            decimal totalIncome = 0;
            foreach (var table in this.tables)
            {
                totalIncome += table.GetBill();
            }

            totalIncome += this.totalIncome;

            return String.Format(OutputMessages.TotalIncome, totalIncome);
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = this.tables.FirstOrDefault(table => table.TableNumber == tableNumber);
            decimal bill = table.GetBill();
            this.totalIncome += bill;
            table.Clear();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {bill:f2}");
            return sb.ToString().TrimEnd();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = this.tables.FirstOrDefault(table => table.TableNumber == tableNumber);
            if (table == null)
            {
                return String.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            IDrink drink = this.drinks.FirstOrDefault(drink => drink.Name == drinkName && drink.Brand == drinkBrand);
            if (drink == null)
            {
                return String.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }

            //Here I could have some output problems!!!
            table.OrderDrink(drink);
            return String.Format(OutputMessages.FoodOrderSuccessful, tableNumber, drinkName) + $" {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = this.tables.FirstOrDefault(table => table.TableNumber == tableNumber);
            if (table == null)
            {
                return String.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            IBakedFood food = this.bakedFoods.FirstOrDefault(food => food.Name == foodName);
            if (food == null)
            {
                return String.Format(OutputMessages.NonExistentFood, foodName);
            }

            table.OrderFood(food);
            return String.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = this.tables.FirstOrDefault(table => table.Capacity >= numberOfPeople && !table.IsReserved);
            if (table == null)
            {
                return String.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }

            table.Reserve(numberOfPeople);
            return String.Format(OutputMessages.TableReserved, table.TableNumber, numberOfPeople);
        }
    }
}
