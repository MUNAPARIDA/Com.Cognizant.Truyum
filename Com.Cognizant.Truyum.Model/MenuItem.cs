using System;
namespace Com.Cognizant.Truyum.Model
{
    public class MenuItem
    {
        private int id;
        private string name;
        private double price;
        private bool active;
        private DateTime dateOfLaunch;
        private string category;
        private bool freeDelivery;

        public int ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }
        public bool Active { get => active; set => active = value; }
        public DateTime DateOfLaunch { get => dateOfLaunch; set => dateOfLaunch = value; }
        public string Category { get => category; set => category = value; }
        public bool FreeDelivery { get => freeDelivery; set => freeDelivery = value; }

        public override string ToString()
        {
            return String.Format("{0,-5}{1,-20} {2,-10} {3,-5} {4,-15} {5,-20} {6,-5}",ID, Name,Price , Active ? "Yes" : "No", Utility.Utility.ConvertToString(DateOfLaunch), Category, FreeDelivery ? "Yes" : "No");
        }
        public bool Equals(MenuItem obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            return this.ID == obj.ID;
        }
    }
}
