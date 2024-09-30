using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("animals")]
public class Animal
{
    [Column("animal_id")]
    [Required]
    public int AnimalId { get; set; }

    [Column("name", TypeName = "varchar(50)")]
    [Required]
    public string Name { get; set; }

    [Column("animal_species", TypeName = "varchar(25)")]
    [Required]
    public string AnimalSpecies { get; set; }

    [Column("birth_year")]
    public int? BirthYear { get; set; }

    [ForeignKey("Human")]
    [Column("human_id")]
    [Required]
    public int HumanId { get; set; }

    //instructions said nav prop of Human obj
    [Column("human")]
    public Human Human { get; set; }

    public override string ToString()
    {
        return $" AnimalId: {AnimalId} Name: {Name} Species: {AnimalSpecies}";
    }

}

[Table("humans")]
public class Human
{
    [Column("human_id")]
    [Required]
    public int HumanId { get; set; }

    [Column("fname", TypeName = "varchar(25)")]
    [Required]
    public string FirstName { get; set; }

    [Column("lname", TypeName = "varchar(25)")]
    [Required]
    public string LastName { get; set; }

    [Column("email", TypeName = "varchar(100)")]
    [Required]
    public string Email { get; set; }

    //and a list of obj for animal nav prop
    [Column("animal")]
    public List<Animal> Animal { get; set; }

    public override string ToString()
    {
        return $" HumanId: {HumanId} fname: {FirstName}";
    }

}
