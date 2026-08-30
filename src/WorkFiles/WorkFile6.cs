namespace WorkFiles;

public class WorkFile6 
{
    public int Id { get; set; } = 6;
    public string Name { get; set; } = "WorkFile6";
    
    public string Process() => $"Processed {Name} with Id {Id}";
}
