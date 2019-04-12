using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class RModel<T>
{
    public IQueryable<T> Result { get; set; }
    public T ResultRow { get; set; }
    public RType ResultType { get; set; }

    public List<string> ErrorList = new List<string>();
    public List<string> WarningList = new List<string>();
    public List<string> MessageList = new List<string>();
    public string MessageListJson { get; set; }
    public string ResultJson { get; set; }

    public string RedirectUrl { get; set; }

}

