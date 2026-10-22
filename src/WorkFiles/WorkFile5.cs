namespace WorkFiles;

public class WorkFile5 
{
    public int Id { get; set; } = 5;
    public string Name { get; set; } = "WorkFile5";
    
    public string Process() => $"Processed {Name} with Id {Id}";
}
