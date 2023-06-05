namespace NovoLibrary.Models
{
    public class BorrowTransaction
    {
        public int Id { get; set; }

        public int BookId { get; set; }
        public int MemberId { get; set; }
        
        public DateTime BorrowDate { get; set; }

        public DateTime? ReturnDate { get; set; }
    }
}
