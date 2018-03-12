using System.ComponentModel.DataAnnotations;

namespace MvcSignPage.ViewModels
{
    public class SignInViewModel
    {
        [Required(ErrorMessage = "不能为空")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "长度不对")]
        public string Username { get; set; }

        [Required(ErrorMessage = "不能为空")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "长度不对")]
        public string Password { get; set; }
    }

    public class SignUpViewModel
    {
        [Required(ErrorMessage = "不能为空")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "长度不对")]
        public string Username { get; set; }

        [Required(ErrorMessage = "不能为空")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "长度不对")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "不能为空")]
        [Compare("Password", ErrorMessage = "密码和确认密码不匹配")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "不能为空")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "邮箱格式不对")]
        public string Email { get; set; }

        [Required(ErrorMessage = "不能为空")]
        [StringLength(11, ErrorMessage = "电话号码的长度不对")]
        [RegularExpression(@"^1(3|4|5|7|8)\d{9}$", ErrorMessage = "电话号码的格式不对")]
        public string Telephone { get; set; }
    }
}