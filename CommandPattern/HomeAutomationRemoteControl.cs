using System;
using System.Text;

namespace CommandPattern
{
    public class HomeAutomationRemoteControl
    {
        ICommand[] onCommands;
        ICommand[] offCommands;
        ICommand undoCommand;
        public HomeAutomationRemoteControl()
        {
            onCommands = new ICommand[7];
            offCommands = new ICommand[7];

            ICommand noCommand = new NoCommand();
            for (int i = 0; i < 7; i++)
            {
                onCommands[i] = noCommand;
                offCommands[i] = noCommand;
            }
            undoCommand = noCommand;
        }

        public void SetCommand(int slot, ICommand onCommand, ICommand offCommand)
        {
            onCommands[slot] = onCommand;
            offCommands[slot] = offCommand;
        }

        public void OnButtonWasPushed(int slot)
        {
            if (onCommands[slot] != null)
            {
                onCommands[slot].Execute();
                undoCommand = onCommands[slot];
            }
        }

        public void OffButtonWasPushed(int slot)
        {
            if (offCommands[slot] != null)
            {
                offCommands[slot].Execute();
                undoCommand = offCommands[slot];
            }
        }

        public void UndoButtonWasPushed()
        {
            undoCommand.Undo();
        }

        public string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("\n------ Remote Control------ -\n");
            for (int i = 0; i < onCommands.Length; i++)
            {
                stringBuilder.Append("[slot " + i + "] " + onCommands[i].GetType().Name
               + " " + offCommands[i].GetType().Name + "\n");
            }
            return stringBuilder.ToString();
        }

    }
    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    public class MacroCommand : ICommand
    {
        ICommand[] commands;
        public MacroCommand(ICommand[] commands)
        {
            this.commands = commands;
        }
        public void Execute()
        {
            for (int i = 0; i < commands.Length; i++)
            {
                commands[i].Execute();
            }
        }

        /// <summary>
        /// TODO: Buna bir bak
        /// </summary>
        public void Undo()
        {
            for (int i = 0; i < commands.Length; i++)
            {
                commands[i].Undo();
            }
        }
    }

    public class NoCommand : ICommand
    {
        public void Execute()
        {

        }

        public void Undo()
        {

        }
    }
    public class LightOnCommand : ICommand
    {
        Light _light;
        /// <summary>
        /// The constructor is passed the specific light that this command is going to control - say the living room light
        /// - and stashes it in the light instance variable.When execute gets called, this is 
        /// the light object that is going to be the Receiver of the request.
        /// </summary>
        /// <param name="light"></param>
        public LightOnCommand(Light light)
        {
            this._light = light;
        }

        /// <summary>
        /// The execute method calls the on() method on the receiving object, which is the light we
        /// are controlling.
        /// </summary>
        public void Execute()
        {
            _light.On();
        }

        public void Undo()
        {
            _light.Off();
        }
    }

    public class LightOffCommand : ICommand
    {
        Light _light;

        public LightOffCommand(Light light)
        {
            this._light = light;
        }

        public void Execute()
        {
            _light.Off();
        }

        public void Undo()
        {
            _light.On();
        }
    }

    public class GarageDoorOpenCommand : ICommand
    {
        GarageDoor _garageDoor;

        public GarageDoorOpenCommand(GarageDoor garageDoor)
        {
            _garageDoor = garageDoor;
        }
        public void Execute()
        {
            _garageDoor.Up();
        }

        public void Undo()
        {
            _garageDoor.Down();
        }
    }
    public class GarageDoorDownCommand : ICommand
    {
        GarageDoor _garageDoor;

        public GarageDoorDownCommand(GarageDoor garageDoor)
        {
            _garageDoor = garageDoor;
        }
        public void Execute()
        {
            _garageDoor.Down();
        }

        public void Undo()
        {
            _garageDoor.Up();
        }
    }
    public class StereoOnWithCDCommand : ICommand
    {
        Stereo _stereo;

        public StereoOnWithCDCommand(Stereo stereo)
        {
            _stereo = stereo;
        }
        public void Execute()
        {
            _stereo.On();
            _stereo.SetCD();
            _stereo.SetVolume(11);
        }

        public void Undo()
        {
            _stereo.SetVolume(0);
            _stereo.Off();
        }
    }
    public class StereoOffCommand : ICommand
    {
        Stereo _stereo;

        public StereoOffCommand(Stereo stereo)
        {
            _stereo = stereo;
        }
        public void Execute()
        {
            _stereo.Off();
        }

        public void Undo()
        {
            _stereo.On();
            _stereo.SetVolume(11);
        }
    }
    public class CeilingFanOffCommand : ICommand
    {
        CeilingFan _ceilingFan;

        public CeilingFanOffCommand(CeilingFan ceilingFan)
        {
            _ceilingFan = ceilingFan;
        }
        public void Execute()
        {
            _ceilingFan.Off();
        }

        public void Undo()
        {
            _ceilingFan.High();
        }
    }
    public class CeilingFanHighCommand : ICommand
    {
        CeilingFan _ceilingFan;
        int prevSpeed;

        public CeilingFanHighCommand(CeilingFan ceilingFan)
        {
            _ceilingFan = ceilingFan;
        }
        public void Execute()
        {
            prevSpeed = _ceilingFan.GetSpeed();
            _ceilingFan.High();
        }

        public void Undo()
        {
            if (prevSpeed == CeilingFan.HIGH)
            {
                _ceilingFan.High();
            }
            else if (prevSpeed == CeilingFan.MEDIUM)
            {
                _ceilingFan.Medium();
            }
            else if (prevSpeed == CeilingFan.LOW)
            {
                _ceilingFan.Low();
            }
            else if (prevSpeed == CeilingFan.OFF)
            {
                _ceilingFan.Off();
            }
        }
    }
    public class CeilingFanMediumCommand : ICommand
    {
        CeilingFan _ceilingFan;
        int prevSpeed;

        public CeilingFanMediumCommand(CeilingFan ceilingFan)
        {
            _ceilingFan = ceilingFan;
        }
        public void Execute()
        {
            prevSpeed = _ceilingFan.GetSpeed();
            _ceilingFan.Medium();
        }

        public void Undo()
        {
            if (prevSpeed == CeilingFan.HIGH)
            {
                _ceilingFan.High();
            }
            else if (prevSpeed == CeilingFan.MEDIUM)
            {
                _ceilingFan.Medium();
            }
            else if (prevSpeed == CeilingFan.LOW)
            {
                _ceilingFan.Low();
            }
            else if (prevSpeed == CeilingFan.OFF)
            {
                _ceilingFan.Off();
            }
        }
    }

    public class Light
    {
        string _place;
        public Light(string place)
        {
            _place = place;
        }
        public void On()
        {
            Console.WriteLine($"Light of the {_place} is open");
        }
        public void Off()
        {
            Console.WriteLine($"Light of the {_place} is close");
        }
    }
    public class CeilingFan
    {
        string _place;
        public static int HIGH = 3;
        public static int MEDIUM = 2;
        public static int LOW = 1;
        public static int OFF = 0;
        int speed;
        public CeilingFan(string place)
        {
            _place = place;
            speed = OFF;
        }
        public void High()
        {
            speed = HIGH;
            Console.WriteLine($"CeilingFan of the {_place} is high to speed {speed}");
        }

        public void Medium()
        {
            speed = MEDIUM;
            Console.WriteLine($"CeilingFan of the {_place} is medium to speed {speed}");
        }
        public void Low()
        {
            speed = LOW;
            Console.WriteLine($"CeilingFan of the {_place} is low to speed {speed}");
        }
        public void Off()
        {
            speed = OFF;
            Console.WriteLine($"CeilingFan of the {_place} is off to {speed}");
        }

        public int GetSpeed()
        {
            return speed;
        }
    }
    public class GarageDoor
    {
        string _place;
        public GarageDoor(string place)
        {
            _place = place;
        }
        public void Up()
        {
            Console.WriteLine($"Garagedoor of the {_place} is up.");
        }
        public void Down()
        {
            Console.WriteLine($"Garagedoor of the {_place} is down.");
        }
        public void Stop()
        {
            Console.WriteLine($"Garagedoor of the {_place} is stop.");
        }
    }

    public class Stereo
    {
        string _place;
        public Stereo(string place)
        {
            _place = place;
        }
        public void On()
        {
            Console.WriteLine($"Stereo of the {_place} is open");
        }
        public void Off()
        {
            Console.WriteLine($"Stereo of the {_place} is close");
        }
        public void SetCD()
        {
            Console.WriteLine($"Stereo of the {_place} sets CD");
        }
        public void SetDVD()
        {
            Console.WriteLine($"Stereo of the {_place} sets DVD");
        }
        public void SetRadio()
        {
            Console.WriteLine($"Stereo of the {_place} sets radio");
        }
        public void SetVolume(int volume)
        {
            Console.WriteLine($"Stereo of the {_place} sets volume to {volume}");
        }
    }
}
