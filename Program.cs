using HotelManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var hotelService = new HotelService();

            Console.WriteLine("Welcome to Hotel Management System");

            while (true)
            {
                Console.WriteLine("-------------------------------------\n               Menu: \n-------------------------------------");
                Console.WriteLine("1. Check Available Rooms");
                Console.WriteLine("2. Make Reservation");
                Console.WriteLine("3. View Reservations");
                Console.WriteLine("4. Cancel Reservation");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter check-in date (yyyy-mm-dd): ");
                        var checkInDate = DateTime.Parse(Console.ReadLine());

                        Console.Write("Enter check-out date (yyyy-mm-dd): ");
                        var checkOutDate = DateTime.Parse(Console.ReadLine());

                        var availableRooms = hotelService.GetAvailableRooms(checkInDate, checkOutDate);
                        Console.WriteLine("\nAvailable Rooms:");
                        foreach (var room in availableRooms)
                        {
                            Console.WriteLine($"Room Number: {room.RoomNumber}, Type: {room.RoomType}, Price: {room.PricePerNight}");
                        }
                        break;

                    case 2:
                        Console.Write("Enter room number: ");
                        var roomNumber = int.Parse(Console.ReadLine());

                        Console.Write("Enter check-in date (yyyy-mm-dd): ");
                        checkInDate = DateTime.Parse(Console.ReadLine());

                        Console.Write("Enter check-out date (yyyy-mm-dd): ");
                        checkOutDate = DateTime.Parse(Console.ReadLine());

                        try
                        {
                            hotelService.MakeReservation(roomNumber, checkInDate, checkOutDate);
                            Console.WriteLine("Reservation successfully made.");
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 3:
                        var allReservations = hotelService.GetAllReservations();
                        Console.WriteLine("\nAll Reservations:");
                        foreach (var reservation in allReservations)
                        {
                            Console.WriteLine($"Reservation ID: {reservation.ReservationId}, Room Number: {reservation.RoomNumber}, Check-In Date: {reservation.CheckInDate}, Check-Out Date: {reservation.CheckOutDate}, Total Cost: {reservation.TotalCost}");
                        }
                        break;

                    case 4:
                        Console.Write("Enter reservation ID to cancel: ");
                        var reservationId = int.Parse(Console.ReadLine());

                        try
                        {
                            hotelService.CancelReservation(reservationId);
                            Console.WriteLine("Reservation successfully canceled.");
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 5:
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please select again.");
                        break;
                }
            }
        }
    }
}
