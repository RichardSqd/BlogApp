namespace myBlog.API.Helpers
{
    public class PaginationHeader
    {

        public int CurrentPage;
        public int ItemsPerPage;
        public int TotalItems;

        public int totalPages;
        public PaginationHeader(int currentPage, int itemsPerPage, int totalItems, int totalPages){
            this.CurrentPage = currentPage;
            this.ItemsPerPage = itemsPerPage;
            this.TotalItems = totalItems;
            this.totalPages = totalPages;
        }
    }
}