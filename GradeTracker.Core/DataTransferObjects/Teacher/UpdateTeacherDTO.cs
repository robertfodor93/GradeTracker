﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTracker.Core.DataTransferObjects.Teacher
{
    public class UpdateTeacherDTO : BaseTeacherDTO, IBaseDTO
    {
        public int Id { get; set; }
    }
}
