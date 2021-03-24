using SeeSharpersCinema.Data.Infrastructure;
using SeeSharpersCinema.Data.Models.Program;
using SeeSharpersCinema.Data.Program;
using SeeSharpersCinema.Models.Program;
using SeeSharpersCinema.Models.Theater;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using Xunit;

namespace SeeSharpersCinema.Tests
{
    public class JSONSeatingHelperTests
    {
        [Fact]
        public void GenerateCorrectJson()
        {
            // Arrange
            Room room = new Room { Id = 1, Capacity = 2, Rows = 2 };
            ReservedSeat rS = new ReservedSeat { Id = 1, RowId = 1, SeatId = 1, SeatState = SeatState.Reserved };
            List<ReservedSeat> seats = new List<ReservedSeat> { rS };

            // Arrange
            List<ObjRow> ObjRowList = new List<ObjRow>();
            for (var j = 1; j <= room.Rows; j++)
            {
                List<ObjSeat> objSeatList = new List<ObjSeat>();
                for (var i = 1; i <= (room.Capacity / room.Rows); i++)
                {

                    ObjSeat ObjSeat = new ObjSeat { GridSeatNum = i, seatNumber = i, SeatStatus = "0" };
                    var seatTaken = 0;
                    seats.ForEach(s =>
                    {
                        if (s.SeatId == i & s.RowId == j & s.SeatState == SeatState.Reserved)
                        {
                            seatTaken = 1;
                        }
                        if (s.SeatId == i & s.RowId == j & s.SeatState == SeatState.Disabled)
                        {
                            seatTaken = 2;
                        }
                    });
                    if (seatTaken > 0)
                    {
                        ObjSeat.SeatStatus = seatTaken.ToString();
                        seatTaken = 0;
                    }

                    objSeatList.Add(ObjSeat);
                }
                ObjRow ObjRow = new ObjRow { GridRowId = j, PhyRowId = j.ToString(), objSeat = objSeatList };
                ObjRowList.Add(ObjRow);
            }

            ObjArea ObjArea = new ObjArea { AreaDesc = "EXECUTIVE", AreaCode = "0000000003", AreaNum = "1", HasCurrentOrder = true, objRow = ObjRowList };
            List<ObjArea> ObjAreaList = new List<ObjArea>();
            ObjAreaList.Add(ObjArea);


            ColAreas ColAreas = new ColAreas { Count = 1, intMaxSeatId = 21, intMinSeatId = 2, objArea = ObjAreaList };
            SeatLayout SeatLayout = new SeatLayout { colAreas = ColAreas };
            List<object> areaList = new List<object>();
            List<object> groupedSeatsList = new List<object>();

            Root Root = new Root
            {
                product_id = 46539040,
                freeSeating = false,
                tempTransId = "1ecae165f2d86315fea19963d0ded41a",
                seatLayout = SeatLayout,
                areas = areaList,
                groupedSeats = groupedSeatsList
            };

            var encoderSettings = new TextEncoderSettings();
            encoderSettings.AllowCharacters('\u0022');
            encoderSettings.AllowRange(UnicodeRanges.BasicLatin);
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(encoderSettings),
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(Root, options);

            // Act
            string sut = JSONSeatingHelper.JSONSeating(room, seats);

            // Assert
            Assert.Equal(sut, jsonString);

        }
    }
}
