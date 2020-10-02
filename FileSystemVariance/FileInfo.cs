using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemVarianceLib
{
    class FileInfo : AbstractObjectInfo, ICreatedDateReturnable
    {
        public string Name
        {
            get => _Name;
            private set
            {
                _Name = value;
            }
        }
        public long ByteSize
        {
            get => _ByteSize;
            private set
            {
                _ByteSize = value;
            }
        }

        public override DateTime GetCreatedDate()
        {
            return _CreatedDate;
        }

        public override DateTime GetLastChangedDate()
        {
            return _LastChangedDate;
        }

        public override long GetByteSize()
        {
            return _ByteSize;
        }
    }
}
