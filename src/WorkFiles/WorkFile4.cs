namespace WorkFiles;

public class WorkFile4 
{
    public int Id { get; set; } = 4;
    public string Name { get; set; } = "WorkFile4";
    
    public string Process() => $"Processed {Name} with Id {Id}";
}
