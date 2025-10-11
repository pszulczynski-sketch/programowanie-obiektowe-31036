// Task 4

class Osoba
{
    public string name;
    public int age;

    public Osoba(string name,int age)
    {
        this.name = name;
        this.age = age;
    }

    public void Przedstawsie()
    {
        Console.WriteLine("Mam na imię"+name+" oraz mój wiek to "+age);
    }
}

var dodaj1 = new Osoba("Przemek",age:28);
var dodaj2 = new Osoba("Piotr",age:39);

dodaj1.Przedstawsie();
dodaj2.Przedstawsie();