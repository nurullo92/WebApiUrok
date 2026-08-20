using EF_Urok.Data;
using EF_Urok.Model;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EF_Urok.Repositories
{
    public class BookReapository
    {
        private readonly AppDbContext db;
        public BookReapository(AppDbContext db) 
        {
            this.db = db;
        }


        /// <summary>
        /// Выбор обькта из бд по (id)
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Book? GetById(int Id)
        {
            return db.Books.Find(Id);
        }


        /// <summary>
        /// Вывод всех обьяектов из бд.
        /// </summary>
        /// <returns></returns>
        public List<Book> GetAll()
        {
            return db.Books.ToList();
        }


        /// <summary>
        /// Добавление новой книги в бд.
        /// </summary>
        /// <param name="book"></param>
        public void Add(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
        }


        /// <summary>
        /// Удаление книги из бд.
        /// </summary>
        /// <param name="Id"></param>
        public void Delete(int Id)
        {
            var book = db.Books.Find(Id);

            if (book == null) return;
            
            db.Books.Remove(book);
            db.SaveChanges();
        }


        /// <summary>
        /// Обнавление года выпуска книги по (id).
        /// </summary>
        /// <param name="book"></param>
        public void Update(Book book)
        {
            var books = db.Books.Find(book.Id);

            if (books == null) return;
            
            books.Year = book.Year;
            db.SaveChanges();
        }




        public List<Book> GetUserBooks(User user)
        {
            return db.Borrowins
                .Where(b => b.UserId == user.Id)
                .Select(b => b.Book)
                .ToList();
        }


        /// <summary>
        /// Получать список книг определенного жанра и вышедших между определенными годами.
        /// </summary>
        /// <param name="genreId"></param>
        /// <param name="fromYear"></param>
        /// <param name="toYear"></param>
        /// <returns></returns>
        public List<Book> ListBooks(int genreId, int fromYear, int toYear)
        {
            return db.Books
            .Where(b => b.GenreId == genreId
                     && b.Year >= fromYear
                     && b.Year <= toYear)
            .ToList();


        }



        /// <summary>
        /// Получать количество книг определенного автора в библиотеке.
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns></returns>
        public int CountBook(int authorId)
        {
            return db.Books
                   .Count(b => b.AuthorId == authorId);
        }


        /// <summary>
        /// Получать количество книг определенного жанра в библиотеке.
        /// </summary>
        /// <param name="genreId"></param>
        /// <returns></returns>
        public int CountGenre(int genreId)
        {
            return db.Books.Count(b => b.GenreId == genreId);
        }


        /// <summary>
        /// Получать булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns></returns>
        public bool HasBook(int authorId, string title)
        {
            return db.Books.Any(b => b.AuthorId == authorId && b.Title == title);
        }


        /// <summary>
        /// Получать булевый флаг о том, есть ли определенная книга на руках у пользователя.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public bool GetBoolGenreName(int userId, int bookId)
        {
            return db.Borrowins.Any(ub => ub.BookId == bookId
                                    && ub.UserId == userId);
        }


        /// <summary>
        /// Получать количество книг на руках у пользователя.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int IsBookBorrowedByUser(int userId)
        {
            return db.Borrowins.Count(u => u.UserId == userId);
        }



        /// <summary>
        /// Получение последней вышедшей книги.
        /// </summary>
        /// <returns></returns>
        public Book? GetLatestBook()
        {
            return db.Books
                .OrderByDescending(b => b.Year)
                .ThenByDescending(b => b.Id)
                .FirstOrDefault();
        }


        /// <summary>
        /// Получение списка всех книг, отсортированного в алфавитном порядке по названию.
        /// </summary>
        /// <returns></returns>
        public List<Book> GetBookName()
        {
            return db.Books
                .OrderBy(t => t.Title)
                .ToList();
        }


        /// <summary>
        /// Получение списка всех книг, отсортированного в порядке убывания года их выхода.
        /// </summary>
        /// <returns></returns>
        public List<Book> GetBooks()
        {
            return db.Books
                .OrderByDescending(t => t.Year)
                .ToList();
        }
            
    }
}
