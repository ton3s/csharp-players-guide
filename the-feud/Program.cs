using IField;
using McDroid;
using Pig = IField.Pig;

Console.Clear();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("THe Feud");

Sheep sheep = new Sheep();
Console.WriteLine(sheep.ToString());

// IField.Pig
Pig iPig = new Pig();
Console.WriteLine(iPig.ToString());

// McDroid.Pig
McDroid.Pig mPig = new McDroid.Pig();
Console.WriteLine(mPig.ToString());

Cow cow = new Cow();
Console.WriteLine(cow.ToString());

namespace IField
{
    class Sheep { }
    class Pig { }
}

namespace McDroid
{
    class Cow { }
    class Pig { }
}