namespace WorkFiles;

public class WorkFile7 
{
    public int Id { get; set; } = 7;
    public string Name { get; set; } = "WorkFile7";
    
    public string Process() => $"Processed {Name} with Id {Id}";
}
