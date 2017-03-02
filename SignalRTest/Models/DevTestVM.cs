using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace SignalRTest.Models
{
    public class DevTestVM
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Campaign Name")]
        public string CampaignName { get; set; }

        [Required]
        [Display(Name = "Campaign Date")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Campaign Clicks")]
        public int Clicks { get; set; }

        [Required]
        [Display(Name = "Campaign Conversions")]
        public int Conversions { get; set; }

        [Required]
        [Display(Name = "Campaign Impressions")]
        public int Impressions { get; set; }

        [Required]
        [Display(Name = "Affiliate Name")]
        public string AffiliateName { get; set; }

        public DevTestVM()
        {
        }
    }
}
