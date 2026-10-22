namespace WorkFiles;

public class WorkFile2 
{
    public int Id { get; set; } = 2;
    public string Name { get; set; } = "WorkFile2";
    
    public string Process() => $"Processed {Name} with Id {Id}";
}
