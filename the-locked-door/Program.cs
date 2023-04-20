using System;

namespace the_locked_door;
class Program
{
    static void Main(string[] args)
    {
        // Setup the console
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("The Locked Door");
        
        // Prompt user for passcode
        Console.Write("Please enter an initial passcode for the door: ");
        string initialPasscode = Console.ReadLine();

        // Create a new door with the passcode
        Door door = new Door(initialPasscode);

        // Prompt user
        string input;
        do
        {
            Console.Write("Transition (open, close, lock, unlock, change, quit): ");
            input = Console.ReadLine();
            switch (input)
            {
                case "open":
                    door.Open();
                    break;
                case "close":
                    door.Close();
                    break;
                case "lock":
                    door.Lock();
                    break;
                case "unlock":
                    Console.Write("Please enter the door passcode: ");
                    string passcode = Console.ReadLine();
                    door.Unlock(passcode);
                    break;
                case "change":
                    Console.Write("Please enter the old passcode: ");
                    string oldPasscode = Console.ReadLine();
                    Console.Write("Please enter the new passcode: ");
                    string newPasscode = Console.ReadLine();
                    door.ChangePasscode(oldPasscode, newPasscode);
                    break;
            }
            door.displayStatus();
        } while (input != "quit");

    }

    public class Door {
        private string _passcode;
        private DoorState _doorState;

        public Door(string passcode) {
            _passcode = passcode;
            _doorState = DoorState.Locked;
        }

        public void Open() {
            if (_doorState == DoorState.Closed) _doorState = DoorState.Open;
        }

        public void Close() {
            if (_doorState == DoorState.Open) _doorState = DoorState.Closed;
        }

        public void Lock() {
            if (_doorState == DoorState.Closed) _doorState = DoorState.Locked;
        }

        public void Unlock(string passcode) {
            if (_doorState == DoorState.Locked && passcode == _passcode) _doorState = DoorState.Closed;
        }

        public void ChangePasscode(string oldPasscode, string newPasscode) {
            if (_passcode == oldPasscode) _passcode = newPasscode;
        }

        public void displayStatus() {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Door is in a {_doorState} state.");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    public enum DoorState { Open, Closed, Locked }
}
