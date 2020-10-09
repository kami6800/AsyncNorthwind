using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrderDetails = new HashSet<OrderDetails>();

            OrderDate = DateTime.Now;
        }

        private int _orderId;
        public int OrderId
        {
            get { return _orderId; }
            set
            {
                if (ValidationMethods.ValidInt(value))
                    _orderId = value;
                else throw new Exception("Invalid Order ID");
            }
        }

        private string _customerId;
        public string CustomerId
        {
            get { return _customerId; }
            set
            {
                if (ValidationMethods.ValidString(value, 5))
                    _customerId = value;
                else throw new Exception("Invalid customer ID");
            }
        }

        private int? _employeeId;
        public int? EmployeeId
        {
            get { return _employeeId; }
            set
            {
                if (value > 0)
                    _employeeId = value;
                else throw new Exception("Invalid employee ID");
            }
        }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int? ShipVia { get; set; }
        public decimal? Freight { get; set; }
        public string ShipName { get; set; }

        private string _shipAddress;
        public string ShipAddress
        {
            get { return _shipAddress; }
            set
            {
                if (ValidationMethods.ValidString(value, 60))
                    _shipAddress = value;
                else throw new Exception("Invalid address");
            }
        }

        private string _shipCity;
        public string ShipCity
        {
            get { return _shipCity; }
            set
            {
                if (ValidationMethods.ValidString(value, 15))
                    _shipCity = value;
                else throw new Exception("Invalid city");
            }
        }

        public string ShipRegion { get; set; }

        private string _shipPostalCode;
        public string ShipPostalCode
        {
            get { return _shipPostalCode; }
            set
            {
                if (ValidationMethods.ValidDigits(value, 10))
                    _shipPostalCode = value;
                else throw new Exception("Invalid postal code");
            }
        }

        private string _shipCountry;
        public string ShipCountry
        {
            get { return _shipCountry; }
            set
            {
                if (ValidationMethods.ValidString(value, 15))
                    _shipCountry = value;
                else throw new Exception("Invalid country");
            }
        }

        public virtual Customers Customer { get; set; }
        public virtual Employees Employee { get; set; }
        public virtual Shippers ShipViaNavigation { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
