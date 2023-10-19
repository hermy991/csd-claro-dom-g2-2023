using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumManager.Core.Entities;
public class Sprint
{
    public required string Name { get; set; }
    public int DurationQuantity { get; set; }
    public required string DurationUnit { get; set; }
    public bool Regular { get; set; }
    public int Points { get; set; }
    public DateTime StartDate  { get; set; }
    public DateTime EndDate { get; set; }
    public int FinalPoints { get; set; }
    public required string Developers { get; set; }
}
