namespace WorkFiles;

public class WorkFile1 
{
    public int Id { get; set; } = 1;
    public string Name { get; set; } = "WorkFile1";
    
    public string Process() => $"Processed {Name} with Id {Id}";
}
