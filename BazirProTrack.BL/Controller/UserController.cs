using BazirProTrack.BL.Model;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BazirProTrack.BL.Controller
{
    [Serializable]
    /// <summary>
    /// Контроллер пользователя | User controller
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователь приложения | App user
        /// </summary>
        public List<User> Users { get; }

        public User CurentUser { get; }

        public bool IsNewUser { get; } = false;

       

        /// <summary>
        /// Создание нового контроллера пользователя | Creating a New User Controller
        /// </summary>
        public UserController(string username)
        {

            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException("User Name can't be Null or White Space", nameof(username));
            }

            Users = GetUsersData();

            CurentUser = Users.SingleOrDefault(u => u.Name == username);
            if (CurentUser == null)
            {
                CurentUser = new User(username);
                Users.Add(CurentUser);
                IsNewUser = true;
                Save();
            }


        }
       
        /// <summary>
        /// Получить сохроненный список пользователей| Get saved users list.
        /// </summary>
        /// <returns>Пользователь приложения | App user. </returns>

        private List<User> GetUsersData()
        {
            var formater = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formater.Deserialize(fs) is List<User> users)
                {
                    return users;
                }
                else
                {
                    return new List<User>();
                }

            }

        }


        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            //Проверка
            CurentUser.Gender = new Gender(genderName);
            CurentUser.BirthDate = birthDate;
            CurentUser.Weight = weight;
            CurentUser.Height = height;
            Save();
        }

        /// <summary>
        /// Сохранить данные пользоватьеля | Save user data
        /// </summary>
        public void Save()
        {
            var formater = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formater.Serialize(fs, Users);
            }
        }
    }
}

