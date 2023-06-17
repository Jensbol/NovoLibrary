using System.Text.Json.Serialization;

namespace NovoLibrary.Models.DTOs
{
    public class BorrowTransactionDto
    {

        public int BookId { get; set; }
        public int MemberId { get; set; }
        
        public DateTime BorrowDate { get; set; }

        public DateTime? ReturnDate { get; set; }

    }
}
