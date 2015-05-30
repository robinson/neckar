using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebApplication.Entities {

    public interface IEntity {

        Guid Key { get; set; }
    }
}