using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OasisWebApp.DTOs
{
    public class CinemaDto
    {
        public int CinemaId { get; set; }

        [Required(ErrorMessage = "Введите название")]
        [StringLength(50)]
        [Display(Name = "Кинотеатр")]
        public string Name { get; set; }

        [Phone(ErrorMessage = "Телефон введен некорректно")]
        [Display(Name = "Телефонный номер")]
        public string PhoneNumber { get; set; }
        
        [Required(ErrorMessage = "Введите E-mail")]
        [EmailAddress(ErrorMessage = "Данный email введен некорректно")]
        public string Email { get; set; }

        [Display(Name = "Адрес")]
        public AddressDto Address { get; set; }
        [Display(Name = "Фильмы")]
        public ICollection<FilmDto> Films { get; set; }
    }
}
