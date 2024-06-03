using EmployeeDirectory.BLL.Interface.location;
using EmployeeDirectory.Models.ModelDAL;
using EmployeeDirectory.Presentation.Interface;

namespace EmployeeDirectory.Presentation.Presentation
{
    public class LocationManagment
    {
        private ILocationBL _locationBL;
        private Constants.Constants _constants;
        private Iinput _input;

        public LocationManagment(ILocationBL _locationBL, Constants.Constants _constants, Iinput _input) {
            this._locationBL = _locationBL;
            this._constants = _constants;
            this._input = _input;
        }
        public void Managment()
        {
            while (true)
            {
                Console.WriteLine();
                for (int i = 0; i < _constants.locationManagmentOption.Count; i++)
                {   
                    Console.WriteLine($"{i}.{_constants.locationManagmentOption[i]}");
                }
                Console.WriteLine("\nTo exit the option between selection press '0'"); ;
                Console.Write("Choose the option:");
                string choice = Console.ReadLine()!;
                if (choice == "e") return;
                switch (choice)
                {
                    case "0": return;
                    case "1":
                        string location = _input.GetLocation();
                        _locationBL.AddLocation(new Location {Value = location });
                        break;
                    case "2":
                        DisplayAllLocation();
                        break;
                    default:
                        Console.WriteLine("Enter Valid Input");
                        break;
                }
            }

        }
        private void DisplayAllLocation()
        {
            var locations = _locationBL.GetAllLocation();
            foreach (var location in locations)
            {
                Console.WriteLine(location.Id + " " + location.Value);
            }
        }
    }
}
