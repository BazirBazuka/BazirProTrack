using BazirProTrack.BL.Model;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;


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
        public User User { get; }

        /// <summary>
        /// Создание нового контроллера пользователя | Creating a New User Controller
        /// </summary>
        public UserController(string username, string gendername, DateTime birthDay, double weight, double height)
        {
            //TODO Проверка
            var gender = new Gender(gendername);
            User = new User(username, gender, birthDay, weight, height);

        }
        /// <summary>
        /// Загрузить данные пользователя | Load user data.
        /// </summary>
        /// <returns>Пользователь приложения | App user. </returns>

        public UserController()
        {
            var formater = new BinaryFormatter();

            using (var fs = new FileStream("Users.dat", FileMode.OpenOrCreate))
            {
                if (formater.Deserialize(fs) is User user)
                {
                    User = user;
                }
                // TODO: Что делать если пользоваетля не прочитали?
            }

        }

        /// <summary>
        /// Сохранить данные пользоватьеля | Save user data
        /// </summary>
        public void Save()
        {
            var formater = new BinaryFormatter();

            using (var fs = new FileStream("User.dat", FileMode.OpenOrCreate))
            {
                formater.Serialize(fs, User);
            }
        }
    }
}

