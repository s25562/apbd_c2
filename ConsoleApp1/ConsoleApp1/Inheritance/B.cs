namespace ConsoleApp1.Inheritance;

public class B : A 
{
    public int myProperty { get; set; }
    public B (int number, int myProperty) : base(number);{
        this.myProperty = myProperty;
    }

}