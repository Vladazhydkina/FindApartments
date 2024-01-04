using System;
using System.Collections.Generic;

class Apartment
{
    public string Address { get; set; }
    public int Rooms { get; set; }
    public double Price { get; set; }
}

interface IAgencyObserver
{
    void Update(Apartment apartment);
}

class RealEstateAgency : IAgencyObserver
{
    private List<Apartment> apartmentsDatabase = new List<Apartment>();

    public void RegisterApartment(Apartment apartment)
    {
        apartmentsDatabase.Add(apartment);
        Console.WriteLine($"Apartment at {apartment.Address} registered in the database.");
    }

    public void Update(Apartment apartment)
    {
        apartmentsDatabase.Add(apartment);
        Console.WriteLine($"New apartment received: {apartment.Address}");
    }

    public List<Apartment> FindApartmentsMatchingCriteria(int minRooms, double maxPrice)
    {

        List<Apartment> matchingApartments = new List<Apartment>();
        foreach (var apartment in apartmentsDatabase)
        {
            if (apartment.Rooms >= minRooms && apartment.Price <= maxPrice)
            {
                matchingApartments.Add(apartment);
            }
        }
        return matchingApartments;
    }
}

class RealEstateFacade
{
    private RealEstateAgency agency;

    public RealEstateFacade()
    {
        agency = new RealEstateAgency();
    }

    public void RegisterApartment(Apartment apartment)
    {
        agency.RegisterApartment(apartment);
    }

    public void FindApartmentsForBuyer(int minRooms, double maxPrice)
    {
        List<Apartment> matchingApartments = agency.FindApartmentsMatchingCriteria(minRooms, maxPrice);

        Console.WriteLine($"Found {matchingApartments.Count} apartments matching criteria.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        RealEstateFacade facade = new RealEstateFacade();

        Apartment apartment1 = new Apartment { Address = "123 Main St", Rooms = 3, Price = 150000 };
        Apartment apartment2 = new Apartment { Address = "456 Elm St", Rooms = 2, Price = 120000 };

        facade.RegisterApartment(apartment1);
        facade.RegisterApartment(apartment2);

        // Логіка покупця
        int minRooms = 2;
        double maxPrice = 130000;
        facade.FindApartmentsForBuyer(minRooms, maxPrice);
    }
}


