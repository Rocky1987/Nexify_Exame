using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Nexify.DataAccess.DataModel
{
    public class UserDataModel
    {
        //public int item { get; set; }
        [Required(ErrorMessage = "請輸入姓名")]
        [StringLength(10, ErrorMessage = "名子長度不可超過10碼")]
        public string Name { get; set; }

        [Required(ErrorMessage = "請輸入出生年月日")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "薪資")]
        [Range(0, 100000)]
        public int Salary { get; set; }

        [Required(ErrorMessage = "請輸入地址")]
        [StringLength(50, ErrorMessage = "地址長度不可超過50碼")]
        public string Address { get; set; }
    }
}
