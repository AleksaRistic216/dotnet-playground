namespace WorkFiles;

public class WorkFile10 
{
    public int Id { get; set; } = 10;
    public string Name { get; set; } = "WorkFile10";
    
    public string Process() => $"Processed {Name} with Id {Id}";
}
