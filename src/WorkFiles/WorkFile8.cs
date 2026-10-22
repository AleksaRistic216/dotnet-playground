namespace WorkFiles;

public class WorkFile8 
{
    public int Id { get; set; } = 8;
    public string Name { get; set; } = "WorkFile8";
    
    public string Process() => $"Processed {Name} with Id {Id}";
}
