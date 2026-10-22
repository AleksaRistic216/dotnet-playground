namespace WorkFiles;

public class WorkFile3 
{
    public int Id { get; set; } = 3;
    public string Name { get; set; } = "WorkFile3";
    
    public string Process() => $"Processed {Name} with Id {Id}";
}
