using System;

namespace BazirProTrack.BL.Model
{
    [Serializable]
    /// <summary>
    /// Пользователь | User
    /// </summary>
    public class User
    {
        #region Properties
        /// <summary>
        /// Имя | Name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Пол | Gender
        /// </summary>
        public Gender Gender { get; }

        /// <summary>
        /// Дата рождения | BirthDate
        /// </summary>
        public DateTime BirthDate { get; }

        /// <summary>
        /// Вес | Weight
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Рост | Height
        /// </summary>
        public double Height { get; set; }
        #endregion

        /// <summary>
        /// Создать нового пользователя | Create new user
        /// </summary>
        /// <param name="name">Имя. </param>
        /// <param name="gender">Пол. </param>
        /// <param name="birthDate">Дата рождения. </param>
        /// <param name="weight">Вес. </param>
        /// <param name="height">Рост. </param>
        public User(string name,
                    Gender gender,
                    DateTime birthDate,
                    double weight,
                    double height)
        {

            #region Checking for exceptions

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Username can`t be empty or null.", nameof(name));
            }

            if (gender == null)
            {
                throw new ArgumentNullException("Gender can`t be empty or null.", nameof(gender));
            }

            if (birthDate < DateTime.Parse("01.01.1900") || birthDate > DateTime.Today)
            {
                throw new ArgumentException("Impossible date of birth.", nameof(birthDate));
            }

            if (weight <= 0)
            {
                throw new ArgumentException("Weight cannot be less than or equal to 0.", nameof(weight));
            }

            if (height <= 0)
            {
                throw new ArgumentException("Height cannot be less than or equal to 0.", nameof(height));
            }

            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
