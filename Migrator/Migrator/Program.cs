using System;
using System.Collections.Generic;
using Common.DataTypes.Dto;
using Common.DataTypes.Enums;
using Migrator.Helpers;

namespace Migrator
{
    class Program
    {
        static void Main(string[] args)
        {
            var films = GetFilmList();
            var users = GetUsersList();

            films.ForEach(MigratorHelper.Migrate);
            users.ForEach(MigratorHelper.Migrate);

            Console.WriteLine($"Successfully Migrated. Entities added Films: {films.Count}, Users: {users.Count}");
            Console.ReadKey();
        }

        private static List<Film> GetFilmList()
        {
            return new List<Film>
            {
                #region fill film list
                new Film
                {
                    Id = Guid.NewGuid(),
                    ReleaseDate = new DateTime(1994, 10, 14),
                    Title = "The Shawshank Redemption",
                    Type = FilmType.Old,
                    IsAvailable = true,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin et lacinia felis, non condimentum purus. Fusce in enim erat. Praesent est orci, interdum id libero quis, fringilla facilisis ex. "
                },
                new Film
                {
                    Id = Guid.NewGuid(),
                    ReleaseDate = new DateTime(1972, 03, 24),
                    Title = "The Godfather",
                    Type = FilmType.Old,
                    IsAvailable = true,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin et lacinia felis, non condimentum purus. Fusce in enim erat. Praesent est orci, interdum id libero quis, fringilla facilisis ex. "
                },
                new Film
                {
                    Id = Guid.NewGuid(),
                    ReleaseDate = new DateTime(2008, 07, 18),
                    Title = "The Dark Knight",
                    Type = FilmType.Regular,
                    IsAvailable = true,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin et lacinia felis, non condimentum purus. Fusce in enim erat. Praesent est orci, interdum id libero quis, fringilla facilisis ex. "

                },
                new Film
                {
                    Id = Guid.NewGuid(),
                    ReleaseDate = new DateTime(2003, 12, 17),
                    Title = "The Lord of the Rings: The Return of the King",
                    Type = FilmType.Regular,
                    IsAvailable = true,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin et lacinia felis, non condimentum purus. Fusce in enim erat. Praesent est orci, interdum id libero quis, fringilla facilisis ex. "


                },
                new Film
                {
                    Id = Guid.NewGuid(),
                    ReleaseDate = new DateTime(1999, 10, 15),
                    Title = "Fight Club",
                    Type = FilmType.Old,
                    IsAvailable = true,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin et lacinia felis, non condimentum purus. Fusce in enim erat. Praesent est orci, interdum id libero quis, fringilla facilisis ex. "


                },
                new Film
                {
                    Id = Guid.NewGuid(),
                    ReleaseDate = new DateTime(2018, 2, 16),
                    Title = "Black Panther",
                    Type = FilmType.NewRelease,
                    IsAvailable = true,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin et lacinia felis, non condimentum purus. Fusce in enim erat. Praesent est orci, interdum id libero quis, fringilla facilisis ex. "


                },
                new Film
                {
                    Id = Guid.NewGuid(),
                    ReleaseDate = new DateTime(2018, 3, 16),
                    Title = "Tomb Raider",
                    Type = FilmType.NewRelease,
                    IsAvailable = true,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin et lacinia felis, non condimentum purus. Fusce in enim erat. Praesent est orci, interdum id libero quis, fringilla facilisis ex. "


                },
                new Film
                {
                    Id = Guid.NewGuid(),
                    ReleaseDate = new DateTime(2018, 3, 23),
                    Title = "Pacific Rim: Uprising",
                    Type = FilmType.NewRelease,
                    IsAvailable = true,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin et lacinia felis, non condimentum purus. Fusce in enim erat. Praesent est orci, interdum id libero quis, fringilla facilisis ex. "


                },
                new Film
                {
                    Id = Guid.NewGuid(),
                    ReleaseDate = new DateTime(2018, 4, 27),
                    Title = "Avengers: Infinity War",
                    Type = FilmType.NewRelease,
                    IsAvailable = true,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin et lacinia felis, non condimentum purus. Fusce in enim erat. Praesent est orci, interdum id libero quis, fringilla facilisis ex. "


                },
                new Film
                {
                    Id = Guid.NewGuid(),
                    ReleaseDate = new DateTime(2018, 5, 18),
                    Title = "Deadpool 2 ",
                    Type = FilmType.NewRelease,
                    IsAvailable = true,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin et lacinia felis, non condimentum purus. Fusce in enim erat. Praesent est orci, interdum id libero quis, fringilla facilisis ex. "

                },

                #endregion
            };
        }

        private static List<User> GetUsersList()
        {
            return new List<User>
            {
                #region fill users list
                new User
                {
                    Id = Guid.NewGuid(),
                    AvailableBonus = new Random().Next(5, 100),
                    Name = "Bruse",
                    Surname = "Wayne",
                    Username = "U" + new Random().Next(100, 200),
                    Contact = new Contact
                    {
                        Address = "Criminal Street 14, County, Gotham",
                        Email = "im@batman.com",
                        Phone = "88005553535"
                    }
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    AvailableBonus = new Random().Next(5, 100),
                    Name = "Bruse",
                    Surname = "Wayne",
                    Username = "U" + new Random().Next(100, 200),
                    Contact = new Contact
                    {
                        Address = "Criminal Street 14, County, Gotham",
                        Email = "im@batman.com",
                        Phone = "88005553535"
                    }
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    AvailableBonus = new Random().Next(5, 100),
                    Name = "Bruse",
                    Surname = "Wayne",
                    Username = "U" + new Random().Next(100, 200),
                    Contact = new Contact
                    {
                        Address = "Criminal Street 14, County, Gotham",
                        Email = "im@batman.com",
                        Phone = "88005553535"
                    }
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    AvailableBonus = new Random().Next(5, 100),
                    Name = "Bruse",
                    Surname = "Wayne",
                    Username = "U" + new Random().Next(100, 200),
                    Contact = new Contact
                    {
                        Address = "Criminal Street 14, County, Gotham",
                        Email = "im@batman.com",
                        Phone = "88005553535"
                    }
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    AvailableBonus = new Random().Next(5, 100),
                    Name = "Bruse",
                    Surname = "Wayne",
                    Username = "U" + new Random().Next(100, 200),
                    Contact = new Contact
                    {
                        Address = "Criminal Street 14, County, Gotham",
                        Email = "im@batman.com",
                        Phone = "88005553535"
                    }
                },
                #endregion
            };
        }
    }
}
