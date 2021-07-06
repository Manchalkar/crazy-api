using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crazy_api.Service
{
    public class CrazyService
    {
        public List<Models.CrazyApi> course_lst;

        public CrazyService()
        {
            course_lst = new List<Models.CrazyApi>()
            {
                new Models.CrazyApi() {MyProperty=1,Name="AZ-204"},
                new Models.CrazyApi() {MyProperty=2,Name="AZ-303"},
                new Models.CrazyApi() {MyProperty=3,Name="AZ-304"}
            };
        }

        public IEnumerable<Models.CrazyApi> GetCourses()
        {
            return (course_lst);
        }
    }
}
