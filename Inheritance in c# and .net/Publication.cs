using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_in_c__and_.net
{
    #region PublicationType
    public enum PublicationType { Misc, Book, Magazine, Article };
    #endregion

    #region Publication class
    public abstract class Publication
    {
        private bool _published = false;
        private DateTime _datePublished;
        private int _totalPages;

        public Publication(string title, string publisher, PublicationType type)
        {
            if (string.IsNullOrWhiteSpace(publisher))
                throw new ArgumentException("The publisher is required.");
            Publisher = publisher;

            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("The title is required.");
            Title = title;

            Type = type;
        }

        public string Publisher { get; }

        public string Title { get; }

        public PublicationType Type { get; } //-> public enum PublicationType { Misc, Book, Magazine, Article };

        public string? CopyrightName { get; private set; }

        public int CopyrightDate { get; private set; }

        public int Pages
        {
            get { return _totalPages; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "The number of pages cannot be zero or negative.");
                _totalPages = value;
            }
        }

        public string GetPublicationDate()
        {
            if (!_published) //if _published is true -> _published = false => "NYP" becus that -> we used (!_published)
                return "NYP";
            else
                return _datePublished.ToString("d");
        }

        public void Publish(DateTime datePublished)
        {
            _published = true;
            _datePublished = datePublished;
        }

        public void Copyright(string copyrightName, int copyrightDate)
        {
            if (string.IsNullOrWhiteSpace(copyrightName))
                throw new ArgumentException("The name of the copyright holder is required.");
            CopyrightName = copyrightName;

            int currentYear = DateTime.Now.Year;
            if (copyrightDate < currentYear - 10 || copyrightDate > currentYear + 2)
                throw new ArgumentOutOfRangeException($"The copyright year must be between {currentYear - 10} and {currentYear + 1}");
            CopyrightDate = copyrightDate;
        }

        public override string ToString() => Title;

        //Because the Publication class is abstract, it cannot be instantiated directly from code like the following example:

        //var publication = new Publication("Tiddlywinks for Experts", "Fun and Games",PublicationType.Book);

        /* However, its instance constructor can be called directly 
         * from derived class constructors, as the source code for the Book class shows. */
    }
    #endregion

    #region Book:Publication
    public sealed class Book : Publication
    {
        public Book(string title, string author, string publisher) :
               this(title, string.Empty, author, publisher)
        { }

        public Book(string title, string isbn, string author, string publisher) : base(title, publisher, PublicationType.Book)
        {
            // isbn argument must be a 10- or 13-character numeric string without "-" characters.
            // We could also determine whether the ISBN is valid by comparing its checksum digit
            // with a computed checksum.
            //
            if (!string.IsNullOrEmpty(isbn))// string.IsNullOrEmpty(isbn)==true ==> this if is work
            {
                // Determine if ISBN length is correct.
                if (!(isbn.Length == 10 | isbn.Length == 13))
                    throw new ArgumentException("The ISBN must be a 10- or 13-character numeric string.");
                if (!ulong.TryParse(isbn, out _))
                    throw new ArgumentException("The ISBN can consist of numeric characters only.");
            }
            ISBN = isbn;

            Author = author;
        }

        public string ISBN { get; }

        public string Author { get; }

        public decimal Price { get; private set; }

        // A three-digit ISO currency symbol.
        public string? Currency { get; private set; }

        // Returns the old price, and sets a new price.
        public decimal SetPrice(decimal price, string currency)
        {
            if (price < 0)
                throw new ArgumentOutOfRangeException(nameof(price), "The price cannot be negative.");
            decimal oldValue = Price;
            Price = price;

            if (currency.Length != 3)
                throw new ArgumentException("The ISO currency symbol is a 3-character string.");
            Currency = currency;

            return oldValue;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Book book)
                return false;
            else
                return ISBN == book.ISBN;
        }

        public override int GetHashCode() => ISBN.GetHashCode();

        public override string ToString() => $"{(string.IsNullOrEmpty(Author) ? "" : Author + ", ")}{Title}";
    }
    #endregion
}
