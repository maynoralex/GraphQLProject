using GraphQLProject.Data;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;

namespace GraphQLProject.Services;

public class ReservationRepository(GraphQLDbContext dbContext) : IReservationRepository
{
    public Reservation AddReservation(Reservation reservation)
    {
        dbContext.Reservations.Add(reservation);
        dbContext.SaveChanges();
        return reservation;
    }

    public List<Reservation> GetAllReservations()
    {
        return dbContext.Reservations.ToList();
    }
}
