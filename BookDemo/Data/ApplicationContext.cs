using BookDemo.Models;

namespace BookDemo.Data
{
    public static class ApplicationContext
    {
        
        public static List<Book> Books { get; set; }

        static ApplicationContext()
        {
            
            Books = new List<Book>
            {
                new Book
                {
                    Id = 1,
                    Title = "The Great Gatsby",
                    Price = 150
                },
                new Book
                {
                    Id = 2,
                    Title = "To Kill a Mockingbird",
                    Price = 95
                },
                new Book
                {
                    Id = 3,
                    Title = "1984",
                    Price = 75
                }
            }; 
        }
    }
}