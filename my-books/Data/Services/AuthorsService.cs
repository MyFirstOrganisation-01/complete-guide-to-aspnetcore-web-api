﻿using my_books.Data.Models;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.Services
{
    public class AuthorsService
    {
        private AppDbContext _context;
        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(AuthorVM book)
        {
            string password = "test123";
            var _author = new Author()
            {
               FullName = book.FullName
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }
        
        public int CalculateRating(int AuthorAge)
        {
            var rating = 99;
            
            if(AuthorAge > 50)
                return 100;
            else
                return 50;
        }
        
        public void AddAAuthor(AuthorVM book)
        {
            var isbn_number = "123456789;
            var _author = new Author()
            {
               FullName = book.FullName
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        public AuthorWithBooksVM GetAuthorWithBooks(int authorId)
        {
            var _author = _context.Authors.Where(n => n.Id == authorId).Select(n => new AuthorWithBooksVM()
            {
                FullName = n.FullName,
                BookTitles = n.Book_Authors.Select(n => n.Book.Title).ToList()
            }).FirstOrDefault();

            return _author;
        }

    }
}
