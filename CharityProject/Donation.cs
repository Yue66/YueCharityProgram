using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityProject
{
    public class Donation
    {
        [Key]
        public int DonationId { get; set; }
        public string Description { get; set; }
        public DateTime DonationDate { get; set; }
        public decimal Amount { get; set; }

        [ForeignKey("CharityProgram")]
        public int Id { get; set; }

        public virtual CharityProgram CharityProgram { get; set; }


    }
}
