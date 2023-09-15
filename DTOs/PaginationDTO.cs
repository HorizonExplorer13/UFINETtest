namespace UFINETTest.DTOs
{
    public class PaginationDTO
    {
        public int PageNumber { get; set; } = 1;
        private int RowsperPage { get; set; } = 1;
        private readonly int MaxRowsPerPage = 2;

        public int RowPerPage
        {
            get
            {
                return RowsperPage;
            }
            set {
            RowsperPage = (value > MaxRowsPerPage) ? MaxRowsPerPage : value;
            }
        }
    }
}
