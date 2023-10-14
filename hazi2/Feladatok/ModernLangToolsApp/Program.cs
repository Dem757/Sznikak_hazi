using System.Diagnostics;
using System.Xml.Serialization;
using System;
using System.ComponentModel;

namespace ModernLangToolsApp;

public class Program
{
    private static void Council_CouncilChanged(string message)
    {
        throw new NotImplementedException();
    }

    [Description("Feladat2")]
    private static void TestXml()
    {
        var anakin = new Jedi
        {
            Name = "Anakin",
            MidiChlorianCount = 20000,
        };

        var serializer = new XmlSerializer(typeof(Jedi));
        var stream = new FileStream("jedi.txt", FileMode.Create);
        serializer.Serialize(stream, anakin);
        stream.Close();
        Process.Start(new ProcessStartInfo
        {
            FileName = "jedi.txt",
            UseShellExecute = true,
        });

        stream = new FileStream("jedi.txt", FileMode.Open);
        var clone = (Jedi)serializer.Deserialize(stream);
        stream.Close();

    }

    private static void MessageReceived(string message)
    {
        Console.WriteLine(message);
    }

    [Description("Feladat3")]
    private static void TestJediCouncil()
    {
        var council = new JediCouncil();

        var anakin = new Jedi
        {
            Name = "Anakin",
            MidiChlorianCount = 20000,
        };

        var obivan = new Jedi
        {
            Name = "Obivan",
            MidiChlorianCount = 10000,
        };

        council.CouncilChanged += MessageReceived;

        council.Add(anakin);
        council.Add(obivan);

        council.Remove();
        council.Remove();

    }

    [Description("Feladat4")]
    public static void TestWeakers()
    {
        var council = new JediCouncil();

        var anakin = new Jedi
        {
            Name = "Anakin",
            MidiChlorianCount = 20000,
        };

        var weakJedi = new Jedi
        {
            Name = "Weak",
            MidiChlorianCount = 100,
        };

        council.Add(anakin);
        council.Add(weakJedi);

        var weakers = council.WeakJedis_Delegate();
        weakers.ForEach(jedi => Console.WriteLine(jedi.Name + " is a weak Jedi!"));

    }

    [Description("Feladat5")]
    public static void TestNotThatWeaks ()
    {
        var council = new JediCouncil();

        var anakin = new Jedi
        {
            Name = "Anakin",
            MidiChlorianCount = 20000,
        };

        var weakJedi = new Jedi
        {
            Name = "Weak",
            MidiChlorianCount = 800,
        };

        council.Add(anakin);
        council.Add(weakJedi);

        var test = council.NotThatWeakJedis_Lambda();

        test.ForEach(jedi => Console.WriteLine(jedi.Name + " is kinda weak"));
    }
       
    public static void Main(string[] args)
    {
        TestXml();
        TestJediCouncil();
        TestWeakers();
        TestNotThatWeaks();
    }
}
