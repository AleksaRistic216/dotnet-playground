namespace WorkFiles;

public class WorkFile9 
{
    public int Id { get; set; } = 9;
    public string Name { get; set; } = "WorkFile9";
    
    public string Process() => $"Processed {Name} with Id {Id}";
}
