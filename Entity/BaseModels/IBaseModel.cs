using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IBaseModel
{
    int Id { get; set; }
    int? OrderNo { get; set; }
    int CreaUser { get; set; }
    int? ModUser { get; set; }
    DateTime CreaDate { get; set; }
    DateTime? Tombstone { get; set; }

    DateTime? ModDate { get; set; }
}

