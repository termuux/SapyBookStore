using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Bulky.Models;

public class Product
{
    [Key]
    public int Id { get; set; }

    [Required]
    [DisplayName("Title")]
    public string Title { get; set; }
    public string Description { get; set; }
    [Required]
    public string Author { get; set; }
    [Required]
    public string ISBN { get; set; }
    [Required]
    [Display(Name = "List Price")]
    [Range(1,1000,ErrorMessage = "Price must be between 1 and 1000")]
    public double ListPrice { get; set; }
    
    
    [Required]
    [Display(Name = "Price")]
    [Range(1,1000,ErrorMessage = "Price must be between 1 and 1000")]
    public double Price { get; set; }
    
    [Required]
    [Display(Name = "Price for 50+")]
    [Range(1,1000,ErrorMessage = "Price must be between 1 and 1000")]
    public double Price50 { get; set; }

    [Required]
    [Display(Name = "Price for 100+")]
    [Range(1,1000,ErrorMessage = "Price must be between 1 and 1000")]
    public double Price100 { get; set; }
    
    public int CategoryID { get; set; }
    [ForeignKey("CategoryID")]
    [ValidateNever]
    public Category Category { get; set; }
    [ValidateNever]
    public string ImageUrl { get; set; }
    

}