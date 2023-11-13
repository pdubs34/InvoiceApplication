namespace InvoiceApplication.Services
{
    public class DataProcessor
    {
        private string Data;
        public DataProcessor() {
            Data = string.Empty;
        }
        public DataProcessor(string data)
        {
            Data = data;
        }
        public string ProcessData()
        {
            return Data;
            /* parse and insert items into database
             * Note: Will eventually need to make 3 functions, one to parse, one to validate, and one to insert into DB
            */

        }
    }
}
