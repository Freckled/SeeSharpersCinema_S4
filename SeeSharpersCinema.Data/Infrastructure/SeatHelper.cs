using SeeSharpersCinema.Data.Models.Repository;
using SeeSharpersCinema.Data.Program;
using SeeSharpersCinema.Models.Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeSharpersCinema.Data.Infrastructure
{
    public class SeatHelper
    {
        private IReservedSeatRepository seatRepository;
        private List<ReservedSeat> SeatList;
        public SeatHelper(IReservedSeatRepository seatRepository, List<ReservedSeat> SeatList)
        {
            this.seatRepository = seatRepository;
            this.SeatList = SeatList;
        }

        public async Task<List<ReservedSeat>> AddCOVIDSeats()
        {
            var ReservedSeats = await seatRepository.FindAllByTimeSlotIdAsync(SeatList[0].TimeSlotId);
            List<ReservedSeat> tempSeatList = new List<ReservedSeat>();
            SeatList.ForEach(s => tempSeatList.Add(s));
            List<ReservedSeat> ReservedSeatList = new List<ReservedSeat>();
            ReservedSeatList = ReservedSeats.ToList();
                  
                SeatList.ForEach(s =>
                {
                    if ((ReservedSeatList.FindIndex(r => r.SeatId == (s.SeatId - 1) && r.RowId == s.RowId) == -1) && SeatList.FindIndex(f => f.SeatId == (s.SeatId - 1) && f.RowId == s.RowId) == -1)
                    {
                        ReservedSeat ReservedSeat = new ReservedSeat { SeatId = (s.SeatId - 1), RowId = s.RowId, TimeSlotId = s.TimeSlotId, SeatState = SeatState.Disabled };
                        tempSeatList.Add(ReservedSeat);
                    }

                    if ((ReservedSeatList.FindIndex(r => r.SeatId == (s.SeatId + 1) && r.RowId == s.RowId) == -1) && SeatList.FindIndex(f => f.SeatId == (s.SeatId + 1) && f.RowId == s.RowId) == -1)
                    {
                        ReservedSeat ReservedSeat = new ReservedSeat { SeatId = (s.SeatId + 1), RowId = s.RowId, TimeSlotId = s.TimeSlotId, SeatState = SeatState.Disabled };
                        tempSeatList.Add(ReservedSeat);
                    }
                });
          
            return tempSeatList;
        }


        public async Task<List<ReservedSeat>> RemoveCOVIDSeats()
        {
            var ReservedSeats = await seatRepository.FindAllByTimeSlotIdAsync(SeatList[0].TimeSlotId);
            List<ReservedSeat> tempSeatList = new List<ReservedSeat>();
            SeatList.ForEach(s => tempSeatList.Add(s));
            List<ReservedSeat> ReservedSeatList = new List<ReservedSeat>();
            ReservedSeatList = ReservedSeats.ToList();

                SeatList.ForEach(s =>
                {
                    if ((ReservedSeatList.FindIndex(r => r.SeatId == (s.SeatId - 1) && r.RowId == s.RowId) >= 0) && SeatList.FindIndex(f => f.SeatId == (s.SeatId - 1) && f.RowId == s.RowId) == -1)
                    {
                        ReservedSeat ReservedSeat = new ReservedSeat { SeatId = (s.SeatId - 1), RowId = s.RowId, TimeSlotId = s.TimeSlotId, SeatState = SeatState.Disabled };
                        tempSeatList.Add(ReservedSeat);
                    }

                    if ((ReservedSeatList.FindIndex(r => r.SeatId == (s.SeatId + 1) && r.RowId == s.RowId) >= 0) && SeatList.FindIndex(f => f.SeatId == (s.SeatId + 1) && f.RowId == s.RowId) == -1)
                    {
                        ReservedSeat ReservedSeat = new ReservedSeat { SeatId = (s.SeatId + 1), RowId = s.RowId, TimeSlotId = s.TimeSlotId, SeatState = SeatState.Disabled };
                        tempSeatList.Add(ReservedSeat);
                    }
                });
            
            return tempSeatList;

        }











    }

}
