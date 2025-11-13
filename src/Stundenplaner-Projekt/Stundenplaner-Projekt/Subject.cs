using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Subject
{
    private string _name;
    private Room _room;

    public string Name { get => _name; set => _name = value; }
    public Room Room { get => _room; set => _room = value; }

    public Subject(string name)
    {
        _name = name;
    }

    public Subject(string name, Room room)
    {
        _name = name;
        _room = room;
    }
}

// Placeholder-Klassen
public class TimeBlock { }
public class Room { }
}

