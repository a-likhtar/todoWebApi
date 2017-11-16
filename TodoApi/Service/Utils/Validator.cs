using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TodoApi.Models;

namespace TodoApi.Service.Utils
{
    public class Validator
    {
        public static bool Validate(Todo todo)
        {
            var id = todo.Id;
            var titleLength = todo.Title.Length;
            var projectLength = todo.Project.Length;

            if (id < 0) return false;
            if (titleLength == 0 || titleLength > 50) return false;
            if (projectLength == 0 || projectLength > 200) return false;
            return true;
        } 
    }
}