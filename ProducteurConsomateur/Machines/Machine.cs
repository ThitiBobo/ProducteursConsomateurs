
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/**
 * 
 */
public abstract class Machine {


    protected int _id;

    protected ulong _minTime;

    protected ulong _maxTime;

    public Machine(int id, ulong minTime, ulong maxTime)
    {
        _id = id;
        _minTime = minTime;
        _maxTime = maxTime;
    }


}