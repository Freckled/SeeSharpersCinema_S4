using SeeSharpersCinema.Models.Theater;
using System.Collections.Generic;
using System;
using SeeSharpersCinema.Models.Film;
using SeeSharpersCinema.Models.Program;
using SeeSharpersCinema.Data.Models.Program;

namespace SeeSharpersCinema.Models.Database
{
    public class FakeData
    {
        public static List<Cinema> FakeCinemas
            = new List<Cinema>
            {
                new Cinema { Id = 1, Name = "Pathé", Address= "Gedempte Zuiderdiep 78", City = "Groningen", Phone = "0885152050", TotalRooms = 5, TotalCapacity = 1500 }
            };

        public static List<Room> FakeRooms
            = new List<Room>
            {
                new Room { Id = 1, Capacity = 300, CinemaId = 1 },
                new Room { Id = 2, Capacity = 300, CinemaId = 1 },
                new Room { Id = 3, Capacity = 300, CinemaId = 1 },
                new Room { Id = 4, Capacity = 300, CinemaId = 1 },
                new Room { Id = 5, Capacity = 300, CinemaId = 1 },
                new Room { Id = 6, Capacity = 300, CinemaId = 1 },
                new Room { Id = 7, Capacity = 300, CinemaId = 1 }
            };

        public static List<TimeSlot> FakeTimeSlots
            = new List<TimeSlot>
            {
                new TimeSlot { Id = 1, Week = 9, SlotStart = new DateTime(2021, 3, 9, 19, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 20, 30, 00), RoomId= 1 },
                new TimeSlot { Id = 2, Week = 9, SlotStart = new DateTime(2021, 3, 9, 21, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 23, 00, 00), RoomId= 1 },
                new TimeSlot { Id = 3, Week = 9, SlotStart = new DateTime(2021, 3, 9, 19, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 20, 30, 00), RoomId= 2 },
                new TimeSlot { Id = 4, Week = 9, SlotStart = new DateTime(2021, 3, 9, 21, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 23, 00, 00), RoomId= 2 },
                new TimeSlot { Id = 5, Week = 9, SlotStart = new DateTime(2021, 3, 9, 19, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 20, 30, 00), RoomId= 3 },
                new TimeSlot { Id = 6, Week = 9, SlotStart = new DateTime(2021, 3, 9, 21, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 23, 00, 00), RoomId= 3 },
                new TimeSlot { Id = 7, Week = 9, SlotStart = new DateTime(2021, 3, 9, 19, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 20, 30, 00), RoomId= 4 },
                new TimeSlot { Id = 8, Week = 9, SlotStart = new DateTime(2021, 3, 9, 21, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 23, 00, 00), RoomId= 4 },
                new TimeSlot { Id = 9, Week = 9, SlotStart = new DateTime(2021, 3, 9, 19, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 20, 30, 00), RoomId= 5 },
                new TimeSlot { Id = 10, Week = 9, SlotStart = new DateTime(2021, 3, 9, 21, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 23, 00, 00), RoomId= 5 },
                new TimeSlot { Id = 11, Week = 9, SlotStart = new DateTime(2021, 3, 9, 19, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 20, 30, 00), RoomId= 6 },
                new TimeSlot { Id = 12, Week = 9, SlotStart = new DateTime(2021, 3, 9, 21, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 23, 00, 00), RoomId= 6 },
                new TimeSlot { Id = 13, Week = 9, SlotStart = new DateTime(2021, 3, 9, 19, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 20, 30, 00), RoomId= 7 },
                new TimeSlot { Id = 14, Week = 9, SlotStart = new DateTime(2021, 3, 9, 21, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 23, 00, 00), RoomId= 7 }, //nieuwe fakedata sprint 2

                new TimeSlot { Id = 15, Week = 9, SlotStart = new DateTime(2021, 3, 10, 19, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 20, 30, 00), RoomId= 1 },
                new TimeSlot { Id = 16, Week = 9, SlotStart = new DateTime(2021, 3, 10, 21, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 23, 00, 00), RoomId= 1 },
                new TimeSlot { Id = 17, Week = 9, SlotStart = new DateTime(2021, 3, 10, 19, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 20, 30, 00), RoomId= 2 },
                new TimeSlot { Id = 18, Week = 9, SlotStart = new DateTime(2021, 3, 10, 21, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 23, 00, 00), RoomId= 2 },
                new TimeSlot { Id = 19, Week = 10, SlotStart = new DateTime(2021, 3, 11, 19, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 20, 30, 00), RoomId= 3 },
                new TimeSlot { Id = 20, Week = 10, SlotStart = new DateTime(2021, 3, 11, 21, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 23, 00, 00), RoomId= 3 },
                new TimeSlot { Id = 21, Week = 10, SlotStart = new DateTime(2021, 3, 11, 19, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 20, 30, 00), RoomId= 4 },
                new TimeSlot { Id = 22, Week = 10, SlotStart = new DateTime(2021, 3, 11, 21, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 23, 00, 00), RoomId= 4 },
                new TimeSlot { Id = 23, Week = 10, SlotStart = new DateTime(2021, 3, 12, 19, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 20, 30, 00), RoomId= 5 },
                new TimeSlot { Id = 24, Week = 10, SlotStart = new DateTime(2021, 3, 12, 21, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 23, 00, 00), RoomId= 5 },
                new TimeSlot { Id = 25, Week = 10, SlotStart = new DateTime(2021, 3, 12, 19, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 20, 30, 00), RoomId= 6 },
                new TimeSlot { Id = 26, Week = 10, SlotStart = new DateTime(2021, 3, 12, 21, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 23, 00, 00), RoomId= 6 },
                new TimeSlot { Id = 27, Week = 10, SlotStart = new DateTime(2021, 3, 12, 19, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 20, 30, 00), RoomId= 7 },
                new TimeSlot { Id = 28, Week = 10, SlotStart = new DateTime(2021, 3, 12, 21, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 23, 00, 00), RoomId= 7 },
                new TimeSlot { Id = 29, Week = 10, SlotStart = new DateTime(2021, 3, 13, 19, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 20, 30, 00), RoomId= 1 },
                new TimeSlot { Id = 30, Week = 10, SlotStart = new DateTime(2021, 3, 13, 21, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 23, 00, 00), RoomId= 1 },
                new TimeSlot { Id = 31, Week = 10, SlotStart = new DateTime(2021, 3, 13, 19, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 20, 30, 00), RoomId= 2 },
                new TimeSlot { Id = 32, Week = 10, SlotStart = new DateTime(2021, 3, 14, 21, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 23, 00, 00), RoomId= 2 },
                new TimeSlot { Id = 33, Week = 10, SlotStart = new DateTime(2021, 3, 14, 19, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 20, 30, 00), RoomId= 3 },
                new TimeSlot { Id = 34, Week = 10, SlotStart = new DateTime(2021, 3, 14, 21, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 23, 00, 00), RoomId= 3 },
                new TimeSlot { Id = 35, Week = 10, SlotStart = new DateTime(2021, 3, 15, 19, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 20, 30, 00), RoomId= 4 },
                new TimeSlot { Id = 36, Week = 10, SlotStart = new DateTime(2021, 3, 15, 21, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 23, 00, 00), RoomId= 4 },
                new TimeSlot { Id = 37, Week = 10, SlotStart = new DateTime(2021, 3, 15, 19, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 20, 30, 00), RoomId= 5 },
                new TimeSlot { Id = 38, Week = 10, SlotStart = new DateTime(2021, 3, 16, 21, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 23, 00, 00), RoomId= 5 },
                new TimeSlot { Id = 39, Week = 10, SlotStart = new DateTime(2021, 3, 16, 19, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 20, 30, 00), RoomId= 6 },
                new TimeSlot { Id = 40, Week = 10, SlotStart = new DateTime(2021, 3, 16, 21, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 23, 00, 00), RoomId= 6 },
                new TimeSlot { Id = 41, Week = 10, SlotStart = new DateTime(2021, 3, 17, 19, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 20, 30, 00), RoomId= 7 },
                new TimeSlot { Id = 42, Week = 10, SlotStart = new DateTime(2021, 3, 17, 21, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 23, 00, 00), RoomId= 7 },
                new TimeSlot { Id = 43, Week = 10, SlotStart = new DateTime(2021, 3, 17, 19, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 20, 30, 00), RoomId= 1 },
                new TimeSlot { Id = 44, Week = 11, SlotStart = new DateTime(2021, 3, 18, 21, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 23, 00, 00), RoomId= 1 },
                new TimeSlot { Id = 45, Week = 11, SlotStart = new DateTime(2021, 3, 18, 19, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 20, 30, 00), RoomId= 2 },
                new TimeSlot { Id = 46, Week = 11, SlotStart = new DateTime(2021, 3, 18, 21, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 23, 00, 00), RoomId= 2 },
                new TimeSlot { Id = 47, Week = 11, SlotStart = new DateTime(2021, 3, 18, 19, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 20, 30, 00), RoomId= 3 },
                new TimeSlot { Id = 48, Week = 11, SlotStart = new DateTime(2021, 3, 18, 21, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 23, 00, 00), RoomId= 3 },
                new TimeSlot { Id = 49, Week = 11, SlotStart = new DateTime(2021, 3, 19, 19, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 20, 30, 00), RoomId= 4 },
                new TimeSlot { Id = 50, Week = 11, SlotStart = new DateTime(2021, 3, 19, 21, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 23, 00, 00), RoomId= 4 },
                new TimeSlot { Id = 51, Week = 11, SlotStart = new DateTime(2021, 3, 19, 19, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 20, 30, 00), RoomId= 5 },
                new TimeSlot { Id = 52, Week = 11, SlotStart = new DateTime(2021, 3, 20, 21, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 23, 00, 00), RoomId= 5 },
                new TimeSlot { Id = 53, Week = 11, SlotStart = new DateTime(2021, 3, 20, 19, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 20, 30, 00), RoomId= 6 },
                new TimeSlot { Id = 54, Week = 11, SlotStart = new DateTime(2021, 3, 20, 21, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 23, 00, 00), RoomId= 6 },
                new TimeSlot { Id = 55, Week = 11, SlotStart = new DateTime(2021, 3, 21, 19, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 20, 30, 00), RoomId= 7 },
                new TimeSlot { Id = 56, Week = 11, SlotStart = new DateTime(2021, 3, 21, 21, 00, 00), SlotEnd = new DateTime(2021, 3, 9, 23, 00, 00), RoomId= 7 }

            };

        public static List<Movie> FakeMovies
            = new List<Movie>
            {
                new Movie
                {
                    Id = 1,
                    Title = "Blackbird",
                    PosterUrl = "https://media.pathe.nl/thumb/360x508/gfx_content/other/api/filmdepot/v1/movie/download/32660_128633_ps_sd-high.jpg",
                    Duration = 98,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc elementum rutrum magna at sagittis. Curabitur viverra hendrerit enim, at gravida elit venenatis vel. Pellentesque aliquam maximus suscipit. Pellentesque et dolor elit. Duis rhoncus interdum quam, maximus pharetra tortor auctor sed. Ut congue molestie nisl ut aliquam.",
                    Language = "Original",
                    Technique = "2D",
                    Genre = Genre.Drama,
                    ViewIndication = ViewIndication.Sixteen,
                    Year = 2021,
                    Director = "Roger Michell",
                    Country = "USA"
                },

                new Movie
                {
                    Id = 2,
                    Title = "In the mood for love",
                    PosterUrl = "https://media.pathe.nl/thumb/360x508/gfx_content/other/api/filmdepot/v1/movie/download/33783_134425_ps_sd-high.jpg",
                    Duration = 98,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc elementum rutrum magna at sagittis. Curabitur viverra hendrerit enim, at gravida elit venenatis vel. Pellentesque aliquam maximus suscipit. Pellentesque et dolor elit. Duis rhoncus interdum quam, maximus pharetra tortor auctor sed. Ut congue molestie nisl ut aliquam.",
                    Language = "Original",
                    Technique = "2D",
                    Genre = Genre.Drama,
                    ViewIndication = ViewIndication.All,
                    Year = 2020,
                    Director = "Kar-Wai Wong",
                    Country = "USA"
                },

                new Movie
                {
                    Id = 3,
                    Title = "De slag om de schelde",
                    PosterUrl = "https://media.pathe.nl/thumb/360x508/gfx_content/PathePartners/movie-25169-SlagOmDeScheldeDe_Poster_DEF.jpg",
                    Duration = 124,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc elementum rutrum magna at sagittis. Curabitur viverra hendrerit enim, at gravida elit venenatis vel. Pellentesque aliquam maximus suscipit. Pellentesque et dolor elit. Duis rhoncus interdum quam, maximus pharetra tortor auctor sed. Ut congue molestie nisl ut aliquam.",
                    Language = "Nederlands",
                    Technique = "2D",
                    Genre = Genre.Drama,
                    ViewIndication = ViewIndication.Sixteen,
                    Year = 2021,
                    Director = "Matthijs van Heijningen Jr.",
                    Country = "NL"
                },

                new Movie {
                    Id = 4,
                    Title = "Ainbo: Heldin van de amazone",
                    PosterUrl = "https://media.pathe.nl/thumb/360x508/gfx_content/other/api/filmdepot/v1/movie/download/23672_133688_ps_sd-high.jpg",
                    Duration = 84,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc elementum rutrum magna at sagittis. Curabitur viverra hendrerit enim, at gravida elit venenatis vel. Pellentesque aliquam maximus suscipit. Pellentesque et dolor elit. Duis rhoncus interdum quam, maximus pharetra tortor auctor sed. Ut congue molestie nisl ut aliquam.",
                    Language = "Nederlands",
                    Technique = "3D",
                    Genre = Genre.Children,
                    ViewIndication = ViewIndication.All,
                    Year = 2020,
                    Director = "Kar-Wai Wong",
                    Country = "USA"
                },

                new Movie {
                    Id = 5,
                    Title = "David Byrne's amerikan utopia",
                    PosterUrl = "https://media.pathe.nl/thumb/360x508//gfx_content/other/api/filmdepot/v1/movie/download/33816_134505_ps_sd-high.jpg",
                    Duration = 105,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc elementum rutrum magna at sagittis. Curabitur viverra hendrerit enim, at gravida elit venenatis vel. Pellentesque aliquam maximus suscipit. Pellentesque et dolor elit. Duis rhoncus interdum quam, maximus pharetra tortor auctor sed. Ut congue molestie nisl ut aliquam.",
                    Language = "Original",
                    Technique = "2D",
                    Genre = Genre.Documentary,
                    ViewIndication = ViewIndication.All,
                    Year = 2021,
                    Director = "Spike Lee",
                    Country = "USA"
                },

                new Movie {
                    Id = 6,
                    Title = "The united stats vs. billie holiday",
                    PosterUrl = "https://media.pathe.nl/thumb/360x508/gfx_content/other/api/filmdepot/v1/movie/download/33645_134768_ps_sd-high.jpg",
                    Duration = 130,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc elementum rutrum magna at sagittis. Curabitur viverra hendrerit enim, at gravida elit venenatis vel. Pellentesque aliquam maximus suscipit. Pellentesque et dolor elit. Duis rhoncus interdum quam, maximus pharetra tortor auctor sed. Ut congue molestie nisl ut aliquam.",
                    Language = "Original",
                    Technique = "2D",
                    Genre = Genre.Drama,
                    ViewIndication = ViewIndication.Fourteen,
                    Year = 2021,
                    Director = "Lee Daniels",
                    Country = "USA"
                },

                new Movie {
                    Id = 7,
                    Title = "The croods: a new age (OV)",
                    PosterUrl = "https://media.pathe.nl/thumb/360x508/gfx_content/other/api/filmdepot/v1/movie/download/23557_133608_ps_sd-high.jpg",
                    Duration = 95,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc elementum rutrum magna at sagittis. Curabitur viverra hendrerit enim, at gravida elit venenatis vel. Pellentesque aliquam maximus suscipit. Pellentesque et dolor elit. Duis rhoncus interdum quam, maximus pharetra tortor auctor sed. Ut congue molestie nisl ut aliquam.",
                    Language = "Original",
                    Technique = "3D",
                    Genre = Genre.Animation,
                    ViewIndication = ViewIndication.Six,
                    Year = 2020,
                    Director = "Joel Crawford",
                    Country = "USA"
                },

                new Movie {
                    Id = 8,
                    Title = "De croods 2: een nieuw begin (NL)",
                    PosterUrl = "https://media.pathe.nl/thumb/360x508/gfx_content/other/api/filmdepot/v1/movie/download/23557_133608_ps_sd-high.jpg",
                    Duration = 95,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc elementum rutrum magna at sagittis. Curabitur viverra hendrerit enim, at gravida elit venenatis vel. Pellentesque aliquam maximus suscipit. Pellentesque et dolor elit. Duis rhoncus interdum quam, maximus pharetra tortor auctor sed. Ut congue molestie nisl ut aliquam.",
                    Language = "Nederlands",
                    Technique = "3D",
                    Genre = Genre.Children,
                    ViewIndication = ViewIndication.Six,
                    Year = 2020,
                    Director = "Joel Crawford",
                    Country = "USA"
                },

                new Movie {
                    Id = 9,
                    Title = "Slalom",
                    PosterUrl = "https://media.pathe.nl/thumb/360x508/gfx_content/Slalom.jpg",
                    Duration = 92,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc elementum rutrum magna at sagittis. Curabitur viverra hendrerit enim, at gravida elit venenatis vel. Pellentesque aliquam maximus suscipit. Pellentesque et dolor elit. Duis rhoncus interdum quam, maximus pharetra tortor auctor sed. Ut congue molestie nisl ut aliquam.",
                    Language = "Original",
                    Technique = "2D",
                    Genre = Genre.Drama,
                    ViewIndication = ViewIndication.Nine,
                    Year = 2020,
                    Director = "Charlène Favier",
                    Country = "USA"
                },

                new Movie {
                    Id = 10,
                    Title = "Into the labyrinth",
                    PosterUrl = "https://media.pathe.nl/thumb/360x508/gfx_content/other/api/filmdepot/v1/movie/download/33764_133801_ps_sd-high.jpg",
                    Duration = 130,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc elementum rutrum magna at sagittis. Curabitur viverra hendrerit enim, at gravida elit venenatis vel. Pellentesque aliquam maximus suscipit. Pellentesque et dolor elit. Duis rhoncus interdum quam, maximus pharetra tortor auctor sed. Ut congue molestie nisl ut aliquam.",
                    Language = "Original",
                    Technique = "2D",
                    Genre = Genre.Crime,
                    ViewIndication = ViewIndication.Nine,
                    Year = 2021,
                    Director = "Donato Carrisi",
                    Country = "USA"
                },

                new Movie {
                    Id = 11,
                    Title = "Wrong turn",
                    PosterUrl = "https://media.pathe.nl/thumb/360x508/gfx_content/other/api/filmdepot/v1/movie/download/33804_134756_ps_sd-high.jpg",
                    Duration = 110,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc elementum rutrum magna at sagittis. Curabitur viverra hendrerit enim, at gravida elit venenatis vel. Pellentesque aliquam maximus suscipit. Pellentesque et dolor elit. Duis rhoncus interdum quam, maximus pharetra tortor auctor sed. Ut congue molestie nisl ut aliquam.",
                    Language = "Original",
                    Technique = "2D",
                    Genre = Genre.Horror,
                    ViewIndication = ViewIndication.Sixteen,
                    Year = 2020,
                    Director = "Mike P. Nelson",
                    Country = "USA"
                },

                new Movie {
                    Id = 12,
                    Title = "De Flummels",
                    PosterUrl = "https://media.pathe.nl/thumb/360x508/gfx_content/other/api/filmdepot/v1/movie/download/33774_133282_ps_sd-high.jpg",
                    Duration = 84,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc elementum rutrum magna at sagittis. Curabitur viverra hendrerit enim, at gravida elit venenatis vel. Pellentesque aliquam maximus suscipit. Pellentesque et dolor elit. Duis rhoncus interdum quam, maximus pharetra tortor auctor sed. Ut congue molestie nisl ut aliquam.",
                    Language = "Nederlands",
                    Technique = "2D",
                    Genre = Genre.Children,
                    ViewIndication = ViewIndication.Six,
                    Year = 2021,
                    Director = "David Silverman",
                    Country = "USA"
                },

                new Movie {
                    Id = 13,
                    Title = "Nobody",
                    PosterUrl = "https://media.pathe.nl/thumb/360x508/gfx_content/other/api/filmdepot/v1/movie/download/23923_133307_ps_sd-high.jpg",
                    Duration = 92,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc elementum rutrum magna at sagittis. Curabitur viverra hendrerit enim, at gravida elit venenatis vel. Pellentesque aliquam maximus suscipit. Pellentesque et dolor elit. Duis rhoncus interdum quam, maximus pharetra tortor auctor sed. Ut congue molestie nisl ut aliquam.",
                    Language = "Original",
                    Technique = "2D",
                    Genre = Genre.Thriller,
                    ViewIndication = ViewIndication.Sixteen,
                    Year = 2021,
                    Director = "Ilya Naishuller",
                    Country = "USA"
                },

                new Movie {
                    Id = 14,
                    Title = "The Father",
                    PosterUrl = "https://media.pathe.nl/thumb/360x508/gfx_content/other/api/filmdepot/v1/movie/download/33495_134471_ps_sd-high.jpg",
                    Duration = 97,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc elementum rutrum magna at sagittis. Curabitur viverra hendrerit enim, at gravida elit venenatis vel. Pellentesque aliquam maximus suscipit. Pellentesque et dolor elit. Duis rhoncus interdum quam, maximus pharetra tortor auctor sed. Ut congue molestie nisl ut aliquam.",
                    Language = "Original",
                    Technique = "2D",
                    Genre = Genre.Drama,
                    ViewIndication = ViewIndication.Nine,
                    Year = 2020,
                    Director = "Florian Zeller",
                    Country = "USA"
                }
            };

        public static List<PlayList> FakePlayLists
            = new List<PlayList>
            {
                new PlayList { Id = 1, MovieId = 1, TimeSlotId = 1 },
                new PlayList { Id = 2, MovieId = 2, TimeSlotId = 2 },
                new PlayList { Id = 3, MovieId = 3, TimeSlotId = 3 },
                new PlayList { Id = 4, MovieId = 4, TimeSlotId = 4 },
                new PlayList { Id = 5, MovieId = 5, TimeSlotId = 5 },
                new PlayList { Id = 6, MovieId = 6, TimeSlotId = 6 },
                new PlayList { Id = 7, MovieId = 7, TimeSlotId = 7 },
                new PlayList { Id = 8, MovieId = 8, TimeSlotId = 8 },
                new PlayList { Id = 9, MovieId = 9, TimeSlotId = 9 },
                new PlayList { Id = 10, MovieId = 10, TimeSlotId = 10 },
                new PlayList { Id = 11, MovieId = 11, TimeSlotId = 11 },
                new PlayList { Id = 12, MovieId = 12, TimeSlotId = 12 },
                new PlayList { Id = 13, MovieId = 13, TimeSlotId = 13 },
                new PlayList { Id = 14, MovieId = 14, TimeSlotId = 14 },
                new PlayList { Id = 15, MovieId = 1, TimeSlotId = 15 },
                new PlayList { Id = 16, MovieId = 2, TimeSlotId = 16 },
                new PlayList { Id = 17, MovieId = 3, TimeSlotId = 17 },
                new PlayList { Id = 18, MovieId = 4, TimeSlotId = 18 },
                new PlayList { Id = 19, MovieId = 5, TimeSlotId = 19 },
                new PlayList { Id = 20, MovieId = 6, TimeSlotId = 20 },
                new PlayList { Id = 21, MovieId = 7, TimeSlotId = 21 },
                new PlayList { Id = 22, MovieId = 8, TimeSlotId = 22 },
                new PlayList { Id = 23, MovieId = 9, TimeSlotId = 23 },
                new PlayList { Id = 24, MovieId = 10, TimeSlotId = 24 },
                new PlayList { Id = 25, MovieId = 11, TimeSlotId = 25 },
                new PlayList { Id = 26, MovieId = 12, TimeSlotId = 26 },
                new PlayList { Id = 27, MovieId = 13, TimeSlotId = 27 },
                new PlayList { Id = 28, MovieId = 14, TimeSlotId = 28 },
                new PlayList { Id = 29, MovieId = 1, TimeSlotId = 29 },
                new PlayList { Id = 30, MovieId = 2, TimeSlotId = 30 },
                new PlayList { Id = 31, MovieId = 3, TimeSlotId = 31 },
                new PlayList { Id = 32, MovieId = 4, TimeSlotId = 32 },
                new PlayList { Id = 33, MovieId = 5, TimeSlotId = 33 },
                new PlayList { Id = 34, MovieId = 6, TimeSlotId = 34 },
                new PlayList { Id = 35, MovieId = 7, TimeSlotId = 35 },
                new PlayList { Id = 36, MovieId = 8, TimeSlotId = 36 },
                new PlayList { Id = 37, MovieId = 9, TimeSlotId = 37 },
                new PlayList { Id = 38, MovieId = 10, TimeSlotId = 38 },
                new PlayList { Id = 39, MovieId = 11, TimeSlotId = 39 },
                new PlayList { Id = 40, MovieId = 12, TimeSlotId = 40 },
                new PlayList { Id = 41, MovieId = 13, TimeSlotId = 41 },
                new PlayList { Id = 42, MovieId = 14, TimeSlotId = 42 },
                new PlayList { Id = 43, MovieId = 1, TimeSlotId = 43 },
                new PlayList { Id = 44, MovieId = 2, TimeSlotId = 44 },
                new PlayList { Id = 45, MovieId = 3, TimeSlotId = 45 },
                new PlayList { Id = 46, MovieId = 4, TimeSlotId = 46 },
                new PlayList { Id = 47, MovieId = 5, TimeSlotId = 47 },
                new PlayList { Id = 48, MovieId = 6, TimeSlotId = 48 },
                new PlayList { Id = 49, MovieId = 7, TimeSlotId = 49 },
                new PlayList { Id = 50, MovieId = 8, TimeSlotId = 50 },
                new PlayList { Id = 51, MovieId = 9, TimeSlotId = 51 },
                new PlayList { Id = 52, MovieId = 10, TimeSlotId = 52 },
                new PlayList { Id = 53, MovieId = 11, TimeSlotId = 53 },
                new PlayList { Id = 54, MovieId = 12, TimeSlotId = 54 },
                new PlayList { Id = 55, MovieId = 13, TimeSlotId = 55 },
                new PlayList { Id = 56, MovieId = 14, TimeSlotId = 56 }
            };

        public static List<ReservedSeat> FakeReservedSeats
        = new List<ReservedSeat>
        {
                new ReservedSeat { Id = 1, TimeSlotId =1, SeatId =1 },
                new ReservedSeat { Id = 2, TimeSlotId =1, SeatId =2 },
                new ReservedSeat { Id = 3, TimeSlotId =1, SeatId =4 },
                new ReservedSeat { Id = 4, TimeSlotId =1, SeatId =5 },
                new ReservedSeat { Id = 5, TimeSlotId =1, SeatId =7 },
                new ReservedSeat { Id = 6, TimeSlotId =1, SeatId =8 },
                new ReservedSeat { Id = 7, TimeSlotId =1, SeatId =10 },
                new ReservedSeat { Id = 8, TimeSlotId =1, SeatId =11},
                new ReservedSeat { Id = 9, TimeSlotId =1, SeatId =13 },
                new ReservedSeat { Id = 10, TimeSlotId =2, SeatId =14 },
                new ReservedSeat { Id = 11, TimeSlotId =2, SeatId =16 },
                new ReservedSeat { Id = 12, TimeSlotId =2, SeatId =17 },
                new ReservedSeat { Id = 13, TimeSlotId =2, SeatId =19 },
                new ReservedSeat { Id = 14, TimeSlotId =2, SeatId =20 },
                new ReservedSeat { Id = 15, TimeSlotId =3, SeatId =1 },
                new ReservedSeat { Id = 16, TimeSlotId =3, SeatId =2 },
                new ReservedSeat { Id = 17, TimeSlotId =3, SeatId =4 },
                new ReservedSeat { Id = 18, TimeSlotId =3, SeatId =5 },
                new ReservedSeat { Id = 19, TimeSlotId =3, SeatId =7 },
                new ReservedSeat { Id = 20, TimeSlotId =3, SeatId =8 },
                new ReservedSeat { Id = 21, TimeSlotId =4, SeatId =10 },
                new ReservedSeat { Id = 22, TimeSlotId =4, SeatId =11 },
                new ReservedSeat { Id = 23, TimeSlotId =4, SeatId =50 },
                new ReservedSeat { Id = 24, TimeSlotId =4, SeatId =51 },
                new ReservedSeat { Id = 25, TimeSlotId =5, SeatId =94 },
                new ReservedSeat { Id = 26, TimeSlotId =5, SeatId =95 },
                new ReservedSeat { Id = 27, TimeSlotId =5, SeatId =112 },
                new ReservedSeat { Id = 28, TimeSlotId =5, SeatId =113 }
        };
    }
}
