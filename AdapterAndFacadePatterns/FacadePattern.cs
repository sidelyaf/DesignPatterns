using System;

namespace AdapterAndFacadePatterns
{
    public class FacadePattern
    {
    }

    public class HomeTheaterFacade
    {
        Amplifier amp;
        Tuner tuner;
        DvdPlayer dvd;
        CdPlayer cd;
        Projector projector;
        TheaterLights lights;
        Screen screen;
        PopcornPopper popper;

        public HomeTheaterFacade(Amplifier amp,Tuner tuner, DvdPlayer dvd, CdPlayer cd, Projector projector,
 Screen screen, TheaterLights lights, PopcornPopper popper)
        {
            this.amp = amp;
            this.tuner = tuner;
            this.dvd = dvd;
            this.cd = cd;
            this.projector = projector;
            this.screen = screen;
            this.lights = lights;
            this.popper = popper;
        }

        public void WatchMovie(String movie)
        {
            Console.WriteLine("Get ready to watch a movie...");
            popper.On();
            popper.Pop();
            lights.Dim(10);
            screen.Down();
            projector.On();
            projector.WideScreenMode();
            amp.On();
            amp.SetDvd(dvd);
            amp.SetSurroundSound();
            amp.SetVolume(5);
            dvd.On();
            dvd.Play(movie);
        }


        public void EndMovie()
        {
            Console.WriteLine("Shutting movie theater down...");
            popper.Off();
            lights.On();
            screen.Up();
            projector.Off();
            amp.Off();
            dvd.Stop();
            dvd.Eject();
            dvd.Off();
        }

        public void ListenToCd(String cdTitle)
        {
            Console.WriteLine("Get ready for an audiopile experence...");
            lights.On();
            amp.On();
            amp.SetVolume(5);
            amp.SetCd(cd);
            amp.SetStereoSound();
            cd.On();
            cd.Play(cdTitle);
        }

        public void EndCd()
        {
            Console.WriteLine("Shutting down CD...");
            amp.Off();
            amp.SetCd(cd);
            cd.Eject();
            cd.Off();
        }

        public void ListenToRadio(double frequency)
        {
            Console.WriteLine("Tuning in the airwaves...");
            tuner.On();
            tuner.SetFrequency(frequency);
            amp.On();
            amp.SetVolume(5);
            amp.SetTuner(tuner);
        }

        public void EndRadio()
        {
            Console.WriteLine("Shutting down the tuner...");
            tuner.Off();
            amp.Off();
        }
    }

    public class Tuner
    {
        string _description;
        Amplifier amp;
        public Tuner(string description, Amplifier amp)
        {
            _description = description;
            this.amp = amp;
        }

        public void On()
        {
            Console.WriteLine(_description + " on");
        }

        public void Off()
        {
            Console.WriteLine(_description + " off");
        }

        public void SetFrequency(double frequency)
        {
            Console.WriteLine(_description + " set frequency to " + frequency);
        }

        public string toString()
        {
            return _description;
        }
    }
    public class TheaterLights
    {
        string _description;
        public TheaterLights(string description)
        {
            _description = description;
        }

        public void On()
        {
            Console.WriteLine(_description + " on");
        }

        public void Off()
        {
            Console.WriteLine(_description + " off");
        }

        public void Dim(int level)
        {
            Console.WriteLine(_description + " dimming to " + level + "%");
        }

        public string toString()
        {
            return _description;
        }
    }

    public class Screen
    {
        string _description;
        public Screen(string description)
        {
            _description = description;
        }
        public void Up()
        {
            Console.WriteLine(_description + " going up");
        }

        public void Down()
        {
            Console.WriteLine(_description + " going down");
        }

        public string toString()
        {
            return _description;
        }
    }

    public class PopcornPopper
    {
        string _description;
        public PopcornPopper(string description)
        {
            _description = description;
        }
        public void On()
        {
            Console.WriteLine(_description + " on");
        }

        public void Off()
        {
            Console.WriteLine(_description + " off");
        }

        public void Pop()
        {
            Console.WriteLine(_description + " popping popcorn!");
        }

        public string toString()
        {
            return _description;
        }
    }

    public class Amplifier
    {
        string _description;
        Tuner tuner;
        DvdPlayer dvd;
        CdPlayer cd;

        public Amplifier(string description)
        {
            this._description = description;
        }

        public void On()
        {
            Console.WriteLine(_description + " on");
        }

        public void Off()
        {
            Console.WriteLine(_description + " off");
        }

        public void SetStereoSound()
        {
            Console.WriteLine(_description + " stereo mode on");
        }

        public void SetSurroundSound()
        {
            Console.WriteLine(_description + " surround sound on (5 speakers, 1 subwoofer)");
        }

        public void SetVolume(int level)
        {
            Console.WriteLine(_description + " setting volume to " + level);
        }

        public void SetTuner(Tuner tuner)
        {
            Console.WriteLine(_description + " setting tuner to " + dvd);
            this.tuner = tuner;
        }

        public void SetDvd(DvdPlayer dvd)
        {
            Console.WriteLine(_description + " setting DVD player to " + dvd);
            this.dvd = dvd;
        }

        public void SetCd(CdPlayer cd)
        {
            Console.WriteLine(_description + " setting CD player to " + cd);
            this.cd = cd;
        }

        public string toString()
        {
            return _description;
        }
    }

    public class CdPlayer
    {
        string _description;
        int currentTrack;
        Amplifier amplifier;
        String title;

        public CdPlayer(string description, Amplifier amplifier)
        {
            this._description = description;
            this.amplifier = amplifier;
        }

        public void On()
        {
            Console.WriteLine(_description + " on");
        }

        public void Off()
        {
            Console.WriteLine(_description + " off");
        }

        public void Eject()
        {
            title = null;
            Console.WriteLine(_description + " eject");
        }

        public void Play(String title)
        {
            this.title = title;
            currentTrack = 0;
            Console.WriteLine(_description + " playing \"" + title + "\"");
        }

        public void Play(int track)
        {
            if (title == null)
            {
                Console.WriteLine(_description + " can't play track " + currentTrack +
                  ", no cd inserted");
            }
            else
            {
                currentTrack = track;
                Console.WriteLine(_description + " playing track " + currentTrack);
            }
        }

        public void Stop()
        {
            currentTrack = 0;
            Console.WriteLine(_description + " stopped");
        }

        public void Pause()
        {
            Console.WriteLine(_description + " paused \"" + title + "\"");
        }

        public string toString()
        {
            return _description;
        }
    }

    public class DvdPlayer
    {
        string _description;
        int currentTrack;
        Amplifier amplifier;
        String movie;

        public DvdPlayer(string description, Amplifier amplifier)
        {
            this._description = description;
            this.amplifier = amplifier;
        }

        public void On()
        {
            Console.WriteLine(_description + " on");
        }

        public void Off()
        {
            Console.WriteLine(_description + " off");
        }

        public void Eject()
        {
            movie = null;
            Console.WriteLine(_description + " eject");
        }

        public void Play(String movie)
        {
            this.movie = movie;
            currentTrack = 0;
            Console.WriteLine(_description + " playing \"" + movie + "\"");
        }

        public void Play(int track)
        {
            if (movie == null)
            {
                Console.WriteLine(_description + " can't play track " + track + " no dvd inserted");
            }
            else
            {
                currentTrack = track;
                Console.WriteLine(_description + " playing track " + currentTrack + " of \"" + movie + "\"");
            }
        }

        public void Stop()
        {
            currentTrack = 0;
            Console.WriteLine(_description + " stopped \"" + movie + "\"");
        }

        public void Pause()
        {
            Console.WriteLine(_description + " paused \"" + movie + "\"");
        }

        public void SetTwoChannelAudio()
        {
            Console.WriteLine(_description + " set two channel audio");
        }

        public void SetSurroundAudio()
        {
            Console.WriteLine(_description + " set surround audio");
        }

        public string toString()
        {
            return _description;
        }
    }

    public class Projector
    {
        string _description;
        DvdPlayer dvdPlayer;

        public Projector(string description, DvdPlayer dvdPlayer)
        {
            this._description = description;
            this.dvdPlayer = dvdPlayer;
        }

        public void On()
        {
            Console.WriteLine(_description + " on");
        }

        public void Off()
        {
            Console.WriteLine(_description + " off");
        }

        public void WideScreenMode()
        {
            Console.WriteLine(_description + " in widescreen mode (16x9 aspect ratio)");
        }

        public void TvMode()
        {
            Console.WriteLine(_description + " in tv mode (4x3 aspect ratio)");
        }

        public string toString()
        {
            return _description;
        }
    }
}
