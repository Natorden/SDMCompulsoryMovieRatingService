# SDMCompulsoryMovieRatingService
SDM Compulsory Assignment 

Movie Rating

This assignment is about developing a class library using pair-programming and testdriven development.


What to develop?

In the assignment you must develop a service class implementing advanced functions
on a data source. The service class will get the raw data from a data source. The most
important business entity is a review for a movie. A review is a simple data class
containing a reviewer, a movie, a grade, and the date for the review. 

An example of a rating from this file is:

  {Reviewer:563, Movie:781196, Grade:2, Date:'2003-03-06'}

This means, that reviewer with id 563 had reviewed film with id 781196 Marts 6, 2003.
The reviewer rated the movie with a 2 (1 to 5 inclusive is a possible rating).
The class you must implement is a typical service class containing logic. You must
separate the logic from the data access by using dependency injection. In that way you
can either use mocking or implement your own data repository encapsulating the
actual data source (that might be the json-file or just a part of it). In production your
service class will be connected to a data repository class reading the reviews from a
live database.

The class you must implement must contain a function for each of the following
questions (with proper signatures):

1. On input N, what are the number of reviews from reviewer N?
    int GetNumberOfReviewsFromReviewer(int reviewer);
    
2. On input N, what is the average rate that reviewer N had given?
    double GetAverageRateFromReviewer(int reviewer);
    
3. On input N and R, how many times has reviewer N given rate R?
    int GetNumberOfRatesByReviewer(int reviewer, int rate);
    
4. On input N, how many have reviewed movie N?
    Int GetNumberOfReviews(int movie);
    
5. On input N, what is the average rate the movie N had received?
    double GetAverageRateOfMovie(int movie);
    
6. On input N and R, how many times had movie N received rate R?
    int GetNumberOfRates(int movie, int rate);
    
7. What is the id(s) of the movie(s) with the highest number of top rates (5)?
    List<int> GetMoviesWithHighestNumberOfTopRates();
    
8. What reviewer(s) had done most reviews?
    List<int> GetMostProductiveReviewers();
    
9. On input N, what is top N of movies? The score of a movie is its average rate.
    List<int> GetTopRatedMovies(int amount);
    
10. On input N, what are the movies that reviewer N has reviewed? The list should be sorted decreasing by rate first, and date secondly.
    List<int> GetTopMoviesByReviewer(int reviewer);
    
11. On input N, who are the reviewers that have reviewed movie N? The list should be sorted decreasing by rate first, and date secondly.
    List<int> GetReviewersByMovie(int movie);
    
    What and when to hand-in?
You must hand-in in groups of 2-4 students.
NOT LATER THAN FRIDAY 8/10-2021

The mail must contain full name of all team members and a attached .pdf document
containing:

1. Full name of all team members.
2. State of delivery
  Describe the state of your hand-in. In case you have not completed the test and implementation of all functions, you may specify what you have accomplished.
3. In depth description of two selected functions. For each of them you must present the test cases and explain why you find these sufficient.
4. Github Repositiory
  An url to a public github repository containing the project including production code and test project.
  
This assignment is compulsory; your work must be approved by the teacher.
In case your work is not approved you will get a second chance. Participation in the
SDM exam is only possible when all compulsory assignments are approved by your
teacher.
