Console.WriteLine("Start");

SomeType? obj = null;
if(obj?.Value == true && obj?.OtherValue == 42) {
    Console.WriteLine("Input is true");
}

Console.WriteLine("End");

class SomeType {
    public bool Value = true;
    public int OtherValue = 42;
}