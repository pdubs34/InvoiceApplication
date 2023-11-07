namespace InvoiceApplication.Models.DataModels
{
    public class DayData
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Precipitation { get; set; }
        public string Temp { get; set; }
        public double Retail { get; set; }

        public DayData()
        {
            Date = DateTime.Now;
            Precipitation = string.Empty;
            Temp = string.Empty;
        }
    }
}
