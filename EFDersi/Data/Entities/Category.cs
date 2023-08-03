using System.ComponentModel.DataAnnotations.Schema;

namespace EFDersi.Data.Entities;


public class Category
{
    public int Id { get; set; }
    public string Definition { get; set; }
}
