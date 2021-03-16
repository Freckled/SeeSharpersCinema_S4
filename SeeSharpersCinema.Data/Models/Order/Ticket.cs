using QRCoder;
using SeeSharpersCinema.Models.Film;
using SeeSharpersCinema.Models.Theater;
using System;
using System.Drawing;
using System.IO;

namespace SeeSharpersCinema.Models.Order
{
    public class Ticket
    {
        public long TicketID { get; set; }
        public Movie Movie { get; set; }
        public Room Room { get; set; }
        public TimeSlot TimeSlot { get; set; }

        public TicketResponse TicketResponse;

        public double BasePrice = 8.5;

        public double LongMovieAddition = 0.5;
        public double ThreeDimensionalAddition = 2.5;

        public double ChildDiscount = -1.5;
        public double StudentDiscount = -1.5;
        public double SeniorDiscount = -1.5;

        public bool IsNotHoliday = true; //TODO: het ding hier achter
        public bool IsMonToThursday = true; //TODO: het ding hier achter
        public bool IsBeforeSix = true; //TODO: het ding hier achter

        public bool IsChildDiscountValid => IsBeforeSix == Movie.IsGenreChild;
        public bool IsSeniorDiscountValid => IsMonToThursday == IsNotHoliday;
        public bool IsStudentDiscountValid => IsMonToThursday;







        public double TotalPrice()
        {
            double price = BasePrice;
            if (Movie.IsLongMovie)
            {
                price += LongMovieAddition;
            }

            if (Movie.IsThreeDimensional)
            {
                price += ThreeDimensionalAddition;
            }

/*            if (Discount == "Child" & IsChildDiscountValid)
            {
                price += ChildDiscount;
            }*/
            //if (Movie.//htmlpost input form TicketType.Student && IsStudentDiscountValid)
            //{
            //    price += StudentDiscount;
            //}
            //if (Movie.//htmlpost input form type TicketType.Senior && IsSeniorDiscountValid)
            //{
            //    price += SeniorDiscount;
            //}
            return price;
        }
        public bool isThreeD() => Movie.Technique == "3D";

        public string GetQr() => $"data:image/png;base64,{Convert.ToBase64String(GenerateQr(this))}";

        private Byte[] GenerateQr(Ticket ticket)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode("https://www.google.com", QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            return BitmapToBytesCode(qrCodeImage);
        }

        private static Byte[] BitmapToBytesCode(Bitmap image)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
    }
}
