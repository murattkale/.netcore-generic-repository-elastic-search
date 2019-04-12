
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class BaseSession : IBaseSession
{
    public BaseModel _BaseModel { get { return SessionRequest._User; } set { } }

}
