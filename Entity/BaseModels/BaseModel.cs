using System;
using System.Collections.Generic;


public class BaseModel : IBaseModel
{
    public int Id { get; set; }
    public int? OrderNo { get; set; }
    public int CreaUser { get; set; }
    public int? ModUser { get; set; }
    public DateTime CreaDate { get; set; }
    public DateTime? Tombstone { get; set; }
    public DateTime? ModDate { get; set; }




}

