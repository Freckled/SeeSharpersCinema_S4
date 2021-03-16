using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SeeSharpersCinema.Data.Migrations
{
    public partial class Reserved_Seats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cinema",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalRooms = table.Column<int>(type: "int", nullable: false),
                    TotalCapacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinema", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PosterUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Technique = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ViewIndication = table.Column<int>(type: "int", nullable: false),
                    Genre = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    CinemaId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_Cinema_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeSlot",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Week = table.Column<int>(type: "int", nullable: false),
                    SlotStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SlotEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoomId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSlot_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayList",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeSlotId = table.Column<long>(type: "bigint", nullable: false),
                    MovieId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayList_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayList_TimeSlot_TimeSlotId",
                        column: x => x.TimeSlotId,
                        principalTable: "TimeSlot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservedSeat",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeSlotId = table.Column<long>(type: "bigint", nullable: false),
                    SeatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservedSeat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservedSeat_TimeSlot_TimeSlotId",
                        column: x => x.TimeSlotId,
                        principalTable: "TimeSlot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    TicketID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<long>(type: "bigint", nullable: true),
                    RoomId = table.Column<long>(type: "bigint", nullable: true),
                    TimeSlotId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.TicketID);
                    table.ForeignKey(
                        name: "FK_Ticket_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_TimeSlot_TimeSlotId",
                        column: x => x.TimeSlotId,
                        principalTable: "TimeSlot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Cinema",
                columns: new[] { "Id", "Address", "City", "Name", "Phone", "TotalCapacity", "TotalRooms" },
                values: new object[] { 1L, "Gedempte Zuiderdiep 78", "Groningen", "Pathé", "0885152050", 1500, 5 });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "Country", "Description", "Director", "Duration", "Genre", "Language", "PosterUrl", "Technique", "Title", "ViewIndication", "Year" },
                values: new object[,]
                {
                    { 1L, "USA", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc elementum rutrum magna at sagittis. Curabitur viverra hendrerit enim, at gravida elit venenatis vel. Pellentesque aliquam maximus suscipit. Pellentesque et dolor elit. Duis rhoncus interdum quam, maximus pharetra tortor auctor sed. Ut congue molestie nisl ut aliquam.", "Roger Michell", 98, 7, "Original", "https://media.pathe.nl/thumb/360x508/gfx_content/other/api/filmdepot/v1/movie/download/32660_128633_ps_sd-high.jpg", "2D", "Blackbird", 5, 2021 },
                    { 2L, "USA", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc elementum rutrum magna at sagittis. Curabitur viverra hendrerit enim, at gravida elit venenatis vel. Pellentesque aliquam maximus suscipit. Pellentesque et dolor elit. Duis rhoncus interdum quam, maximus pharetra tortor auctor sed. Ut congue molestie nisl ut aliquam.", "Kar-Wai Wong", 98, 7, "Original", "https://media.pathe.nl/thumb/360x508/gfx_content/other/api/filmdepot/v1/movie/download/33783_134425_ps_sd-high.jpg", "2D", "In the mood for love", 0, 2020 },
                    { 3L, "NL", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc elementum rutrum magna at sagittis. Curabitur viverra hendrerit enim, at gravida elit venenatis vel. Pellentesque aliquam maximus suscipit. Pellentesque et dolor elit. Duis rhoncus interdum quam, maximus pharetra tortor auctor sed. Ut congue molestie nisl ut aliquam.", "Matthijs van Heijningen Jr.", 124, 7, "Nederlands", "https://media.pathe.nl/thumb/360x508/gfx_content/PathePartners/movie-25169-SlagOmDeScheldeDe_Poster_DEF.jpg", "2D", "De slag om de schelde", 5, 2021 },
                    { 4L, "USA", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc elementum rutrum magna at sagittis. Curabitur viverra hendrerit enim, at gravida elit venenatis vel. Pellentesque aliquam maximus suscipit. Pellentesque et dolor elit. Duis rhoncus interdum quam, maximus pharetra tortor auctor sed. Ut congue molestie nisl ut aliquam.", "Kar-Wai Wong", 84, 11, "Nederlands", "https://media.pathe.nl/thumb/360x508/gfx_content/other/api/filmdepot/v1/movie/download/23672_133688_ps_sd-high.jpg", "3D", "Ainbo: Heldin van de amazone", 0, 2020 },
                    { 5L, "USA", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc elementum rutrum magna at sagittis. Curabitur viverra hendrerit enim, at gravida elit venenatis vel. Pellentesque aliquam maximus suscipit. Pellentesque et dolor elit. Duis rhoncus interdum quam, maximus pharetra tortor auctor sed. Ut congue molestie nisl ut aliquam.", "Spike Lee", 105, 17, "Original", "https://media.pathe.nl/thumb/360x508//gfx_content/other/api/filmdepot/v1/movie/download/33816_134505_ps_sd-high.jpg", "2D", "David Byrne's amerikan utopia", 0, 2021 },
                    { 6L, "USA", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc elementum rutrum magna at sagittis. Curabitur viverra hendrerit enim, at gravida elit venenatis vel. Pellentesque aliquam maximus suscipit. Pellentesque et dolor elit. Duis rhoncus interdum quam, maximus pharetra tortor auctor sed. Ut congue molestie nisl ut aliquam.", "Lee Daniels", 130, 7, "Original", "https://media.pathe.nl/thumb/360x508/gfx_content/other/api/filmdepot/v1/movie/download/33645_134768_ps_sd-high.jpg", "2D", "The united stats vs. billie holiday", 4, 2021 },
                    { 7L, "USA", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc elementum rutrum magna at sagittis. Curabitur viverra hendrerit enim, at gravida elit venenatis vel. Pellentesque aliquam maximus suscipit. Pellentesque et dolor elit. Duis rhoncus interdum quam, maximus pharetra tortor auctor sed. Ut congue molestie nisl ut aliquam.", "Joel Crawford", 95, 10, "Original", "https://media.pathe.nl/thumb/360x508/gfx_content/other/api/filmdepot/v1/movie/download/23557_133608_ps_sd-high.jpg", "3D", "The croods: a new age (OV)", 1, 2020 },
                    { 8L, "USA", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc elementum rutrum magna at sagittis. Curabitur viverra hendrerit enim, at gravida elit venenatis vel. Pellentesque aliquam maximus suscipit. Pellentesque et dolor elit. Duis rhoncus interdum quam, maximus pharetra tortor auctor sed. Ut congue molestie nisl ut aliquam.", "Joel Crawford", 95, 11, "Nederlands", "https://media.pathe.nl/thumb/360x508/gfx_content/other/api/filmdepot/v1/movie/download/23557_133608_ps_sd-high.jpg", "3D", "De croods 2: een nieuw begin (NL)", 1, 2020 },
                    { 9L, "USA", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc elementum rutrum magna at sagittis. Curabitur viverra hendrerit enim, at gravida elit venenatis vel. Pellentesque aliquam maximus suscipit. Pellentesque et dolor elit. Duis rhoncus interdum quam, maximus pharetra tortor auctor sed. Ut congue molestie nisl ut aliquam.", "Charlène Favier", 92, 7, "Original", "https://media.pathe.nl/thumb/360x508/gfx_content/Slalom.jpg", "2D", "Slalom", 2, 2020 },
                    { 10L, "USA", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc elementum rutrum magna at sagittis. Curabitur viverra hendrerit enim, at gravida elit venenatis vel. Pellentesque aliquam maximus suscipit. Pellentesque et dolor elit. Duis rhoncus interdum quam, maximus pharetra tortor auctor sed. Ut congue molestie nisl ut aliquam.", "Donato Carrisi", 130, 9, "Original", "https://media.pathe.nl/thumb/360x508/gfx_content/other/api/filmdepot/v1/movie/download/33764_133801_ps_sd-high.jpg", "2D", "Into the labyrinth", 2, 2021 },
                    { 11L, "USA", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc elementum rutrum magna at sagittis. Curabitur viverra hendrerit enim, at gravida elit venenatis vel. Pellentesque aliquam maximus suscipit. Pellentesque et dolor elit. Duis rhoncus interdum quam, maximus pharetra tortor auctor sed. Ut congue molestie nisl ut aliquam.", "Mike P. Nelson", 110, 3, "Original", "https://media.pathe.nl/thumb/360x508/gfx_content/other/api/filmdepot/v1/movie/download/33804_134756_ps_sd-high.jpg", "2D", "Wrong turn", 5, 2020 },
                    { 12L, "USA", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc elementum rutrum magna at sagittis. Curabitur viverra hendrerit enim, at gravida elit venenatis vel. Pellentesque aliquam maximus suscipit. Pellentesque et dolor elit. Duis rhoncus interdum quam, maximus pharetra tortor auctor sed. Ut congue molestie nisl ut aliquam.", "David Silverman", 84, 11, "Nederlands", "https://media.pathe.nl/thumb/360x508/gfx_content/other/api/filmdepot/v1/movie/download/33774_133282_ps_sd-high.jpg", "2D", "De Flummels", 1, 2021 },
                    { 13L, "USA", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc elementum rutrum magna at sagittis. Curabitur viverra hendrerit enim, at gravida elit venenatis vel. Pellentesque aliquam maximus suscipit. Pellentesque et dolor elit. Duis rhoncus interdum quam, maximus pharetra tortor auctor sed. Ut congue molestie nisl ut aliquam.", "Ilya Naishuller", 92, 6, "Original", "https://media.pathe.nl/thumb/360x508/gfx_content/other/api/filmdepot/v1/movie/download/23923_133307_ps_sd-high.jpg", "2D", "Nobody", 5, 2021 },
                    { 14L, "USA", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc elementum rutrum magna at sagittis. Curabitur viverra hendrerit enim, at gravida elit venenatis vel. Pellentesque aliquam maximus suscipit. Pellentesque et dolor elit. Duis rhoncus interdum quam, maximus pharetra tortor auctor sed. Ut congue molestie nisl ut aliquam.", "Florian Zeller", 97, 7, "Original", "https://media.pathe.nl/thumb/360x508/gfx_content/other/api/filmdepot/v1/movie/download/33495_134471_ps_sd-high.jpg", "2D", "The Father", 2, 2020 }
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "Id", "Capacity", "CinemaId" },
                values: new object[,]
                {
                    { 1L, 300, 1L },
                    { 2L, 300, 1L },
                    { 3L, 300, 1L },
                    { 4L, 300, 1L },
                    { 5L, 300, 1L },
                    { 6L, 300, 1L },
                    { 7L, 300, 1L }
                });

            migrationBuilder.InsertData(
                table: "TimeSlot",
                columns: new[] { "Id", "RoomId", "SlotEnd", "SlotStart", "Week" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2021, 3, 9, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 9, 19, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 49L, 4L, new DateTime(2021, 3, 9, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 19, 19, 0, 0, 0, DateTimeKind.Unspecified), 11 },
                    { 50L, 4L, new DateTime(2021, 3, 9, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 19, 21, 0, 0, 0, DateTimeKind.Unspecified), 11 },
                    { 9L, 5L, new DateTime(2021, 3, 9, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 9, 19, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 10L, 5L, new DateTime(2021, 3, 9, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 9, 21, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 23L, 5L, new DateTime(2021, 3, 9, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 12, 19, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 24L, 5L, new DateTime(2021, 3, 9, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 12, 21, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 37L, 5L, new DateTime(2021, 3, 9, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 15, 19, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 38L, 5L, new DateTime(2021, 3, 9, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 16, 21, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 51L, 5L, new DateTime(2021, 3, 9, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 19, 19, 0, 0, 0, DateTimeKind.Unspecified), 11 },
                    { 52L, 5L, new DateTime(2021, 3, 9, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 20, 21, 0, 0, 0, DateTimeKind.Unspecified), 11 },
                    { 11L, 6L, new DateTime(2021, 3, 9, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 9, 19, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 36L, 4L, new DateTime(2021, 3, 9, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 15, 21, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 12L, 6L, new DateTime(2021, 3, 9, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 9, 21, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 26L, 6L, new DateTime(2021, 3, 9, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 12, 21, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 39L, 6L, new DateTime(2021, 3, 9, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 16, 19, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 40L, 6L, new DateTime(2021, 3, 9, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 16, 21, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 53L, 6L, new DateTime(2021, 3, 9, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 20, 19, 0, 0, 0, DateTimeKind.Unspecified), 11 },
                    { 54L, 6L, new DateTime(2021, 3, 9, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 20, 21, 0, 0, 0, DateTimeKind.Unspecified), 11 },
                    { 13L, 7L, new DateTime(2021, 3, 9, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 9, 19, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 14L, 7L, new DateTime(2021, 3, 9, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 9, 21, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 27L, 7L, new DateTime(2021, 3, 9, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 12, 19, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 28L, 7L, new DateTime(2021, 3, 9, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 12, 21, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 41L, 7L, new DateTime(2021, 3, 9, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 17, 19, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 42L, 7L, new DateTime(2021, 3, 9, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 17, 21, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 25L, 6L, new DateTime(2021, 3, 9, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 12, 19, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 35L, 4L, new DateTime(2021, 3, 9, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 15, 19, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 22L, 4L, new DateTime(2021, 3, 9, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 11, 21, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 21L, 4L, new DateTime(2021, 3, 9, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 11, 19, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 2L, 1L, new DateTime(2021, 3, 9, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 9, 21, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 15L, 1L, new DateTime(2021, 3, 9, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 10, 19, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 16L, 1L, new DateTime(2021, 3, 9, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 10, 21, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 29L, 1L, new DateTime(2021, 3, 9, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 13, 19, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 30L, 1L, new DateTime(2021, 3, 9, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 13, 21, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 43L, 1L, new DateTime(2021, 3, 9, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 17, 19, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 44L, 1L, new DateTime(2021, 3, 9, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 18, 21, 0, 0, 0, DateTimeKind.Unspecified), 11 },
                    { 3L, 2L, new DateTime(2021, 3, 9, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 9, 19, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 4L, 2L, new DateTime(2021, 3, 9, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 9, 21, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 17L, 2L, new DateTime(2021, 3, 9, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 10, 19, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 18L, 2L, new DateTime(2021, 3, 9, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 10, 21, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 31L, 2L, new DateTime(2021, 3, 9, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 13, 19, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 32L, 2L, new DateTime(2021, 3, 9, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 14, 21, 0, 0, 0, DateTimeKind.Unspecified), 10 }
                });

            migrationBuilder.InsertData(
                table: "TimeSlot",
                columns: new[] { "Id", "RoomId", "SlotEnd", "SlotStart", "Week" },
                values: new object[,]
                {
                    { 45L, 2L, new DateTime(2021, 3, 9, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 18, 19, 0, 0, 0, DateTimeKind.Unspecified), 11 },
                    { 46L, 2L, new DateTime(2021, 3, 9, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 18, 21, 0, 0, 0, DateTimeKind.Unspecified), 11 },
                    { 5L, 3L, new DateTime(2021, 3, 9, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 9, 19, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 6L, 3L, new DateTime(2021, 3, 9, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 9, 21, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 19L, 3L, new DateTime(2021, 3, 9, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 11, 19, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 20L, 3L, new DateTime(2021, 3, 9, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 11, 21, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 33L, 3L, new DateTime(2021, 3, 9, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 14, 19, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 34L, 3L, new DateTime(2021, 3, 9, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 14, 21, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 47L, 3L, new DateTime(2021, 3, 9, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 18, 19, 0, 0, 0, DateTimeKind.Unspecified), 11 },
                    { 48L, 3L, new DateTime(2021, 3, 9, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 18, 21, 0, 0, 0, DateTimeKind.Unspecified), 11 },
                    { 7L, 4L, new DateTime(2021, 3, 9, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 9, 19, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 8L, 4L, new DateTime(2021, 3, 9, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 9, 21, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 55L, 7L, new DateTime(2021, 3, 9, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 21, 19, 0, 0, 0, DateTimeKind.Unspecified), 11 },
                    { 56L, 7L, new DateTime(2021, 3, 9, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 21, 21, 0, 0, 0, DateTimeKind.Unspecified), 11 }
                });

            migrationBuilder.InsertData(
                table: "PlayList",
                columns: new[] { "Id", "MovieId", "TimeSlotId" },
                values: new object[,]
                {
                    { 56L, 14L, 56L },
                    { 10L, 10L, 10L },
                    { 9L, 9L, 9L },
                    { 50L, 8L, 50L },
                    { 4L, 4L, 4L },
                    { 17L, 3L, 17L },
                    { 18L, 4L, 18L },
                    { 31L, 3L, 31L },
                    { 32L, 4L, 32L },
                    { 45L, 3L, 45L },
                    { 46L, 4L, 46L },
                    { 49L, 7L, 49L },
                    { 23L, 9L, 23L },
                    { 55L, 13L, 55L },
                    { 35L, 7L, 35L },
                    { 5L, 5L, 5L },
                    { 6L, 6L, 6L },
                    { 19L, 5L, 19L },
                    { 20L, 6L, 20L },
                    { 33L, 5L, 33L },
                    { 34L, 6L, 34L },
                    { 47L, 5L, 47L },
                    { 48L, 6L, 48L },
                    { 7L, 7L, 7L },
                    { 8L, 8L, 8L },
                    { 36L, 8L, 36L },
                    { 3L, 3L, 3L },
                    { 24L, 10L, 24L },
                    { 37L, 9L, 37L },
                    { 42L, 14L, 42L },
                    { 41L, 13L, 41L },
                    { 28L, 14L, 28L },
                    { 27L, 13L, 27L },
                    { 14L, 14L, 14L },
                    { 13L, 13L, 13L },
                    { 54L, 12L, 54L },
                    { 53L, 11L, 53L },
                    { 1L, 1L, 1L },
                    { 40L, 12L, 40L },
                    { 39L, 11L, 39L },
                    { 26L, 12L, 26L },
                    { 25L, 11L, 25L }
                });

            migrationBuilder.InsertData(
                table: "PlayList",
                columns: new[] { "Id", "MovieId", "TimeSlotId" },
                values: new object[,]
                {
                    { 12L, 12L, 12L },
                    { 2L, 2L, 2L },
                    { 15L, 1L, 15L },
                    { 16L, 2L, 16L },
                    { 29L, 1L, 29L },
                    { 30L, 2L, 30L },
                    { 43L, 1L, 43L },
                    { 44L, 2L, 44L },
                    { 11L, 11L, 11L },
                    { 52L, 10L, 52L },
                    { 51L, 9L, 51L },
                    { 38L, 10L, 38L },
                    { 21L, 7L, 21L },
                    { 22L, 8L, 22L }
                });

            migrationBuilder.InsertData(
                table: "ReservedSeat",
                columns: new[] { "Id", "SeatId", "TimeSlotId" },
                values: new object[,]
                {
                    { 26L, 95, 5L },
                    { 27L, 112, 5L },
                    { 2L, 2, 1L },
                    { 3L, 4, 1L },
                    { 4L, 5, 1L },
                    { 5L, 7, 1L },
                    { 6L, 8, 1L },
                    { 7L, 10, 1L },
                    { 8L, 11, 1L },
                    { 9L, 13, 1L },
                    { 10L, 14, 2L },
                    { 11L, 16, 2L },
                    { 12L, 17, 2L },
                    { 28L, 113, 5L },
                    { 13L, 19, 2L },
                    { 15L, 1, 3L },
                    { 16L, 2, 3L },
                    { 17L, 4, 3L },
                    { 18L, 5, 3L },
                    { 19L, 7, 3L },
                    { 20L, 8, 3L },
                    { 21L, 10, 4L },
                    { 22L, 11, 4L },
                    { 23L, 50, 4L },
                    { 24L, 51, 4L },
                    { 25L, 94, 5L },
                    { 14L, 20, 2L },
                    { 1L, 1, 1L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayList_MovieId",
                table: "PlayList",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayList_TimeSlotId",
                table: "PlayList",
                column: "TimeSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservedSeat_TimeSlotId",
                table: "ReservedSeat",
                column: "TimeSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_CinemaId",
                table: "Room",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_MovieId",
                table: "Ticket",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_RoomId",
                table: "Ticket",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_TimeSlotId",
                table: "Ticket",
                column: "TimeSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlot_RoomId",
                table: "TimeSlot",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayList");

            migrationBuilder.DropTable(
                name: "ReservedSeat");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "TimeSlot");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Cinema");
        }
    }
}
