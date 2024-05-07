using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int VendingMachineId { get; set; }
    [ForeignKey(nameof(VendingMachineId))]
    public VendingMachine? VendingMachine { get; set; } //
}