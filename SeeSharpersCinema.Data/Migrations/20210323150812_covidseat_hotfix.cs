using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SeeSharpersCinema.Data.Migrations
{
    public partial class covidseat_hotfix : Migration
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
                    Cast = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notice",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    CinemaId = table.Column<long>(type: "bigint", nullable: false),
                    Rows = table.Column<int>(type: "int", nullable: false)
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
                    SeatId = table.Column<int>(type: "int", nullable: false),
                    RowId = table.Column<int>(type: "int", nullable: false),
                    SeatState = table.Column<int>(type: "int", nullable: false)
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
                values: new object[] { 1L, "Gedempte Zuiderdiep 78", "Groningen", "Pathé", "0885152050", 1500, 7 });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "Cast", "Country", "Description", "Director", "Duration", "Genre", "Language", "PosterUrl", "Technique", "Title", "ViewIndication", "Year" },
                values: new object[,]
                {
                    { 1L, "Sam Neill, Susan Sarandon, Anson Boon", "USA", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc elementum rutrum magna at sagittis. Curabitur viverra hendrerit enim, at gravida elit venenatis vel. Pellentesque aliquam maximus suscipit. Pellentesque et dolor elit. Duis rhoncus interdum quam, maximus pharetra tortor auctor sed. Ut congue molestie nisl ut aliquam.", "Roger Michell", 98, 6, "Original", "https://media.pathe.nl/thumb/360x508/gfx_content/other/api/filmdepot/v1/movie/download/32660_128633_ps_sd-high.jpg", "2D", "Blackbird", 5, 2021 },
                    { 2L, "Tony Chiu-Wai Leung, Maggie Cheung, Ping Lam Siu", "USA", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc elementum rutrum magna at sagittis. Curabitur viverra hendrerit enim, at gravida elit venenatis vel. Pellentesque aliquam maximus suscipit. Pellentesque et dolor elit. Duis rhoncus interdum quam, maximus pharetra tortor auctor sed. Ut congue molestie nisl ut aliquam.", "Kar-Wai Wong", 98, 6, "Original", "https://media.pathe.nl/thumb/360x508/gfx_content/other/api/filmdepot/v1/movie/download/33783_134425_ps_sd-high.jpg", "2D", "In the mood for love", 0, 2020 },
                    { 3L, "Gijs Blom, Jamie Flatters, Susan Radder", "NL", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc elementum rutrum magna at sagittis. Curabitur viverra hendrerit enim, at gravida elit venenatis vel. Pellentesque aliquam maximus suscipit. Pellentesque et dolor elit. Duis rhoncus interdum quam, maximus pharetra tortor auctor sed. Ut congue molestie nisl ut aliquam.", "Matthijs van Heijningen Jr.", 124, 6, "Nederlands", "https://media.pathe.nl/thumb/360x508/gfx_content/PathePartners/movie-25169-SlagOmDeScheldeDe_Poster_DEF.jpg", "2D", "De slag om de schelde", 5, 2021 },
                    { 4L, "Bernardo De Paula, Thom Hoffman, Lola Raie", "USA", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc elementum rutrum magna at sagittis. Curabitur viverra hendrerit enim, at gravida elit venenatis vel. Pellentesque aliquam maximus suscipit. Pellentesque et dolor elit. Duis rhoncus interdum quam, maximus pharetra tortor auctor sed. Ut congue molestie nisl ut aliquam.", "Kar-Wai Wong", 84, 10, "Nederlands", "https://media.pathe.nl/thumb/360x508/gfx_content/other/api/filmdepot/v1/movie/download/23672_133688_ps_sd-high.jpg", "3D", "Ainbo: Heldin van de amazone", 0, 2020 },
                    { 5L, "David Byrne, Jacqueline Acevedo, Gustavo Di Dalva", "USA", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc elementum rutrum magna at sagittis. Curabitur viverra hendrerit enim, at gravida elit venenatis vel. Pellentesque aliquam maximus suscipit. Pellentesque et dolor elit. Duis rhoncus interdum quam, maximus pharetra tortor auctor sed. Ut congue molestie nisl ut aliquam.", "Spike Lee", 105, 16, "Original", "https://media.pathe.nl/thumb/360x508//gfx_content/other/api/filmdepot/v1/movie/download/33816_134505_ps_sd-high.jpg", "2D", "David Byrne's amerikan utopia", 0, 2021 },
                    { 6L, "Andra Day, Trevante Rhodes, Garrett Hedlund", "USA", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc elementum rutrum magna at sagittis. Curabitur viverra hendrerit enim, at gravida elit venenatis vel. Pellentesque aliquam maximus suscipit. Pellentesque et dolor elit. Duis rhoncus interdum quam, maximus pharetra tortor auctor sed. Ut congue molestie nisl ut aliquam.", "Lee Daniels", 130, 6, "Original", "https://media.pathe.nl/thumb/360x508/gfx_content/other/api/filmdepot/v1/movie/download/33645_134768_ps_sd-high.jpg", "2D", "The united stats vs. billie holiday", 4, 2021 },
                    { 7L, "Nicolas Cage, Emma Stone, Ryan Reynolds", "USA", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc elementum rutrum magna at sagittis. Curabitur viverra hendrerit enim, at gravida elit venenatis vel. Pellentesque aliquam maximus suscipit. Pellentesque et dolor elit. Duis rhoncus interdum quam, maximus pharetra tortor auctor sed. Ut congue molestie nisl ut aliquam.", "Joel Crawford", 95, 9, "Original", "https://media.pathe.nl/thumb/360x508/gfx_content/other/api/filmdepot/v1/movie/download/23557_133608_ps_sd-high.jpg", "3D", "The croods: a new age (OV)", 1, 2020 },
                    { 8L, "Nicolas Cage, Emma Stone, Ryan Reynolds", "USA", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc elementum rutrum magna at sagittis. Curabitur viverra hendrerit enim, at gravida elit venenatis vel. Pellentesque aliquam maximus suscipit. Pellentesque et dolor elit. Duis rhoncus interdum quam, maximus pharetra tortor auctor sed. Ut congue molestie nisl ut aliquam.", "Joel Crawford", 95, 10, "Nederlands", "https://media.pathe.nl/thumb/360x508/gfx_content/other/api/filmdepot/v1/movie/download/23557_133608_ps_sd-high.jpg", "3D", "De croods 2: een nieuw begin (NL)", 1, 2020 },
                    { 9L, "Noée Abita, Jérémie Renier, Marie Denarnaud", "USA", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc elementum rutrum magna at sagittis. Curabitur viverra hendrerit enim, at gravida elit venenatis vel. Pellentesque aliquam maximus suscipit. Pellentesque et dolor elit. Duis rhoncus interdum quam, maximus pharetra tortor auctor sed. Ut congue molestie nisl ut aliquam.", "Charlène Favier", 92, 6, "Original", "https://media.pathe.nl/thumb/360x508/gfx_content/Slalom.jpg", "2D", "Slalom", 2, 2020 },
                    { 10L, "Dustin Hoffman, Toni Servillo, Valentina Bellè", "USA", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc elementum rutrum magna at sagittis. Curabitur viverra hendrerit enim, at gravida elit venenatis vel. Pellentesque aliquam maximus suscipit. Pellentesque et dolor elit. Duis rhoncus interdum quam, maximus pharetra tortor auctor sed. Ut congue molestie nisl ut aliquam.", "Donato Carrisi", 130, 8, "Original", "https://media.pathe.nl/thumb/360x508/gfx_content/other/api/filmdepot/v1/movie/download/33764_133801_ps_sd-high.jpg", "2D", "Into the labyrinth", 2, 2021 },
                    { 11L, "Charlotte Vega, Adain Bradley, Bill Sage", "USA", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc elementum rutrum magna at sagittis. Curabitur viverra hendrerit enim, at gravida elit venenatis vel. Pellentesque aliquam maximus suscipit. Pellentesque et dolor elit. Duis rhoncus interdum quam, maximus pharetra tortor auctor sed. Ut congue molestie nisl ut aliquam.", "Mike P. Nelson", 110, 2, "Original", "https://media.pathe.nl/thumb/360x508/gfx_content/other/api/filmdepot/v1/movie/download/33804_134756_ps_sd-high.jpg", "2D", "Wrong turn", 5, 2020 },
                    { 12L, "Adam Devine, Rachel Bloom, Ken Jeong", "USA", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc elementum rutrum magna at sagittis. Curabitur viverra hendrerit enim, at gravida elit venenatis vel. Pellentesque aliquam maximus suscipit. Pellentesque et dolor elit. Duis rhoncus interdum quam, maximus pharetra tortor auctor sed. Ut congue molestie nisl ut aliquam.", "David Silverman", 84, 10, "Nederlands", "https://media.pathe.nl/thumb/360x508/gfx_content/other/api/filmdepot/v1/movie/download/33774_133282_ps_sd-high.jpg", "2D", "De Flummels", 1, 2021 },
                    { 13L, "Bob Odenkirk, Aleksey Serebryakov, Connie Nielsen", "USA", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc elementum rutrum magna at sagittis. Curabitur viverra hendrerit enim, at gravida elit venenatis vel. Pellentesque aliquam maximus suscipit. Pellentesque et dolor elit. Duis rhoncus interdum quam, maximus pharetra tortor auctor sed. Ut congue molestie nisl ut aliquam.", "Ilya Naishuller", 92, 5, "Original", "https://media.pathe.nl/thumb/360x508/gfx_content/other/api/filmdepot/v1/movie/download/23923_133307_ps_sd-high.jpg", "2D", "Nobody", 5, 2021 },
                    { 14L, "Anthony Hopkins, Olivia Colman, Mark Gatiss", "USA", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc elementum rutrum magna at sagittis. Curabitur viverra hendrerit enim, at gravida elit venenatis vel. Pellentesque aliquam maximus suscipit. Pellentesque et dolor elit. Duis rhoncus interdum quam, maximus pharetra tortor auctor sed. Ut congue molestie nisl ut aliquam.", "Florian Zeller", 97, 6, "Original", "https://media.pathe.nl/thumb/360x508/gfx_content/other/api/filmdepot/v1/movie/download/33495_134471_ps_sd-high.jpg", "2D", "The Father", 2, 2020 }
                });

            migrationBuilder.InsertData(
                table: "Notice",
                columns: new[] { "Id", "Message", "isActive" },
                values: new object[] { 1L, "Houd anderhalve meter afstand van iedereen in het theater, niet eerder dan 15 minuten voor aanvang arriveren, direct na afloop van de voorstelling weer vertrekken.", true });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "Id", "Capacity", "CinemaId", "Rows" },
                values: new object[,]
                {
                    { 1L, 300, 1L, 15 },
                    { 2L, 300, 1L, 15 },
                    { 3L, 300, 1L, 15 },
                    { 4L, 300, 1L, 15 },
                    { 5L, 300, 1L, 15 },
                    { 6L, 300, 1L, 15 },
                    { 7L, 300, 1L, 15 }
                });

            migrationBuilder.InsertData(
                table: "TimeSlot",
                columns: new[] { "Id", "RoomId", "SlotEnd", "SlotStart", "Week" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2021, 3, 22, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 22, 19, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 110L, 5L, new DateTime(2021, 4, 8, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 8, 21, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 124L, 5L, new DateTime(2021, 4, 9, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 9, 19, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 125L, 5L, new DateTime(2021, 4, 9, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 9, 21, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 138L, 5L, new DateTime(2021, 4, 11, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 11, 19, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 139L, 5L, new DateTime(2021, 4, 11, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 11, 21, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 152L, 5L, new DateTime(2021, 4, 12, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 12, 19, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 153L, 5L, new DateTime(2021, 4, 12, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 12, 21, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 166L, 5L, new DateTime(2021, 4, 13, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 13, 19, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 167L, 5L, new DateTime(2021, 4, 13, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 13, 21, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 180L, 5L, new DateTime(2021, 4, 14, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 14, 19, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 181L, 5L, new DateTime(2021, 4, 14, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 14, 21, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 194L, 5L, new DateTime(2021, 4, 14, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 14, 19, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 109L, 5L, new DateTime(2021, 4, 8, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 8, 19, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 195L, 5L, new DateTime(2021, 4, 14, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 14, 21, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 209L, 5L, new DateTime(2021, 4, 16, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 16, 21, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 222L, 5L, new DateTime(2021, 4, 18, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 18, 19, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 223L, 5L, new DateTime(2021, 4, 18, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 18, 21, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 236L, 5L, new DateTime(2021, 4, 20, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 20, 19, 0, 0, 0, DateTimeKind.Unspecified), 16 },
                    { 237L, 5L, new DateTime(2021, 4, 20, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 20, 21, 0, 0, 0, DateTimeKind.Unspecified), 16 },
                    { 11L, 6L, new DateTime(2021, 3, 22, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 22, 19, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 12L, 6L, new DateTime(2021, 3, 22, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 22, 21, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 25L, 6L, new DateTime(2021, 3, 23, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 23, 19, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 26L, 6L, new DateTime(2021, 3, 23, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 23, 21, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 38L, 6L, new DateTime(2021, 3, 25, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 25, 21, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 49L, 6L, new DateTime(2021, 3, 29, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 29, 19, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 50L, 6L, new DateTime(2021, 3, 29, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 29, 21, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 208L, 5L, new DateTime(2021, 4, 16, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 16, 19, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 63L, 6L, new DateTime(2021, 4, 2, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 2, 19, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 104L, 5L, new DateTime(2021, 4, 7, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 7, 21, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 90L, 5L, new DateTime(2021, 4, 5, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 5, 21, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 150L, 4L, new DateTime(2021, 4, 12, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 12, 19, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 151L, 4L, new DateTime(2021, 4, 12, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 12, 21, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 164L, 4L, new DateTime(2021, 4, 13, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 13, 19, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 165L, 4L, new DateTime(2021, 4, 13, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 13, 21, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 178L, 4L, new DateTime(2021, 4, 14, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 14, 19, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 179L, 4L, new DateTime(2021, 4, 14, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 14, 21, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 192L, 4L, new DateTime(2021, 4, 14, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 14, 19, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 193L, 4L, new DateTime(2021, 4, 14, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 14, 21, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 206L, 4L, new DateTime(2021, 4, 15, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 15, 19, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 207L, 4L, new DateTime(2021, 4, 15, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 15, 21, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 220L, 4L, new DateTime(2021, 4, 17, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 17, 19, 0, 0, 0, DateTimeKind.Unspecified), 15 }
                });

            migrationBuilder.InsertData(
                table: "TimeSlot",
                columns: new[] { "Id", "RoomId", "SlotEnd", "SlotStart", "Week" },
                values: new object[,]
                {
                    { 221L, 4L, new DateTime(2021, 4, 17, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 17, 21, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 103L, 5L, new DateTime(2021, 4, 7, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 7, 19, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 234L, 4L, new DateTime(2021, 4, 19, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 19, 19, 0, 0, 0, DateTimeKind.Unspecified), 16 },
                    { 9L, 5L, new DateTime(2021, 3, 22, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 22, 19, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 10L, 5L, new DateTime(2021, 3, 22, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 22, 21, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 23L, 5L, new DateTime(2021, 3, 23, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 23, 19, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 24L, 5L, new DateTime(2021, 3, 23, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 23, 21, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 37L, 5L, new DateTime(2021, 3, 25, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 25, 19, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 47L, 5L, new DateTime(2021, 3, 28, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 28, 19, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 48L, 5L, new DateTime(2021, 3, 29, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 29, 21, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 61L, 5L, new DateTime(2021, 4, 1, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 1, 19, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 62L, 5L, new DateTime(2021, 4, 2, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 2, 21, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 75L, 5L, new DateTime(2021, 4, 4, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 4, 19, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 76L, 5L, new DateTime(2021, 4, 4, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 4, 21, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 89L, 5L, new DateTime(2021, 4, 5, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 5, 19, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 235L, 4L, new DateTime(2021, 4, 19, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 19, 21, 0, 0, 0, DateTimeKind.Unspecified), 16 },
                    { 137L, 4L, new DateTime(2021, 4, 10, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 10, 21, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 64L, 6L, new DateTime(2021, 4, 2, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 2, 21, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 78L, 6L, new DateTime(2021, 4, 4, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 4, 21, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 65L, 7L, new DateTime(2021, 4, 3, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 3, 19, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 66L, 7L, new DateTime(2021, 4, 3, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 3, 21, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 79L, 7L, new DateTime(2021, 4, 4, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 4, 19, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 80L, 7L, new DateTime(2021, 4, 4, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 4, 21, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 93L, 7L, new DateTime(2021, 4, 5, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 5, 19, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 94L, 7L, new DateTime(2021, 4, 5, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 5, 21, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 107L, 7L, new DateTime(2021, 4, 7, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 7, 19, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 108L, 7L, new DateTime(2021, 4, 7, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 7, 21, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 114L, 7L, new DateTime(2021, 4, 8, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 8, 19, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 115L, 7L, new DateTime(2021, 4, 8, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 8, 21, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 128L, 7L, new DateTime(2021, 4, 9, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 9, 19, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 129L, 7L, new DateTime(2021, 4, 9, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 9, 21, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 52L, 7L, new DateTime(2021, 3, 30, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 30, 21, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 142L, 7L, new DateTime(2021, 4, 11, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 11, 19, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 156L, 7L, new DateTime(2021, 4, 12, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 12, 19, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 157L, 7L, new DateTime(2021, 4, 12, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 12, 21, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 170L, 7L, new DateTime(2021, 4, 13, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 13, 19, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 171L, 7L, new DateTime(2021, 4, 13, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 13, 21, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 184L, 7L, new DateTime(2021, 4, 14, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 14, 19, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 185L, 7L, new DateTime(2021, 4, 14, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 14, 21, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 198L, 7L, new DateTime(2021, 4, 14, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 14, 19, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 199L, 7L, new DateTime(2021, 4, 14, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 14, 21, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 212L, 7L, new DateTime(2021, 4, 16, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 16, 19, 0, 0, 0, DateTimeKind.Unspecified), 15 }
                });

            migrationBuilder.InsertData(
                table: "TimeSlot",
                columns: new[] { "Id", "RoomId", "SlotEnd", "SlotStart", "Week" },
                values: new object[,]
                {
                    { 213L, 7L, new DateTime(2021, 4, 16, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 16, 21, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 226L, 7L, new DateTime(2021, 4, 18, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 18, 19, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 227L, 7L, new DateTime(2021, 4, 18, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 18, 21, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 143L, 7L, new DateTime(2021, 4, 11, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 11, 21, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 77L, 6L, new DateTime(2021, 4, 4, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 4, 19, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 51L, 7L, new DateTime(2021, 3, 30, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 30, 19, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 27L, 7L, new DateTime(2021, 3, 23, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 23, 19, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 91L, 6L, new DateTime(2021, 4, 5, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 5, 19, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 92L, 6L, new DateTime(2021, 4, 5, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 5, 21, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 105L, 6L, new DateTime(2021, 4, 7, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 7, 19, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 106L, 6L, new DateTime(2021, 4, 7, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 7, 21, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 112L, 6L, new DateTime(2021, 4, 8, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 8, 19, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 113L, 6L, new DateTime(2021, 4, 8, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 8, 21, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 126L, 6L, new DateTime(2021, 4, 9, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 9, 19, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 127L, 6L, new DateTime(2021, 4, 9, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 9, 21, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 140L, 6L, new DateTime(2021, 4, 11, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 11, 19, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 141L, 6L, new DateTime(2021, 4, 11, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 11, 21, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 154L, 6L, new DateTime(2021, 4, 12, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 12, 19, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 155L, 6L, new DateTime(2021, 4, 12, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 12, 21, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 28L, 7L, new DateTime(2021, 3, 23, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 23, 21, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 168L, 6L, new DateTime(2021, 4, 13, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 13, 19, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 182L, 6L, new DateTime(2021, 4, 14, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 14, 19, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 183L, 6L, new DateTime(2021, 4, 14, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 14, 21, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 196L, 6L, new DateTime(2021, 4, 14, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 14, 19, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 197L, 6L, new DateTime(2021, 4, 14, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 14, 21, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 210L, 6L, new DateTime(2021, 4, 16, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 16, 19, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 211L, 6L, new DateTime(2021, 4, 16, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 16, 21, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 224L, 6L, new DateTime(2021, 4, 18, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 18, 19, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 225L, 6L, new DateTime(2021, 4, 18, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 18, 21, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 238L, 6L, new DateTime(2021, 4, 20, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 20, 19, 0, 0, 0, DateTimeKind.Unspecified), 16 },
                    { 239L, 6L, new DateTime(2021, 4, 20, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 20, 21, 0, 0, 0, DateTimeKind.Unspecified), 16 },
                    { 13L, 7L, new DateTime(2021, 3, 22, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 22, 19, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 14L, 7L, new DateTime(2021, 3, 22, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 22, 21, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 169L, 6L, new DateTime(2021, 4, 13, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 13, 21, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 136L, 4L, new DateTime(2021, 4, 10, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 10, 19, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 123L, 4L, new DateTime(2021, 4, 9, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 9, 21, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 122L, 4L, new DateTime(2021, 4, 9, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 9, 19, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 215L, 1L, new DateTime(2021, 4, 17, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 17, 21, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 228L, 1L, new DateTime(2021, 4, 19, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 19, 19, 0, 0, 0, DateTimeKind.Unspecified), 16 },
                    { 229L, 1L, new DateTime(2021, 4, 19, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 19, 21, 0, 0, 0, DateTimeKind.Unspecified), 16 },
                    { 3L, 2L, new DateTime(2021, 3, 22, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 22, 19, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 4L, 2L, new DateTime(2021, 3, 22, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 22, 21, 0, 0, 0, DateTimeKind.Unspecified), 12 }
                });

            migrationBuilder.InsertData(
                table: "TimeSlot",
                columns: new[] { "Id", "RoomId", "SlotEnd", "SlotStart", "Week" },
                values: new object[,]
                {
                    { 17L, 2L, new DateTime(2021, 3, 23, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 23, 19, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 18L, 2L, new DateTime(2021, 3, 23, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 23, 21, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 30L, 2L, new DateTime(2021, 3, 24, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 24, 21, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 34L, 2L, new DateTime(2021, 3, 25, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 25, 21, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 41L, 2L, new DateTime(2021, 3, 26, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 26, 19, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 42L, 2L, new DateTime(2021, 3, 27, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 27, 21, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 55L, 2L, new DateTime(2021, 3, 31, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 31, 19, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 214L, 1L, new DateTime(2021, 4, 17, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 17, 19, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 56L, 2L, new DateTime(2021, 3, 31, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 31, 21, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 70L, 2L, new DateTime(2021, 4, 4, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 4, 21, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 83L, 2L, new DateTime(2021, 4, 5, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 5, 19, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 84L, 2L, new DateTime(2021, 4, 5, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 5, 21, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 97L, 2L, new DateTime(2021, 4, 6, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 6, 19, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 98L, 2L, new DateTime(2021, 4, 6, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 6, 21, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 118L, 2L, new DateTime(2021, 4, 9, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 9, 19, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 119L, 2L, new DateTime(2021, 4, 9, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 9, 21, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 132L, 2L, new DateTime(2021, 4, 10, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 10, 19, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 133L, 2L, new DateTime(2021, 4, 10, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 10, 21, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 146L, 2L, new DateTime(2021, 4, 12, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 12, 19, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 147L, 2L, new DateTime(2021, 4, 12, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 12, 21, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 160L, 2L, new DateTime(2021, 4, 13, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 13, 19, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 69L, 2L, new DateTime(2021, 4, 4, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 4, 19, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 161L, 2L, new DateTime(2021, 4, 13, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 13, 21, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 201L, 1L, new DateTime(2021, 4, 15, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 15, 21, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 187L, 1L, new DateTime(2021, 4, 14, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 14, 21, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 2L, 1L, new DateTime(2021, 3, 22, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 22, 21, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 15L, 1L, new DateTime(2021, 3, 23, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 23, 19, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 16L, 1L, new DateTime(2021, 3, 23, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 23, 21, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 29L, 1L, new DateTime(2021, 3, 24, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 24, 19, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 33L, 1L, new DateTime(2021, 3, 25, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 25, 19, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 39L, 1L, new DateTime(2021, 3, 26, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 26, 19, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 40L, 1L, new DateTime(2021, 3, 26, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 26, 21, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 53L, 1L, new DateTime(2021, 3, 30, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 30, 19, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 54L, 1L, new DateTime(2021, 3, 31, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 31, 21, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 67L, 1L, new DateTime(2021, 4, 4, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 4, 19, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 68L, 1L, new DateTime(2021, 4, 4, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 4, 21, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 81L, 1L, new DateTime(2021, 4, 5, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 5, 19, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 200L, 1L, new DateTime(2021, 4, 15, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 15, 19, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 82L, 1L, new DateTime(2021, 4, 5, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 5, 21, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 96L, 1L, new DateTime(2021, 4, 6, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 6, 21, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 116L, 1L, new DateTime(2021, 4, 9, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 9, 19, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 117L, 1L, new DateTime(2021, 4, 9, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 9, 21, 0, 0, 0, DateTimeKind.Unspecified), 14 }
                });

            migrationBuilder.InsertData(
                table: "TimeSlot",
                columns: new[] { "Id", "RoomId", "SlotEnd", "SlotStart", "Week" },
                values: new object[,]
                {
                    { 130L, 1L, new DateTime(2021, 4, 10, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 10, 19, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 131L, 1L, new DateTime(2021, 4, 10, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 10, 21, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 144L, 1L, new DateTime(2021, 4, 12, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 12, 19, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 145L, 1L, new DateTime(2021, 4, 12, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 12, 21, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 158L, 1L, new DateTime(2021, 4, 13, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 13, 19, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 159L, 1L, new DateTime(2021, 4, 13, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 13, 21, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 172L, 1L, new DateTime(2021, 4, 14, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 14, 19, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 173L, 1L, new DateTime(2021, 4, 14, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 14, 21, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 186L, 1L, new DateTime(2021, 4, 14, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 14, 19, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 95L, 1L, new DateTime(2021, 4, 6, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 6, 19, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 174L, 2L, new DateTime(2021, 4, 14, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 14, 19, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 175L, 2L, new DateTime(2021, 4, 14, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 14, 21, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 188L, 2L, new DateTime(2021, 4, 14, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 14, 19, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 176L, 3L, new DateTime(2021, 4, 14, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 14, 19, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 177L, 3L, new DateTime(2021, 4, 14, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 14, 21, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 190L, 3L, new DateTime(2021, 4, 14, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 14, 19, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 191L, 3L, new DateTime(2021, 4, 14, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 14, 21, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 204L, 3L, new DateTime(2021, 4, 15, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 15, 19, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 205L, 3L, new DateTime(2021, 4, 15, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 15, 21, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 218L, 3L, new DateTime(2021, 4, 17, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 17, 19, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 219L, 3L, new DateTime(2021, 4, 17, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 17, 21, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 232L, 3L, new DateTime(2021, 4, 19, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 19, 19, 0, 0, 0, DateTimeKind.Unspecified), 16 },
                    { 233L, 3L, new DateTime(2021, 4, 19, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 19, 21, 0, 0, 0, DateTimeKind.Unspecified), 16 },
                    { 7L, 4L, new DateTime(2021, 3, 22, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 22, 19, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 8L, 4L, new DateTime(2021, 3, 22, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 22, 21, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 163L, 3L, new DateTime(2021, 4, 13, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 13, 21, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 21L, 4L, new DateTime(2021, 3, 23, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 23, 19, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 32L, 4L, new DateTime(2021, 3, 24, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 24, 21, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 36L, 4L, new DateTime(2021, 3, 25, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 25, 21, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 45L, 4L, new DateTime(2021, 3, 28, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 28, 19, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 46L, 4L, new DateTime(2021, 3, 28, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 28, 21, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 59L, 4L, new DateTime(2021, 4, 1, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 1, 19, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 60L, 4L, new DateTime(2021, 4, 1, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 1, 21, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 73L, 4L, new DateTime(2021, 4, 4, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 4, 19, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 74L, 4L, new DateTime(2021, 4, 4, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 4, 21, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 87L, 4L, new DateTime(2021, 4, 5, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 5, 19, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 88L, 4L, new DateTime(2021, 4, 5, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 5, 21, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 101L, 4L, new DateTime(2021, 4, 6, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 6, 19, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 102L, 4L, new DateTime(2021, 4, 6, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 6, 21, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 22L, 4L, new DateTime(2021, 3, 23, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 23, 21, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 162L, 3L, new DateTime(2021, 4, 13, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 13, 19, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 149L, 3L, new DateTime(2021, 4, 12, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 12, 21, 0, 0, 0, DateTimeKind.Unspecified), 15 }
                });

            migrationBuilder.InsertData(
                table: "TimeSlot",
                columns: new[] { "Id", "RoomId", "SlotEnd", "SlotStart", "Week" },
                values: new object[,]
                {
                    { 148L, 3L, new DateTime(2021, 4, 12, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 12, 19, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 189L, 2L, new DateTime(2021, 4, 14, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 14, 21, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 202L, 2L, new DateTime(2021, 4, 15, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 15, 19, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 203L, 2L, new DateTime(2021, 4, 15, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 15, 21, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 216L, 2L, new DateTime(2021, 4, 17, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 17, 19, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 217L, 2L, new DateTime(2021, 4, 17, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 17, 21, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 230L, 2L, new DateTime(2021, 4, 19, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 19, 19, 0, 0, 0, DateTimeKind.Unspecified), 16 },
                    { 231L, 2L, new DateTime(2021, 4, 19, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 19, 21, 0, 0, 0, DateTimeKind.Unspecified), 16 },
                    { 5L, 3L, new DateTime(2021, 3, 22, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 22, 19, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 6L, 3L, new DateTime(2021, 3, 22, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 22, 21, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 19L, 3L, new DateTime(2021, 3, 23, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 23, 19, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 20L, 3L, new DateTime(2021, 3, 23, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 23, 21, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 31L, 3L, new DateTime(2021, 3, 24, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 24, 19, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 35L, 3L, new DateTime(2021, 3, 25, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 25, 19, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 43L, 3L, new DateTime(2021, 3, 27, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 27, 19, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 44L, 3L, new DateTime(2021, 3, 27, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 27, 21, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 57L, 3L, new DateTime(2021, 3, 31, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 31, 19, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 58L, 3L, new DateTime(2021, 3, 31, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 31, 21, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 71L, 3L, new DateTime(2021, 4, 4, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 4, 19, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 72L, 3L, new DateTime(2021, 4, 4, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 4, 21, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 85L, 3L, new DateTime(2021, 4, 5, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 5, 19, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 86L, 3L, new DateTime(2021, 4, 5, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 5, 21, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 99L, 3L, new DateTime(2021, 4, 6, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 6, 19, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 100L, 3L, new DateTime(2021, 4, 6, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 6, 21, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 120L, 3L, new DateTime(2021, 4, 9, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 9, 19, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 121L, 3L, new DateTime(2021, 4, 9, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 9, 21, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 134L, 3L, new DateTime(2021, 4, 10, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 10, 19, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 135L, 3L, new DateTime(2021, 4, 10, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 10, 21, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 240L, 7L, new DateTime(2021, 4, 20, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 20, 19, 0, 0, 0, DateTimeKind.Unspecified), 16 },
                    { 241L, 7L, new DateTime(2021, 4, 20, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 20, 21, 0, 0, 0, DateTimeKind.Unspecified), 16 }
                });

            migrationBuilder.InsertData(
                table: "PlayList",
                columns: new[] { "Id", "MovieId", "TimeSlotId" },
                values: new object[,]
                {
                    { 1L, 1L, 1L },
                    { 75L, 5L, 75L },
                    { 76L, 6L, 76L },
                    { 89L, 5L, 89L },
                    { 90L, 6L, 90L },
                    { 103L, 5L, 103L },
                    { 104L, 6L, 104L },
                    { 109L, 11L, 109L },
                    { 110L, 12L, 110L },
                    { 124L, 12L, 124L },
                    { 125L, 13L, 125L },
                    { 138L, 12L, 138L },
                    { 139L, 13L, 139L },
                    { 152L, 12L, 152L },
                    { 62L, 6L, 62L },
                    { 153L, 13L, 153L },
                    { 167L, 13L, 167L },
                    { 180L, 12L, 180L },
                    { 181L, 13L, 181L },
                    { 194L, 12L, 194L },
                    { 195L, 13L, 195L },
                    { 208L, 12L, 208L },
                    { 209L, 13L, 209L },
                    { 222L, 12L, 222L },
                    { 223L, 13L, 223L },
                    { 236L, 12L, 236L },
                    { 237L, 13L, 237L },
                    { 11L, 11L, 11L },
                    { 12L, 12L, 12L },
                    { 166L, 12L, 166L },
                    { 25L, 11L, 25L },
                    { 61L, 5L, 61L },
                    { 47L, 5L, 47L },
                    { 74L, 4L, 74L },
                    { 87L, 3L, 87L },
                    { 88L, 4L, 88L },
                    { 101L, 3L, 101L },
                    { 102L, 4L, 102L },
                    { 122L, 10L, 122L },
                    { 123L, 11L, 123L },
                    { 136L, 10L, 136L },
                    { 137L, 11L, 137L }
                });

            migrationBuilder.InsertData(
                table: "PlayList",
                columns: new[] { "Id", "MovieId", "TimeSlotId" },
                values: new object[,]
                {
                    { 150L, 10L, 150L },
                    { 151L, 11L, 151L },
                    { 164L, 10L, 164L },
                    { 165L, 11L, 165L },
                    { 48L, 6L, 48L },
                    { 178L, 10L, 178L },
                    { 192L, 10L, 192L },
                    { 193L, 11L, 193L },
                    { 206L, 10L, 206L },
                    { 207L, 11L, 207L },
                    { 220L, 10L, 220L },
                    { 221L, 11L, 221L },
                    { 234L, 10L, 234L },
                    { 235L, 11L, 235L },
                    { 9L, 9L, 9L },
                    { 10L, 10L, 10L },
                    { 23L, 9L, 23L },
                    { 24L, 10L, 24L },
                    { 37L, 9L, 37L },
                    { 179L, 11L, 179L },
                    { 26L, 12L, 26L },
                    { 38L, 10L, 38L },
                    { 49L, 7L, 49L },
                    { 51L, 9L, 51L },
                    { 52L, 10L, 52L },
                    { 65L, 9L, 65L },
                    { 66L, 10L, 66L },
                    { 79L, 9L, 79L },
                    { 80L, 10L, 80L },
                    { 93L, 9L, 93L },
                    { 94L, 10L, 94L },
                    { 107L, 9L, 107L },
                    { 108L, 10L, 108L },
                    { 114L, 2L, 114L },
                    { 115L, 3L, 115L },
                    { 128L, 2L, 128L },
                    { 28L, 14L, 28L },
                    { 129L, 3L, 129L },
                    { 143L, 3L, 143L },
                    { 156L, 2L, 156L },
                    { 157L, 3L, 157L },
                    { 170L, 2L, 170L }
                });

            migrationBuilder.InsertData(
                table: "PlayList",
                columns: new[] { "Id", "MovieId", "TimeSlotId" },
                values: new object[,]
                {
                    { 171L, 3L, 171L },
                    { 184L, 2L, 184L },
                    { 185L, 3L, 185L },
                    { 198L, 2L, 198L },
                    { 199L, 3L, 199L },
                    { 212L, 2L, 212L },
                    { 213L, 3L, 213L },
                    { 226L, 2L, 226L },
                    { 227L, 3L, 227L },
                    { 142L, 2L, 142L },
                    { 27L, 13L, 27L },
                    { 14L, 14L, 14L },
                    { 13L, 13L, 13L },
                    { 50L, 8L, 50L },
                    { 63L, 7L, 63L },
                    { 64L, 8L, 64L },
                    { 77L, 7L, 77L },
                    { 78L, 8L, 78L },
                    { 91L, 7L, 91L },
                    { 92L, 8L, 92L },
                    { 105L, 7L, 105L },
                    { 106L, 8L, 106L },
                    { 112L, 14L, 112L },
                    { 113L, 1L, 113L },
                    { 126L, 14L, 126L },
                    { 127L, 1L, 127L },
                    { 140L, 14L, 140L },
                    { 141L, 1L, 141L },
                    { 154L, 14L, 154L },
                    { 155L, 1L, 155L },
                    { 168L, 14L, 168L },
                    { 169L, 1L, 169L },
                    { 182L, 14L, 182L },
                    { 183L, 1L, 183L },
                    { 196L, 14L, 196L },
                    { 197L, 1L, 197L },
                    { 210L, 14L, 210L },
                    { 211L, 1L, 211L },
                    { 224L, 14L, 224L },
                    { 225L, 1L, 225L },
                    { 238L, 14L, 238L },
                    { 239L, 11L, 239L }
                });

            migrationBuilder.InsertData(
                table: "PlayList",
                columns: new[] { "Id", "MovieId", "TimeSlotId" },
                values: new object[,]
                {
                    { 73L, 3L, 73L },
                    { 60L, 4L, 60L },
                    { 59L, 3L, 59L },
                    { 46L, 4L, 46L },
                    { 201L, 5L, 201L },
                    { 214L, 4L, 214L },
                    { 215L, 5L, 215L },
                    { 228L, 4L, 228L },
                    { 229L, 5L, 229L },
                    { 3L, 3L, 3L },
                    { 4L, 4L, 4L },
                    { 17L, 3L, 17L },
                    { 18L, 4L, 18L },
                    { 30L, 2L, 30L },
                    { 34L, 6L, 34L },
                    { 200L, 4L, 200L },
                    { 41L, 13L, 41L },
                    { 55L, 13L, 55L },
                    { 56L, 14L, 56L },
                    { 69L, 13L, 69L },
                    { 240L, 12L, 240L },
                    { 83L, 13L, 83L },
                    { 84L, 14L, 84L },
                    { 97L, 13L, 97L },
                    { 98L, 14L, 98L },
                    { 118L, 6L, 118L },
                    { 119L, 7L, 119L },
                    { 132L, 6L, 132L },
                    { 42L, 14L, 42L },
                    { 133L, 7L, 133L },
                    { 187L, 5L, 187L },
                    { 173L, 5L, 173L },
                    { 2L, 2L, 2L },
                    { 15L, 1L, 15L },
                    { 16L, 2L, 16L },
                    { 29L, 1L, 29L },
                    { 33L, 5L, 33L },
                    { 39L, 11L, 39L },
                    { 40L, 12L, 40L },
                    { 53L, 11L, 53L },
                    { 54L, 12L, 54L },
                    { 67L, 11L, 67L }
                });

            migrationBuilder.InsertData(
                table: "PlayList",
                columns: new[] { "Id", "MovieId", "TimeSlotId" },
                values: new object[,]
                {
                    { 68L, 12L, 68L },
                    { 186L, 4L, 186L },
                    { 81L, 11L, 81L },
                    { 95L, 11L, 95L },
                    { 96L, 12L, 96L },
                    { 116L, 4L, 116L },
                    { 117L, 5L, 117L },
                    { 130L, 4L, 130L },
                    { 131L, 5L, 131L },
                    { 144L, 4L, 144L },
                    { 145L, 5L, 145L },
                    { 158L, 4L, 158L },
                    { 159L, 5L, 159L },
                    { 172L, 4L, 172L },
                    { 82L, 12L, 82L },
                    { 146L, 6L, 146L },
                    { 70L, 14L, 70L },
                    { 160L, 6L, 160L },
                    { 121L, 9L, 121L },
                    { 134L, 8L, 134L },
                    { 135L, 9L, 135L },
                    { 148L, 8L, 148L },
                    { 149L, 9L, 149L },
                    { 162L, 8L, 162L },
                    { 163L, 9L, 163L },
                    { 147L, 7L, 147L },
                    { 177L, 9L, 177L },
                    { 190L, 8L, 190L },
                    { 191L, 9L, 191L },
                    { 120L, 8L, 120L },
                    { 204L, 8L, 204L },
                    { 218L, 8L, 218L },
                    { 219L, 9L, 219L },
                    { 232L, 8L, 232L },
                    { 233L, 9L, 233L },
                    { 7L, 7L, 7L },
                    { 8L, 8L, 8L },
                    { 21L, 7L, 21L },
                    { 22L, 8L, 22L },
                    { 32L, 4L, 32L },
                    { 36L, 8L, 36L },
                    { 45L, 3L, 45L }
                });

            migrationBuilder.InsertData(
                table: "PlayList",
                columns: new[] { "Id", "MovieId", "TimeSlotId" },
                values: new object[,]
                {
                    { 205L, 9L, 205L },
                    { 100L, 2L, 100L },
                    { 176L, 8L, 176L },
                    { 86L, 2L, 86L },
                    { 161L, 7L, 161L },
                    { 174L, 6L, 174L },
                    { 99L, 1L, 99L },
                    { 188L, 6L, 188L },
                    { 189L, 7L, 189L },
                    { 202L, 6L, 202L },
                    { 203L, 7L, 203L },
                    { 216L, 6L, 216L },
                    { 217L, 7L, 217L },
                    { 230L, 6L, 230L },
                    { 231L, 7L, 231L },
                    { 5L, 5L, 5L },
                    { 175L, 7L, 175L },
                    { 19L, 5L, 19L },
                    { 85L, 1L, 85L },
                    { 6L, 6L, 6L },
                    { 72L, 2L, 72L },
                    { 71L, 1L, 71L },
                    { 58L, 2L, 58L },
                    { 241L, 13L, 241L },
                    { 44L, 2L, 44L },
                    { 43L, 1L, 43L },
                    { 35L, 7L, 35L },
                    { 31L, 3L, 31L },
                    { 57L, 1L, 57L },
                    { 20L, 6L, 20L }
                });

            migrationBuilder.InsertData(
                table: "ReservedSeat",
                columns: new[] { "Id", "RowId", "SeatId", "SeatState", "TimeSlotId" },
                values: new object[,]
                {
                    { 1L, 1, 1, 1, 1L },
                    { 2L, 1, 2, 1, 1L },
                    { 3L, 1, 3, 2, 1L },
                    { 4L, 1, 4, 1, 1L },
                    { 5L, 1, 5, 1, 1L },
                    { 6L, 2, 5, 2, 1L },
                    { 7L, 2, 6, 1, 1L },
                    { 8L, 2, 8, 1, 1L },
                    { 10L, 1, 1, 1, 2L },
                    { 11L, 1, 2, 1, 2L },
                    { 12L, 1, 3, 2, 2L },
                    { 14L, 1, 5, 1, 2L }
                });

            migrationBuilder.InsertData(
                table: "ReservedSeat",
                columns: new[] { "Id", "RowId", "SeatId", "SeatState", "TimeSlotId" },
                values: new object[,]
                {
                    { 15L, 2, 5, 2, 2L },
                    { 16L, 2, 6, 1, 2L },
                    { 17L, 2, 8, 1, 2L },
                    { 18L, 2, 9, 2, 2L },
                    { 9L, 2, 9, 2, 1L },
                    { 13L, 1, 4, 1, 2L }
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
                name: "Notice");

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
