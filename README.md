# Library

Backend solution that includes the main functionalities of a library.
App entities: 
            - Book
            - Reader/Borrower
A reader can borrow multiple books and a book can be borrowed by multiple readers.

App functionalities:
          Book logic:
            - Add a new book
            - Fetch all existent books
            - Fetch a book by its unique identifier generated in the app
            - Count number of books by ISBN
          Reader logic:
            - Register a new reader
            - Fetch all existent readers
            - Fetch a reader by its identity number  
          Book - Reader logic:
            - Borrow a book using the reader's identity number and the book's name.
            - Return a book using the reader's identity number and the book's name. There is a free borrow period of time, if that time have passed the reader will
            be charged with 1% of the book's rental price per each unit of time (defined in a app configurations file).

There are two app configuration files: AppConfig.cs, TestAppConfig.cs. It's recomended to use the TestAppConfig.cs when testing the application. The config file is registered as a singleton service in Program.cs.
            
