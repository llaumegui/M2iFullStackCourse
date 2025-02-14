using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exo06.Models;

[ComplexType]
public class Picture
{
    [StringLength(50)] public string? Alt;

    [StringLength(100)] public string? Url;
}