using System.ComponentModel.DataAnnotations;

namespace MvcSignPage.Models
{
    public class User
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3, ErrorMessage = "长度不对")]
        public string Username { get; set; }

        [StringLength(20, MinimumLength = 6, ErrorMessage = "长度不对")]
        [Required(ErrorMessage = "不能为空")]
        public string Password { get; set; }

        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "邮箱格式不对")]
        [Required(ErrorMessage = "不能为空")]
        public string Email { get; set; }
        
        [RegularExpression(@"^1(3|4|5|7|8)\d{9}$", ErrorMessage = "电话号码的格式不对")]
        [StringLength(11, ErrorMessage = "电话号码的长度不对")]
        [Required(ErrorMessage = "不能为空")]
        public string Telephone { get; set; }
    }
}