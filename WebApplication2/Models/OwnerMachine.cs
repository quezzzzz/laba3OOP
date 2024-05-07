using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models;

public class OwnerMachine
{
    public int Id { get; set; }
    public int VendingMachineId { get; set; }
    [ForeignKey(nameof(VendingMachineId ))]
    public VendingMachine? VendingMachine { get; set; }
    public int OwnerId { get; set; }
    [ForeignKey(nameof(OwnerId))]
    public Owner? Owner { get; set; }
}