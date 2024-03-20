using HotelManagement.Business;
using HotelManagement.Data;
using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Services
{
    public class HotelService
    {
        private readonly HotelContext _context;
        private readonly HotelBusiness _business;

        public HotelService()
        {
            _context = new HotelContext();
            _business = new HotelBusiness();
        }

        public List<HotelRoom> GetAvailableRooms(DateTime checkInDate, DateTime checkOutDate)
        {
            var occupiedRooms = _context.Reservations
                .Where(r => r.CheckInDate <= checkOutDate && r.CheckOutDate >= checkInDate)
                .Select(r => r.RoomNumber)
                .ToList();

            return _context.HotelRooms.Where(r => !occupiedRooms.Contains(r.RoomNumber)).ToList();
        }

        public void MakeReservation(int roomNumber, DateTime checkInDate, DateTime checkOutDate)
        {
            if (!_business.IsValidReservation(checkInDate, checkOutDate))
            {
                throw new ArgumentException("Invalid reservation dates.");
            }

            var room = _context.HotelRooms.SingleOrDefault(r => r.RoomNumber == roomNumber);
            if (room == null)
            {
                throw new ArgumentException("Invalid room number.");
            }

            var reservation = new Reservation
            {
                RoomNumber = roomNumber,
                CheckInDate = checkInDate,
                CheckOutDate = checkOutDate,
                TotalCost = (checkOutDate - checkInDate).Days * room.PricePerNight
            };

            _context.Reservations.Add(reservation);
            _context.SaveChanges();
        }
        public void CancelReservation(int reservationId)
        {
            var reservation = _context.Reservations.FirstOrDefault(r => r.ReservationId == reservationId);
            if (reservation == null)
            {
                throw new ArgumentException("Reservation not found.");
            }

            _context.Reservations.Remove(reservation);
            _context.SaveChanges();
        }
        public List<Reservation> GetAllReservations()
        {
            return _context.Reservations.ToList();
        }
    }
}
