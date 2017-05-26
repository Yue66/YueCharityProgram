using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityProject
{
    public static class Foundation
    {
        //private static List<CharityProgram> charityPrograms = new List<CharityProgram>();
        private static FoundationModel db = new FoundationModel();
        //private static Donation donation;
        //private static IEnumerable<object> charityPrograms;

        public static CharityProgram CreateCharityProgram(string name, decimal moneyGoal, EmergencyLevels emergencyLevel)
        {
            var charityProgram = new CharityProgram(name, moneyGoal, emergencyLevel);
            charityProgram.CreateDate = DateTime.Now;
            db.CharityPrograms.Add(charityProgram);
            db.SaveChanges();
            return charityProgram;
        }

        public static List<CharityProgram> GetallCharityPrograms()
  
        {
            return db.CharityPrograms.ToList();
        }

        public static decimal ProcessDonation(int id, decimal amount)
        {
            var charityProgram = db.CharityPrograms.Where(a => a.Id == id).FirstOrDefault();
            if (charityProgram == null)
                throw new ArgumentException("Charity Program is not found");
            var MoneyAlreadyGot = charityProgram.ProcessDonation(amount);
            //var donation = new Donation
            //{
            //    DonationDate = DateTime.Now,
            //    Description ="",
            //    Amount =amount,
            //    Id =id
            //};
            //Another way to instantiate
            var donation = new Donation();
            donation.Amount = amount;
            donation.Description = "";
            donation.Id = id;
            donation.DonationDate = DateTime.Now;
            db.Donations.Add(donation);
            db.SaveChanges();
            return MoneyAlreadyGot;
        }
        public static decimal MoneyStillNeeded(int id)
        {
            var charityProgram = db.CharityPrograms.Where(a => a.Id == id).FirstOrDefault();
            if (charityProgram == null)
                throw new ArgumentException("Charity Program not found");
            var MoneyStillNeeded = charityProgram.MoneyStillNeeded();
            
            return MoneyStillNeeded;
        }
        public static List<Donation> GetAllDonationsByCharityProgram (int id)
        {
           return db.Donations.Where(t => t.Id == id).ToList();
        }
    }
}
