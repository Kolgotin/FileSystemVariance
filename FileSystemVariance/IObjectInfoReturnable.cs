using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemVarianceLib
{
    interface IObjectInfoReturnable
    {
        DateTime GetCreatedDate();
        DateTime GetLastChangedDate();
        long GetByteSize();
    }
}
