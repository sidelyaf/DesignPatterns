using System;

namespace CommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            #region Home Automation Remote Control

            HomeAutomationRemoteControl remoteControl = new HomeAutomationRemoteControl();
            Light livingRoomLight = new Light("Living Room");
            Light kitchenLight = new Light("Kitchen");
            CeilingFan ceilingFan = new CeilingFan("Living Room");
            GarageDoor garageDoor = new GarageDoor("");
            Stereo stereo = new Stereo("Living Room");

            LightOnCommand livingRoomLightOn = new LightOnCommand(livingRoomLight);
            LightOffCommand livingRoomLightOff = new LightOffCommand(livingRoomLight);
            LightOnCommand kitchenLightOn = new LightOnCommand(kitchenLight);
            LightOffCommand kitchenLightOff = new LightOffCommand(kitchenLight);
            CeilingFanHighCommand ceilingFanHigh = new CeilingFanHighCommand(ceilingFan);
            CeilingFanOffCommand ceilingFanOff =new CeilingFanOffCommand(ceilingFan);

            /// TODO: Bu çalışmamış sanki bu incelenebilir
            CeilingFanMediumCommand ceilingFanMedium =new CeilingFanMediumCommand(ceilingFan);

            GarageDoorOpenCommand garageDoorUp = new GarageDoorOpenCommand(garageDoor);
            GarageDoorDownCommand garageDoorDown = new GarageDoorDownCommand(garageDoor);
            StereoOnWithCDCommand stereoOnWithCD = new StereoOnWithCDCommand(stereo);
            StereoOffCommand stereoOff = new StereoOffCommand(stereo);

            //remoteControl.SetCommand(0, livingRoomLightOn, livingRoomLightOff);
            //remoteControl.SetCommand(1, kitchenLightOn, kitchenLightOff);
            //remoteControl.SetCommand(2, ceilingFanHigh, ceilingFanOff);
            //remoteControl.SetCommand(3, stereoOnWithCD, stereoOff);

            //remoteControl.SetCommand(0, ceilingFanMedium, ceilingFanOff);
            //remoteControl.SetCommand(1, ceilingFanHigh, ceilingFanOff);

            //Console.WriteLine(remoteControl.ToString());

            //remoteControl.OnButtonWasPushed(0);
            //remoteControl.OffButtonWasPushed(0);
            ////Console.WriteLine(remoteControl.ToString());
            ////remoteControl.UndoButtonWasPushed();
            ////Console.WriteLine(remoteControl.ToString());
            //remoteControl.OffButtonWasPushed(0);
            //remoteControl.OnButtonWasPushed(0);
            ////Console.WriteLine(remoteControl.ToString());
            //remoteControl.UndoButtonWasPushed();
            //remoteControl.OnButtonWasPushed(1);
            //remoteControl.OffButtonWasPushed(1);
            //remoteControl.OnButtonWasPushed(2);
            //remoteControl.OffButtonWasPushed(2);
            //remoteControl.OnButtonWasPushed(3);
            //remoteControl.OffButtonWasPushed(3);

            #endregion

            #region Macro command
            Light light1 = new Light("Living Room");
            CeilingFan ceilingFan1 = new CeilingFan("Living Room");
            Stereo stereo1 = new Stereo("Living Room");
            GarageDoor garageDoor1 = new GarageDoor("Garage");

            LightOnCommand lightOn1 = new LightOnCommand(light1);
            StereoOnWithCDCommand stereoOn1 = new StereoOnWithCDCommand(stereo1);
            CeilingFanHighCommand ceilingFanHighCommand = new CeilingFanHighCommand(ceilingFan1);
            GarageDoorOpenCommand garageDoorOpenCommand = new GarageDoorOpenCommand(garageDoor1);
            LightOffCommand lightOff1 = new LightOffCommand(light1);
            StereoOffCommand stereoOff1 = new StereoOffCommand(stereo1);
            CeilingFanOffCommand ceilingFanOffCommand = new CeilingFanOffCommand(ceilingFan1);
            GarageDoorDownCommand garageDoorDownCommand = new GarageDoorDownCommand(garageDoor1);

            ICommand[] partyOn = { lightOn1, stereoOn1, ceilingFanHighCommand, garageDoorOpenCommand };
            ICommand[] partyOff = { lightOff1, stereoOff1, ceilingFanOffCommand, garageDoorDownCommand };
            MacroCommand partyOnMacro = new MacroCommand(partyOn);
            MacroCommand partyOffMacro = new MacroCommand(partyOff);

            remoteControl.SetCommand(0, partyOnMacro, partyOffMacro);

            Console.WriteLine(remoteControl.ToString());
            Console.WriteLine("---Pushing Macro On-- -");
            remoteControl.OnButtonWasPushed(0);
            Console.WriteLine("---Pushing Macro Off-- -"); 
            remoteControl.OffButtonWasPushed(0);
            #endregion

            Console.ReadLine();
        }
    }
}
