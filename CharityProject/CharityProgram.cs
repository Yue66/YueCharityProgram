using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityProject
{
    public enum EmergencyLevels
    {
        High,
        Medium,
        Low
    }
    public class CharityProgram
    {
        #region Variables
        private static int lastId = 0;

        #endregion

        #region properties
        [Key]
        public int Id { get; private set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public decimal MoneyGoal { get; set; }

        public DateTime  CreateDate { get; set; }

        public int BankAccountNumber { get; set; }

        public decimal MoneyAlreadyGot { get; set; }

        public EmergencyLevels EmergencyLevel { get; set; }

        public virtual ICollection<Donation> Donations { get; set; }
        #endregion

        #region  Constructors
        public CharityProgram()
        {
            Id = ++lastId;
            MoneyAlreadyGot = 0;
        }

        public CharityProgram(string name) : this()
        {
            Name = name;
        }

        public CharityProgram(string name, decimal moneyGoal) : this(name)
        {
            MoneyGoal = moneyGoal;
        }

        public CharityProgram(string name, decimal moneyGoal, EmergencyLevels emergencyLevel) : this(name, moneyGoal)
        {
            EmergencyLevel = emergencyLevel;
        }

        #endregion

        #region Methods



        public decimal ProcessDonation(decimal amount)
        {
            MoneyAlreadyGot += amount;
            return MoneyAlreadyGot;


        }
        public decimal MoneyStillNeeded()
        {

            var MoneyStillNeeded = MoneyGoal - MoneyAlreadyGot;
            return MoneyStillNeeded;

        }
        #endregion 

    }
}